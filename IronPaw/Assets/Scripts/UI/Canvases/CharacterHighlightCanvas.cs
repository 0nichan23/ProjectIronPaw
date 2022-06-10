using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterHighlightCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private TextMeshProUGUI _passiveDesscription;
    [SerializeField] private TextMeshProUGUI _ultimateDesscription;
    [SerializeField] private TextMeshProUGUI _strengthText;
    [SerializeField] private TextMeshProUGUI _intelligenceText;
    [SerializeField] private TextMeshProUGUI _dexterityText;
    [SerializeField] private TextMeshProUGUI _faithText;

    [SerializeField] private List<GameObject> _characterModels;
    public void InitInfo(Character character)
    {
        _characterName.text = character.CharacterName;
        _passiveDesscription.text = character.PassiveDescription;
        _ultimateDesscription.text = character.UltimateDescription;

        _strengthText.text = character.Stats.Strength.ToString();
        _intelligenceText.text = character.Stats.Intelligence.ToString();
        _dexterityText.text = character.Stats.Dexterity.ToString();
        _faithText.text = character.Stats.Faith.ToString();

        TurnOnModel(character);
    }

    private void TurnOnModel(Character givenCharacter)
    {
        int index = 0;
        List<Character> pointerList = null;

        if(givenCharacter is Hero)
        {
            pointerList = PartyManager.Instance.Heroes;
        }
        else if (givenCharacter is Enemy)
        {
            pointerList = PartyManager.Instance.Enemies;
        }

        for (int i = 0; i < pointerList.Count; i++)
        {
            if (pointerList[i] == givenCharacter)
            {
                _characterModels[i].SetActive(true);
            }
            else
            {
                _characterModels[i].SetActive(false);
            }
        }
    }
}
