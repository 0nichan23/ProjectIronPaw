using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    TextMeshPro textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(string input, Material givenFont)
    {
        textMesh.SetText(input);
        textMesh.fontMaterial = givenFont;
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
