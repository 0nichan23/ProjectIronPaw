using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/GreenCards/Utility/GreenRandomAllyEffect")]
public class GreenRandomAllyEffect : CardEffect
{


    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Debug.Log(target.CharacterName + " has " + target.CurrentHP + " health ");
        target.GainBlock(3);
        Debug.Log(target.CharacterName + " has " + target.CurrentHP + " health ");
    }
}
