using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(FieldCounter))]
public class FieldCounterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FieldCounter editor = (FieldCounter)target;

        editor.isTriggerAtFinish = EditorGUILayout.Toggle("Trigger Event at Finish", editor.isTriggerAtFinish);

        if(editor.isTriggerAtFinish)
        {
            editor.TargetGameObject = EditorGUILayout.ObjectField("Target Game Object", editor.TargetGameObject, typeof(GameObject)) as GameObject;
            editor.TriggerFunction = EditorGUILayout.TextField("Function name", editor.TriggerFunction);
            editor.ThresholdToTrigger = EditorGUILayout.IntField("Threshold to trigger", editor.ThresholdToTrigger);
        }

        EditorGUILayout.TextArea("Count: " + editor.counter.ToString());
    }
}
