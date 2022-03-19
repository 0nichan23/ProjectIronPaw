using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{
    public TargetType TargetType;
    public List<Character> Targets = new List<Character>();


    public abstract void PlayEffect();

    
}

//[CustomPropertyDrawer(typeof(CardEffect))]
//public class CardEffectDrawer : PropertyDrawer
//{
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        // Using BeginProperty / EndProperty on the parent property means that
//        // prefab override logic works on the entire property.
//        EditorGUI.BeginProperty(position, label, property);

//        float recSize = 50;

//        // Draw Label
//        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

//        // Define X & Y Labels
//        GUIContent xLabel = new GUIContent();
//        xLabel.text = "X :";

//        Rect xLabelPos = EditorGUI.PrefixLabel(new Rect(position.x, position.y, 0, position.height), GUIUtility.GetControlID(FocusType.Passive), xLabel);
//        Rect xRect = new Rect(xLabelPos.x - 140, position.y, recSize, position.height);
//        EditorGUI.PropertyField(xRect, property.FindPropertyRelative("X"), GUIContent.none);


//        EditorGUI.EndProperty();
//    }
//}
