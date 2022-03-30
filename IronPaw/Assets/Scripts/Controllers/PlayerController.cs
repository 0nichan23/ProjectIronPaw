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

    private void Awake()
    {  
        for (int i = 0; i < transform.childCount; i++)
        {
            controllerChracters.Add(transform.GetChild(i).GetComponent<Hero>());
        }
    }

}
