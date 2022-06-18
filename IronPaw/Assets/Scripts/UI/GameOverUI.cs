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
    private TextMeshProUGUI _buttonText;
    [SerializeField]
    private Image _buttonImage;
    public void SetGameOverUI(string title, string buttonText)
    {
        _title.text = title;
        _buttonText.text = buttonText;

    }
}
