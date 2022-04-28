using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTracker
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

    public int NumberOfCardsDrawn { get => _numberOfCardsDrawn; set => _numberOfCardsDrawn = value; }
    public int NumberOfCardsExiled { get => _numberOfCardsExiled; set => _numberOfCardsExiled = value; }
    public int NumberOfCardsDiscarded { get => _numberOfCardsDiscarded; set => _numberOfCardsDiscarded = value; }
    public int NumberOfCardsPlayed { get => _numberOfCardsPlayed; set => _numberOfCardsPlayed = value; }
    public int NumberOfAttacksPlayed { get => _numberOfAttacksPlayed; set => _numberOfAttacksPlayed = value; }
    public int NumberOfGuardsPlayed { get => _numberOfGuardsPlayed; set => _numberOfGuardsPlayed = value; }
    public int NumberOfUtilitiesPlayed { get => _numberOfUtilitiesPlayed; set => _numberOfUtilitiesPlayed = value; }
    public int NumberOfBuffsApplied { get => _numberOfBuffsApplied; set => _numberOfBuffsApplied = value; }
    public int NumberOfUltimatesPerformed { get => _numberOfUltimatesPerformed; set => _numberOfUltimatesPerformed = value; }
    public int NumberOfTurnsSinceStart { get => _numberOfTurnsSinceStart; set => _numberOfTurnsSinceStart = value; }

    public void ResetData()
    {
        NumberOfCardsDrawn = 0;
        NumberOfCardsExiled = 0;
        NumberOfCardsDiscarded = 0;
        NumberOfCardsPlayed = 0;
        NumberOfAttacksPlayed = 0;
        NumberOfGuardsPlayed = 0;
        NumberOfUtilitiesPlayed = 0;
        NumberOfBuffsApplied = 0;
        NumberOfUltimatesPerformed = 0;
        NumberOfTurnsSinceStart = 0;

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
