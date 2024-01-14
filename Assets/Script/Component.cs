using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[Serializable]
public class Component
{
    public Vector3 objecttPosition;
    public Vector3 objectScale;
    public Vector3 objectRotation;
}

[Serializable]
public class Image : Component
{
    public Color imageColor;
    public Sprite sourceImage;
}

[Serializable]
public class Button : Image
{
    public bool interactable;
}

[Serializable]
public class Text : Component
{
    public enum FontAllignment{
        UpperLeft,
        UpperCenter,
        UpperRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        LowerLeft,
        LowerCenter,
        LowerRight
    }

    public string textString;
    public int fontSize;
    public FontAllignment fontAllignment;
}

[Serializable]
public class DropDown : Image
{
    public List<string> optionList;
}

[Serializable]
public class InputField : Image
{
    public enum InputFieldType{
        Standard,
        Autocorrected,
        IntegerNumber,
        DecimalNumber,
        Alphanumeric,
        Name,
        EmailAddress,
        Password,
        Pin,
        Custom
    }
    public string inputText;
    public InputFieldType fieldType;
}