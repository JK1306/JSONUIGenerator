using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using AttachmentComponent;
using UnityEngine;

[Serializable]
public class Object_
{
    public string gameObjectName;
    public GameObject goObject;
    public Vector3 objectMinOffset,
                    objectMaxOffset;
    public Vector3 objectScale;
    public Vector3 objectRotation;
    [SerializeReference] public List<BaseComponent> attachedComponents;
    public List<Object_> childObjects;

    public Object_(GameObject gameObject){
        attachedComponents = new List<BaseComponent>();
        childObjects = new List<Object_>();

        gameObjectName = gameObject.name;
        goObject = gameObject;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        
        objectMinOffset = rectTransform.offsetMin;
        objectMaxOffset = rectTransform.offsetMax;

        objectScale = rectTransform.localScale;
        // objectRotation = rectTransform.localRotation;
    }

    public string GetObjectInfo(){
        return $"{{\"name\":\"{gameObjectName}\", \"position\":{{\"minOffset\":{{\"x\":{objectMinOffset.x},\"y\":{objectMinOffset.y},\"z\":{objectMinOffset.z}}}, \"maxOffset\":{{\"x\":{objectMaxOffset.x},\"y\":{objectMaxOffset.y},\"z\":{objectMaxOffset.z}}}}}, \"scale\":{{\"x\":{objectScale.x},\"y\":{objectScale.y},\"z\":{objectScale.z}}}, \"attachedComponentInfo\":{GetAttachedComponentInfo()}, \"childObjects\":{GetChildInfo()}}}";
    }

    string GetChildInfo(){
        string childInfo = "[";
        int childObjectCount = childObjects.Count;

        for (int i = 0; i < childObjectCount; i++)
        {
            if(i < (childObjectCount-1)){
                childInfo += $"{childObjects[i].GetObjectInfo()},";
            }else{
                childInfo += $"{childObjects[i].GetObjectInfo()}";
            }
        }

        childInfo += "]";
        return childInfo;
    }

    string GetAttachedComponentInfo(){
        string componentInfo = "[";
        int componentLength = attachedComponents.Count;

        for (int i = 0; i < componentLength; i++)
        {
            Debug.Log(attachedComponents[i].componentType);
            if(i < (componentLength-1)){
                componentInfo += $"{attachedComponents[i].GetComponentInfo()}, ";
            }else{
                componentInfo += $"{attachedComponents[i].GetComponentInfo()}";
            }
        }

        componentInfo += "]";
        return componentInfo;
    }
}
