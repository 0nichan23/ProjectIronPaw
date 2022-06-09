using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterHighlightCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _passiveDesscription;
    [SerializeField] private TextMeshProUGUI _ultimateDesscription;
    [SerializeField] private TextMeshProUGUI _strengthText;
    [SerializeField] private TextMeshProUGUI _intelligenceText;
    [SerializeField] private TextMeshProUGUI _dexterityText;
    [SerializeField] private TextMeshProUGUI _faithText;

    [SerializeField] private Character _charTest;
    public void InitInfo(Character character)
    {
        _passiveDesscription.text = character.PassiveDescription;
        _ultimateDesscription.text = character.UltimateDescription;

        _strengthText.text = character.Stats.Strength.ToString();
        _intelligenceText.text = character.Stats.Intelligence.ToString();
        _dexterityText.text = character.Stats.Dexterity.ToString();
        _faithText.text = character.Stats.Faith.ToString();
    }
}
