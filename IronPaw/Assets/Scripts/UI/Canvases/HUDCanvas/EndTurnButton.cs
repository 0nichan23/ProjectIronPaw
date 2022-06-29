using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    public void OnOutOfActions()
    {
        _animator.SetTrigger("OutOfActions");
    }
}
