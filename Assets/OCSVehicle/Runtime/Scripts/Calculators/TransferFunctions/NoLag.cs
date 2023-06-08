using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class NoLag : TransferFunction
    {
        protected override void Calc()
        {
            base._output = base._input;
        }
    }
}
