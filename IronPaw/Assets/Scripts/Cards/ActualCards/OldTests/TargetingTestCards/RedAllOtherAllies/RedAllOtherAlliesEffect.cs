using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Guard/RedAllOtherAlliesEffect")]
public class RedAllOtherAlliesEffect : CardEffect
{

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.GainBlock(5);
    }
}
