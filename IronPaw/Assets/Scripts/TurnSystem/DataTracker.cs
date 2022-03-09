using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DataTracker
{
    private int _numberOfCardsDrawn;
    private int _numberOfCardsExiled;
    private int _numberOfCardsDiscarded;
    private int _numberOfCardsPlayed;   
    private int _numberOfAttacksPlayed;
    private int _numberOfGuardsPlayed;
    private int _numberOfUtilitiesPlayed;
    private int _numberOfBuffsApplied;
    private int _numberOfUltimatesPerformed;
    private int _numberOfTurnsSinceStart;
    private Dictionary<Character, int> _enemiesSlain;
    private Dictionary<Character, int> _damageTaken;

    public void ResetData()
    {
        _numberOfCardsDrawn = 0;
        _numberOfCardsExiled = 0;
        _numberOfCardsDiscarded = 0;
        _numberOfCardsPlayed = 0;
        _numberOfAttacksPlayed = 0;
        _numberOfGuardsPlayed = 0;
        _numberOfUtilitiesPlayed = 0;
        _numberOfBuffsApplied = 0;
        _numberOfUltimatesPerformed = 0;
        _numberOfTurnsSinceStart = 0;

        foreach (var key in _enemiesSlain.Keys)
        {
            _enemiesSlain[key] = 0;
        }

        foreach (var key in _damageTaken.Keys)
        {
            _damageTaken[key] = 0;
        }
    }


}
