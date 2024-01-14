using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
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
    public List<BaseComponent> attachedComponent;
    public List<Object_> childComponents;

    public Object_(GameObject gameObject){
        gameObjectName = gameObject.name;
        goObject = gameObject;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        
        objectMinOffset = rectTransform.offsetMin;
        objectMaxOffset = rectTransform.offsetMax;

        objectScale = rectTransform.localScale;
        // objectRotation = rectTransform.localRotation;
    }
}
