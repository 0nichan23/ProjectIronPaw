using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventInvoker : MonoBehaviour
{
    [SerializeField] private Character _character;

    void Start()
    {
        _character = GetComponentInChildren<Character>();
    }

    public void OnAttackDealDmg()
    {
        _character.ReachedAnimationSyncFrame = true;
    }

    public void OnAttackAnimationFinished()
    {
        if (_character is Enemy)
        {
            ((EnemyController)_character.Controller).CurrentEnemyDonePlaying = true;
        }
    }
    public void DoneDying()
    {
        _character.DoneDying = true;
    }
}
