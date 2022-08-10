using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusEffectsViewer : CustomButton
{
    [SerializeField] private Character _character;

    protected override void LongPress()
    {
        UIManager.Instance.CharacterCanvas.ShowCharacterCanvas(_character, false);
        UIManager.Instance.ToggleCanvases(false);
    }
}
