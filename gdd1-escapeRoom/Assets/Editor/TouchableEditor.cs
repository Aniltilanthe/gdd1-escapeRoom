// TouchableEditor.cs
using UnityEngine;
using UnityEditor;

namespace UnityEngine.UI
{

    // TouchableEditor component, to prevent treating the component as a Text object.
    [CustomEditor(typeof(Touchable))]
    public class TouchableEditor : Editor
    {
        public override void OnInspectorGUI() { }
    }
}
