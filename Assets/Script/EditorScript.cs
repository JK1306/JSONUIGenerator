using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using AttachmentComponent;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class EditorScript : MonoBehaviour
{
    [TextArea(20, 20)]
    public string jsonString;
    [HideInInspector] public List<Object_> templateObjects;
    string FILE_PATH = "UI_JSON.json";

    public void LoadJSONData(){

        if(jsonString == ""){
            Debug.Log("String null.");
        }else{
            LoadJSON(jsonString);
        }
    }

    public void ExportUItoJSON(){
        templateObjects.Clear();

        templateObjects = GetAllObjects(gameObject);

        List<string> objectInfos = new List<string>();

        foreach (var templateObject in templateObjects)
        {
            // Debug.Log($"Object Name : {templateObject.goObject.name}", templateObject.goObject);
            string objectInfo = templateObject.GetObjectInfo();
            // Debug.Log(objectInfo);
            objectInfos.Add(objectInfo);
        }

        string jsonResponse = $"[{String.Join(',', objectInfos.ToArray())}]";

        using(StreamWriter writer = new StreamWriter(FILE_PATH)){
            writer.WriteLine(jsonResponse);
        }
        Debug.Log($"File Store in : {Regex.Replace(Application.dataPath, @"/Assets$", "")}/{FILE_PATH}");
    }

    private List<Object_> GetAllObjects(GameObject parentObject)
    {
        int totalChildCount = parentObject.transform.childCount;

        List<Object_> tempObject = new List<Object_>();

        // Debug.Log($"Parent Object : {parentObject.name}", parentObject);

        for (int i = 0; i < totalChildCount; i++)
        {
            GameObject currentGameObject = parentObject.transform.GetChild(i).gameObject;

            // Debug.Log(currentGameObject.name, currentGameObject);

            Object_ currentObject = new Object_(currentGameObject);

            GetAllComponentsAttached(currentObject);

            currentObject.childObjects = GetAllObjects(currentGameObject);

            tempObject.Add(currentObject);
        }

        // Debug.Log($"Parent Object : {parentObject.name} - Count {tempObject.Count}", parentObject);

        return tempObject;
    }

    public void GetAllComponentsAttached(Object_ go){
        Component[] allComponent = go.goObject.GetComponents<Component>();

        foreach (var item in allComponent)
        {
            BaseComponent baseComponent = GetComponent(item, go);
            if(baseComponent != null)
                go.attachedComponents.Add(baseComponent);
        }
    }

    public BaseComponent GetComponent(Component component, Object_ componentObject){

        if(component as Button){
            return new UIButton(componentObject.goObject.GetComponent<Button>());
        }else if(component as Image){
            return new UIImage(componentObject.goObject.GetComponent<Image>());
        }else if(component as Text){
            return new UIText(componentObject.goObject.GetComponent<Text>());
        }

        return null;
    }

    void LoadJSON(string jsonString){
        JSONNode jsonNode = JSON.Parse(jsonString);
        for (int i = 0; i < jsonNode.Count; i++)
        {
            CreateUI(jsonNode[i]);
        }
    }

    void CreateUI(JSONNode jsonNode){
        GameObject emptyGO = new GameObject(jsonNode["name"]);
        emptyGO.AddComponent<RectTransform>();
        RectTransform rect = emptyGO.GetComponent<RectTransform>();
        rect.anchorMin = new Vector3(
                jsonNode["position"]["anchorMin"]["x"],
                jsonNode["position"]["anchorMin"]["y"],
                jsonNode["position"]["anchorMin"]["z"]
        );
        rect.anchorMax = new Vector3(
                jsonNode["position"]["anchorMax"]["x"],
                jsonNode["position"]["anchorMax"]["y"],
                jsonNode["position"]["anchorMax"]["z"]
        );
        rect.localPosition = new Vector3(
                jsonNode["position"]["localPosition"]["x"],
                jsonNode["position"]["localPosition"]["y"],
                jsonNode["position"]["localPosition"]["z"]
        );
        rect.offsetMin = new Vector3(
                jsonNode["position"]["minOffset"]["x"],
                jsonNode["position"]["minOffset"]["y"],
                jsonNode["position"]["minOffset"]["z"]
        );
        rect.offsetMax = new Vector3(
                jsonNode["position"]["maxOffset"]["x"],
                jsonNode["position"]["maxOffset"]["y"],
                jsonNode["position"]["maxOffset"]["z"]
        );
        emptyGO.transform.SetParent(transform);
    }
}
