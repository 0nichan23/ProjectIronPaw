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

    public void OnAnimationEvent()
    {
        _character.ReachedAnimationSyncFrame = true;
    }
}
