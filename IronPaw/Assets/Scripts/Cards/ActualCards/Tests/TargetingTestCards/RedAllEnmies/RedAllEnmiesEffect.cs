using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/RedAllEnmiesEffect")]
public class RedAllEnmiesEffect : CardEffect
{


    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(3, playingCharacter));
    }
}
