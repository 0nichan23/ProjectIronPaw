using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public Canvas HUDCanvas;
    [SerializeField] public CharacterHighlightCanvas CharacterHighlightCanvas;

    public void ToggleHUDCanvas(bool state)
    {
        HUDCanvas.gameObject.SetActive(state);
    }

    public void ToggleCharacterHighlightCanvas(bool state)
    {
        CharacterHighlightCanvas.gameObject.SetActive(state);
    }

    public void ToggleCanvasas(bool state)
    {
        ToggleHUDCanvas(state);
        ToggleCharacterHighlightCanvas(!state);
    }
}
