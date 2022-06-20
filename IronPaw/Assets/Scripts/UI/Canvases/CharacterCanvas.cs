using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _characterName;

    [SerializeField] private CharacterStatusEffectsInfoScreen _characterStatusEffectsInfoScreen;
    [SerializeField] private CharacterHighlightCanvas _characterHighlightCanvas;
    [SerializeField] private List<GameObject> _colors;  

    public void ToggleScreens(Character character, bool state)
    {
        InitInfo(character);

        _characterHighlightCanvas.gameObject.SetActive(state);
        _characterHighlightCanvas.InitInfo(character);
        _characterStatusEffectsInfoScreen.gameObject.SetActive(!state);
        _characterStatusEffectsInfoScreen.InitInfo(character);

        if(UIManager.Instance.SelectionCanvas)
        {
            PartyManager.Instance.CancelCard();
        }
    }

    private void InitInfo(Character character)
    {
        _characterName.text = character.CharacterName;
        InitColorSprites(character);
    }

    private void InitColorSprites(Character character)
    {
        foreach (var colorSprite in _colors)
        {
            colorSprite.SetActive(false);
        }

        foreach (var color in character.Colors)
        {
            _colors[(int)color].SetActive(true);
        }
    }
}
