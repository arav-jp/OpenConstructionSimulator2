using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ReadableScriptableObjectAttribute))]
public class ReadableScriptableObjectDrawer : PropertyDrawer
{
    private Editor editor = null;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginDisabledGroup(true);
        EditorGUI.PropertyField(position, property, label, true);
        EditorGUI.EndDisabledGroup();

        //EditorGUI.PropertyField(position, property, label, false);

        if (property.objectReferenceValue != null)
            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none);
        else
            return;

        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;
            if (!editor)
                Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);
            editor.OnInspectorGUI();
            EditorGUI.indentLevel--;
        }
    }
}
#endif