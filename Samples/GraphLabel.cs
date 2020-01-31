using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SMILEI.Core.Samples
{
    [ExecuteAlways]
    public class GraphLabel : MonoBehaviour
    {
        public SetLabelEvent SetLabel = new SetLabelEvent();
        public Graphic ColorGraphic;

        [Serializable] public class SetLabelEvent : UnityEvent<string> {}
        [Serializable] public class SetColorEvent : UnityEvent<Color> {}
        

        public void SetDisplayValues(string itemName, Color displayColor)
        {
            gameObject.name = itemName;
            
            SetLabel.Invoke(itemName);
            ColorGraphic.color = displayColor;
        }

    }
}
