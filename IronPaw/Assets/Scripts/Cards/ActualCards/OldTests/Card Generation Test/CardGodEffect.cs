using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/GreenCards/Utility/CardGodEffect")]
public class CardGodEffect : CardEffect
{
    [SerializeField] private CardScriptableObject cardToCreate;

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        cardToCreate.GenerateCard(playingCharacter);
    }
}
