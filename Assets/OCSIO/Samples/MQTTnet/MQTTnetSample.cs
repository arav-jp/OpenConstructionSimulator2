using UnityEngine;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Disconnecting;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Text;

public class MQTTnetSample : MonoBehaviour
{
    [SerializeField] private string _subscribeTopic = "/themes/sub";
    [SerializeField] private string _publishTopic = "/themes/pub";

    [SerializeField] private string _publishMsg = "Hello World";

    private IMqttClient mqttClient;
    private IMqttClientOptions options;
    private string host = "localhost";

    async void Start()
    {
        mqttClient = new MqttFactory().CreateMqttClient();

        options = new MqttClientOptionsBuilder()
            .WithTcpServer(host, 1883)
            .Build();

        mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnSubscribed);
        mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
        mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);

        try
        {
            await mqttClient.ConnectAsync(options);
        }
        catch
        {

        }
    }

    private async void OnConnected(MqttClientConnectedEventArgs e)
    {
        Debug.Log("MQTT broker connected");
        await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(_subscribeTopic).Build());
        Debug.Log("TOPIC Subscribed");
    }

    private void OnSubscribed(MqttApplicationMessageReceivedEventArgs e)
    {
        Debug.Log("OnAppMessage");
        string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
        Debug.Log(payload);
    }

    private async void OnDisconnected(MqttClientDisconnectedEventArgs e)
    {

        if (mqttClient == null)
        {
            Debug.Log("MQTT Client is disposed");
            return;
        }
        else
        {
            Debug.Log("Connection failed. Try again in 5 secs");
        }

        await Task.Delay(TimeSpan.FromSeconds(5));

        try
        {
            Debug.Log("Start connection");
            await mqttClient.ConnectAsync(options);
        }
        catch
        {

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Publish();
        }
    }

    private async void Publish()
    {
        var message = new MqttApplicationMessageBuilder()
            .WithTopic(_publishTopic)
            .WithPayload(_publishMsg)
            .WithExactlyOnceQoS()
            .WithRetainFlag()
            .Build();

        await mqttClient.PublishAsync(message, CancellationToken.None);
    }

    private void OnDestroy()
    {
        mqttClient.Dispose();
        mqttClient = null;
    }
}