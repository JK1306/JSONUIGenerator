using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace AttachmentComponent
{    
    [Serializable]
    public abstract class BaseComponent
    {
        public bool isEnabled;
        public ComponentType componentType;

        public abstract string GetComponentInfo();
    }

    public enum ComponentType{
        Image,
        Text,
        Button,
        DropDown,
        InputField
    }

    [Serializable]
    public class UIImage : BaseComponent
    {
        public Color imageColor;
        public Sprite sourceImage;
        Image imageComp;

        public UIImage(Component imageComponent){
            componentType = ComponentType.Image;

            imageComp = imageComponent as Image;
            imageColor = imageComp.color;
            sourceImage = imageComp.sprite;
        }

        public override string GetComponentInfo()
        {
            return $"{{\"componentType\":\"{componentType}\", \"imageColor\":{{\"r\":{imageColor.r}, \"g\":{imageColor.g}, \"b\":{imageColor.b}, \"a\":{imageColor.a}}}, \"spriteImage\":\"{sourceImage.name}\"}}";
        }
    }

    [Serializable]
    public class UIButton : BaseComponent
    {
        public bool interactable;
        Button buttonComp;

        public UIButton(Component buttonComponent){
            componentType = ComponentType.Button;

            // Debug.Log($"--> {buttonComponent.name}");
            // Debug.Log(buttonComponent == null);
            buttonComp = buttonComponent as Button;
            // Debug.Log($":: --> {buttonComp == null}");
            interactable = buttonComp.interactable;
        }

        public override string GetComponentInfo()
        {
            return $"{{\"componentType\":\"{componentType}\", \"isInteractable\":\"{interactable}\"}}";
        }
    }

    [Serializable]
    public class UIText : BaseComponent
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
        public int fontAllignmentIndex;
        public FontAllignment fontAllignment;
        Text textComp;

        public UIText(Component textComponent){
            componentType = ComponentType.Text;
            textComp = textComponent as Text;
            
            textString = textComp.text;
            fontSize = textComp.fontSize;
            fontAllignmentIndex = (int)textComp.alignment;
            fontAllignment = (FontAllignment)fontAllignmentIndex;
        }

        public override string GetComponentInfo()
        {
            return $"{{\"componentType\":\"{componentType}\", \"textString\":\"{textString}\", \"fontSize\":{fontSize}, \"fontAllignmentIndex\":\"{fontAllignmentIndex}\"}}";
        }
    }

    [Serializable]
    public class UIDropDown : BaseComponent
    {
        public List<string> optionList;

        public override string GetComponentInfo()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class UIInputField : BaseComponent
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

        public override string GetComponentInfo()
        {
            throw new NotImplementedException();
        }
    }
}