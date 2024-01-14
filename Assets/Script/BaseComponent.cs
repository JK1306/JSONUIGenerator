using System;
using System.Collections.Generic;
using UnityEngine;

namespace AttachmentComponent
{    
    public class BaseComponent
    {
        public bool isEnabled;
    }

    [Serializable]
    public class Image : BaseComponent
    {
        public Color imageColor;
        public Sprite sourceImage;
    }

    [Serializable]
    public class Button : BaseComponent
    {
        public bool interactable;

        public Button(Component buttonComponent){
            // interactable = buttonComponent.
        }
    }

    [Serializable]
    public class Text : BaseComponent
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
    public class DropDown : BaseComponent
    {
        public List<string> optionList;
    }

    [Serializable]
    public class InputField : BaseComponent
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
}