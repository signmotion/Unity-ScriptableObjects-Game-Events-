using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GameEvent), true)]
[CanEditMultipleObjects]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        GameEvent ge = target as GameEvent;

        if (GUILayout.Button("Raise"))
        {
            ge.Raise();
        }
    }
}
