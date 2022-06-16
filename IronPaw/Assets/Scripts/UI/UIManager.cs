using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public Camera MainCamera;

    [SerializeField] public Canvas HUDCanvas;
    [SerializeField] public CardZoomCanvas CardZoomCanvas;
    [SerializeField] public SelectionCanvas SelectionCanvas;
    [SerializeField] public CharacterCanvas CharacterCanvas;
    [SerializeField] public TextMeshProUGUI _fpsCounter;
    public void ToggleHUDCanvas(bool state)
    {
        HUDCanvas.gameObject.SetActive(state);
    }

    public void ToggleCharacterHighlightCanvas(bool state)
    {
        CharacterCanvas.gameObject.SetActive(state);
    }

    public void ToggleSelectionCanvas(bool state, string titleText)
    {
        SelectionCanvas.gameObject.SetActive(state);
        SelectionCanvas.Title.text = titleText;
    }

    public void ToggleCanvases(bool state)
    {
        ToggleHUDCanvas(state);
        ToggleCharacterHighlightCanvas(!state);
    }

    public void ToggleCardZoomCanvas(CardScriptableObject givenCard, bool state, CardUI self)
    {
        CardZoomCanvas.gameObject.SetActive(state);
        if (state)
        {
            CardZoomCanvas.CardCloseUp.InitializeDisplay(givenCard, self);
        }
    }

    public void UpdateFPSCounter(int fps)
    {
        _fpsCounter.text = fps.ToString() + " FPS";
    }
}
