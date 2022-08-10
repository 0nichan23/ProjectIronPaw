using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterModelWrapper : MonoBehaviour
{
    [SerializeField] private Character _character;

    [SerializeField] private Outline _outline;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationEventInvoker _animationEventInvoker;

    private void Start()
    {
        if(!_outline || !_animator || !_animationEventInvoker)
        {
            throw new Exception(_character + "'s model is missing some components!");
        }
    }

}
