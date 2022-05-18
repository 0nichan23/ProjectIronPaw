using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private Text _buttonText;
    [SerializeField]
    private Image _buttonImage;
    public void SetGameOverUI(string title, string buttonText, UnityEngine.Color buttonColor)
    {
        _title.text = title;
        _buttonText.text = buttonText;
        _buttonImage.color = buttonColor;

    }
}
