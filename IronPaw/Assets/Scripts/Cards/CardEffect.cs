using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{
    public TargetType TargetType;
    public Character[] Targets;

    public abstract void Activate();

    public abstract void PickTargets();
}
