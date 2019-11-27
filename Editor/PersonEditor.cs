using System;

namespace SMILEI.Core.Editor
{
    /// <summary>
    /// Stub for Person custom inspector.
    /// </summary>
    public class PersonEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            // Update this editor always.
            base.OnInspectorGUI();
            Repaint();
        }
    }

}


