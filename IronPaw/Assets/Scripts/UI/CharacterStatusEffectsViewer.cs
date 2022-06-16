using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusEffectsViewer : CustomButton
{
    [SerializeField] private Character _character;

    private void Start()
    {
        _character = GetComponentInParent<Character>();
    }
    protected override void LongPress()
    {
        UIManager.Instance.CharacterCanvas.ToggleScreens(_character, false);
        UIManager.Instance.ToggleCanvases(false);
    }
}
