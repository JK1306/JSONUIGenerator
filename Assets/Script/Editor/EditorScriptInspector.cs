using UnityEngine;
using UnityEditor;
using System.Runtime;
using System.Reflection;

[CustomEditor(typeof(EditorScript))]
public class EditorScriptInspector : Editor {

    EditorScript editorScriptInstance;
    SerializedObject editoScriptSerializedObject;

    private void Awake() {
        editorScriptInstance = (EditorScript)target;

        // Debug.Log($"Target : {editorScriptInstance}");

        editoScriptSerializedObject = new SerializedObject(editorScriptInstance);
        
        // Debug.Log($"Editor Script Object : {editoScriptSerializedObject}");
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        editoScriptSerializedObject?.ApplyModifiedProperties();

        if(editoScriptSerializedObject == null) return;

        object editorScriptObject = editoScriptSerializedObject.targetObject;

        EditorGUILayout.Space();

        if(GUILayout.Button("Load Data")){
            editorScriptObject.GetType().GetMethod("LoadJSONData").Invoke(editorScriptObject, null);
        }

        EditorGUILayout.Space();

        if(GUILayout.Button("Export UI")){
            editorScriptObject.GetType().GetMethod("ExportUItoJSON").Invoke(editorScriptObject, null);
        }
    }
}