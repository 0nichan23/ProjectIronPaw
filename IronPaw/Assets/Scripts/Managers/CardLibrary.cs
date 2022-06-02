using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLibrary : Singleton<CardLibrary>
{
    public List<CardScriptableObject> AllCards = new List<CardScriptableObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (CardScriptableObject cardSO in AllCards)
        {
            cardSO.ClearTargetsFromCardEffect();
        }
    }
}
