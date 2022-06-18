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
    [SerializeField] private Image _buttonImage;

    [SerializeField] private Image _titleGraphic;
    [SerializeField] private Sprite _winSprite;
    [SerializeField] private Sprite _loseSprite;

    public void SetGameOverUI(string title, string buttonText, bool win)
    {
        _title.text = title;
        _buttonText.text = buttonText;

        if(win)
        {
            _titleGraphic.sprite = _winSprite;
        }
        else
        {
            _titleGraphic.sprite = _loseSprite;
        }

    }
}
