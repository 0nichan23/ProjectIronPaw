using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/RedSingleEnemyEffect")]
public class RedSingleEnemyEffect : CardEffect
{

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {


        Debug.Log(target.CurrentHP);
        target.TakeDmg(new Damage(10, playingCharacter));
        Debug.Log(target.CurrentHP);
    }
}
