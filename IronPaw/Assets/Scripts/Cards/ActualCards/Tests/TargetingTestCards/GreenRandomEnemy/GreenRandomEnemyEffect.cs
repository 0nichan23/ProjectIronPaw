using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/GreenCards/Attacks/GreenRandomEnemyEffect")]
public class GreenRandomEnemyEffect : CardEffect
{


    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Debug.Log(target.CharacterName + " has " + target.CurrentHP + " health ");
        target.TakeDmg(new Damage(6, playingCharacter));
        Debug.Log(target.CharacterName + " has " + target.CurrentHP + " health ");
    }
}
