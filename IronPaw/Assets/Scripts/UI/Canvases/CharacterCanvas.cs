using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCanvas : MonoBehaviour
{
    [SerializeField] private CharacterStatusEffectsInfoScreen _characterStatusEffectsInfoScreen;
    [SerializeField] private CharacterHighlightCanvas _characterHighlightCanvas;
    
    public void ToggleScreens(Character character, bool state)
    {
        _characterHighlightCanvas.gameObject.SetActive(state);
        _characterHighlightCanvas.InitInfo(character);
        _characterStatusEffectsInfoScreen.gameObject.SetActive(!state);
        _characterStatusEffectsInfoScreen.InitInfo(character);

        if(UIManager.Instance.SelectionCanvas)
        {
            PartyManager.Instance.CancelCard();
        }
    }
}
