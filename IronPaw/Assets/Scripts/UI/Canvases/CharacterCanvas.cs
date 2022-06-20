using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _characterName;

    [SerializeField] private CharacterStatusEffectsInfoScreen _characterStatusEffectsInfoScreen;
    [SerializeField] private CharacterHighlightCanvas _characterHighlightCanvas;
    [SerializeField] private List<GameObject> _colors;

    [SerializeField] private Color _red;
    [SerializeField] private Color _green;
    [SerializeField] private Color _blue;
    [SerializeField] private Color _white;
    [SerializeField] private Color _colorless;

    [SerializeField] Image _panelBackground;

    private Dictionary<ColorIdentity, Color> _colorDictionary;


    private void Start()
    {
        InitializeColorDictionary();
    }

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
        InitializeColorDictionary();

        ColorIdentity characterColor = character.Colors[0];
        Color toColor = _colorDictionary[characterColor];
        _panelBackground.color = toColor;
    }


    private void InitializeColorDictionary()
    {
        _colorDictionary = new Dictionary<ColorIdentity, Color>();
        _colorDictionary.Add(ColorIdentity.Red, _red);
        _colorDictionary.Add(ColorIdentity.Green, _green);
        _colorDictionary.Add(ColorIdentity.Blue, _blue);
        _colorDictionary.Add(ColorIdentity.White, _white);
        _colorDictionary.Add(ColorIdentity.Colorless, _colorless);
    }
}
