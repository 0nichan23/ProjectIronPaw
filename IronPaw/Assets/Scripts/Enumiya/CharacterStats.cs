using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct CharacterStats
{
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int Faith;
}

[CustomPropertyDrawer(typeof(CharacterStats))]
public class CharacterStatsDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        float recSize = 50;
        float statIndent = 40;
        SerializedProperty strength = property.FindPropertyRelative("Strength");
        SerializedProperty dexterity = property.FindPropertyRelative("Dexterity");
        SerializedProperty intelligence = property.FindPropertyRelative("Intelligence");
        SerializedProperty faith = property.FindPropertyRelative("Faith");

        // Draw Label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);
        int lines = 1;
        if (property.isExpanded)
        {
            Rect strengthRect = new Rect(position.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);
            GUIContent strLabel = new GUIContent();
            strLabel.text = "Strength :";
            Rect strLabelLabelPos = EditorGUI.PrefixLabel(new Rect(position.x - strengthRect.x + statIndent, strengthRect.y, 0, 
                position.height), GUIUtility.GetControlID(FocusType.Passive), strLabel);
            EditorGUI.PropertyField(strengthRect, strength, GUIContent.none);


            Rect dexterityRect = new Rect(position.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);
            GUIContent dexterityLabel = new GUIContent();
            dexterityLabel.text = "Dexterity :";
            Rect dexterityLabelPos = EditorGUI.PrefixLabel(new Rect(position.x - dexterityRect.x + statIndent, dexterityRect.y, 0,
                position.height), GUIUtility.GetControlID(FocusType.Passive), dexterityLabel);
            EditorGUI.PropertyField(dexterityRect, dexterity, GUIContent.none);

            Rect intelligenceRect = new Rect(position.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);
            GUIContent intelligenceLabel = new GUIContent();
            intelligenceLabel.text = "Intelligence :";
            Rect intelligenceLabelPos = EditorGUI.PrefixLabel(new Rect(position.x - intelligenceRect.x + statIndent, intelligenceRect.y, 0,
                position.height), GUIUtility.GetControlID(FocusType.Passive), intelligenceLabel);
            EditorGUI.PropertyField(intelligenceRect, intelligence, GUIContent.none);

            Rect faithRect = new Rect(position.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);
            GUIContent faithLabel = new GUIContent();
            faithLabel.text = "Faith :";
            Rect faithLabelPos = EditorGUI.PrefixLabel(new Rect(position.x - faithRect.x + statIndent, faithRect.y, 0,
                position.height), GUIUtility.GetControlID(FocusType.Passive), faithLabel);
            EditorGUI.PropertyField(faithRect, faith, GUIContent.none);
        }

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int totalLines = 2;

        if (property.isExpanded)
        {
            totalLines += 4;
        }

        return EditorGUIUtility.singleLineHeight * totalLines + EditorGUIUtility.standardVerticalSpacing * (totalLines - 1);
    }
}
