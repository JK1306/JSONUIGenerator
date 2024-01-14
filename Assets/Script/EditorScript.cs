using System.Collections;
using System.Collections.Generic;
using AttachmentComponent;
using UnityEngine;

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

    public void ExportUItoJSON(){
        int totalChildCount = gameObject.transform.childCount;

        for (int i = 0; i < totalChildCount; i++)
        {
            Debug.Log($"Name : {gameObject.transform.GetChild(i).name}");
            
            Object_ currentObject = new Object_(gameObject.transform.GetChild(i).gameObject);

            GetAllComponentsAttached(currentObject);
        }
    }

    public void GetAllComponentsAttached(Object_ go){
        Component[] allComponent = go.goObject.GetComponents<Component>();

        Debug.Log($"Game Object {go.gameObjectName}");

        foreach (var item in allComponent)
        {
            GetComponent(item);
        }
    }

    public BaseComponent GetComponent(Component component){

        Debug.Log(component.name);

        if(component.name.ToLower().Contains("button")){
            // return new Button(component.enabled);
        }

        return null;
    }

    // public Object_ GetGameObject(GameObject go){
    //     return new Object_(go.name);
    // }
}
