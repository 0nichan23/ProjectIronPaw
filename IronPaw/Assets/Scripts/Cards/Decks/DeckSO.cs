using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "Decks/DeckSO")]
public class DeckSO : ScriptableObject
{
    public List<GameObject> Cards;
}
