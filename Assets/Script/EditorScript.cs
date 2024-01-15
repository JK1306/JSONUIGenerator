using System;
using System.Collections;
using System.Collections.Generic;
using AttachmentComponent;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class EditorScript : MonoBehaviour
{
    [TextArea(20, 20)]
    public string jsonString;
    public List<Object_> templateObjects;

    public void LoadJSONData(){
        Debug.Log("Came here....");

        if(jsonString == ""){
            Debug.Log("String null.");
        }else{
            Debug.Log(jsonString);
        }
    }

    public void ExportUItoJSON()
    {
        templateObjects.Clear();

        templateObjects = GetAllObjects(gameObject);

        foreach (var templateObject in templateObjects)
        {
            Debug.Log($"Object Name : {templateObject.goObject.name}", templateObject.goObject);
            string objectInfo = templateObject.GetObjectInfo();
            Debug.Log(objectInfo);
        }
        // Debug.Log($"templateObjects count : {templateObjects.Count}");
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

    // public Object_ GetGameObject(GameObject go){
    //     return new Object_(go.name);
    // }
}
