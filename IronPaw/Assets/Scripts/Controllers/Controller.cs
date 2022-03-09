using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public List<CharacterTEMP> controllerChracters;
    public DataTracker TurnTracker;
    public DataTracker CombatTracker;
    public DataTracker RunTracker;
}
