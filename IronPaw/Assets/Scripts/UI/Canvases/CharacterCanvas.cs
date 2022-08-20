using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


enum CharacterCanvasState
{
    CHARACTER_INFO,
    CHARACTER_STATUS_EFFECTS
}

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

    [SerializeField] GameObject _toggleButton;
    [SerializeField] TextMeshProUGUI _toggleCanvasModeButtonText;

    private CharacterCanvasState _currentState;
    private Dictionary<ColorIdentity, Color> _colorDictionary;
    private Character _cachedCharacter;


    private void Start()
    {
        InitializeColorDictionary();
    }

    public void ShowCharacterCanvas(Character character, bool state)
    {
        InitInfo(character);

        //determine which canvas state on canvas activation
        if (state)
        {
            _currentState = CharacterCanvasState.CHARACTER_INFO;
        }
        else
        {
            _currentState = CharacterCanvasState.CHARACTER_STATUS_EFFECTS;
        }

        SetToggleButton();

        _characterHighlightCanvas.gameObject.SetActive(state);
        _characterHighlightCanvas.InitInfo(character);
        _characterStatusEffectsInfoScreen.gameObject.SetActive(!state);
        _characterStatusEffectsInfoScreen.InitInfo(character);

        if(UIManager.Instance.SelectionCanvas)
        {
            CombatManager.Instance.CancelCard();
        }
    }

    // Setting up the toggle button before showing the canvas
    private void SetToggleButton()
    {
        // Show the toggle mode button only on heroes
        if (_cachedCharacter is Enemy)
        {
            _toggleButton.SetActive(false);
        }
        else
        {
            _toggleButton.SetActive(true);
        }

        // Change button contents based on canvas state
        switch (_currentState)
        {
            case CharacterCanvasState.CHARACTER_INFO:
                _toggleCanvasModeButtonText.text = "STATUS EFFECTS";
                break;

            case CharacterCanvasState.CHARACTER_STATUS_EFFECTS:
                _toggleCanvasModeButtonText.text = "CHACATER INFO";
                break;
        }
    }

    // toggling canvas state enum
    private void ToggleCanvasState()
    {
        if(_currentState == CharacterCanvasState.CHARACTER_INFO)
        {
            _currentState = CharacterCanvasState.CHARACTER_STATUS_EFFECTS;
        }
        else
        {
            _currentState = CharacterCanvasState.CHARACTER_INFO;
        }
    }

    // Swapping the canvas state
    public void ToggleScreens()
    {
        ToggleCanvasState();
        SetToggleButton();
        
        _characterHighlightCanvas.gameObject.SetActive(!_characterHighlightCanvas.gameObject.activeSelf);
        _characterStatusEffectsInfoScreen.gameObject.SetActive(!_characterStatusEffectsInfoScreen.gameObject.activeSelf);
    }

    private void InitInfo(Character character)
    {
        _characterName.text = character.CharacterName;
        InitColorSprites(character);
        _cachedCharacter = character;
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
