using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public float UltimateMeter;
    public Hand Hand;
    public Deck Deck;
    public DiscardPile DiscardPile;
    public ExiledPile ExiledPile;
    public int MaxEnergy;
    public int CurrentEnergy;

    private void Start()
    {
        CurrentEnergy = MaxEnergy;
    }

}
