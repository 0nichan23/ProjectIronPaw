using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroProfile : CharacterProfile
{
    public abstract void SubscribePassive();
    public abstract void UnSubscribePassive();

    public abstract void Ultimate();
}
