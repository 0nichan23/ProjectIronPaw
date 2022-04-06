using UnityEngine;
[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/EnemyTestEffect")]
public class EnemyTestEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Debug.Log("yes");
    }
}
