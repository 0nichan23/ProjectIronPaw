using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public GameObject Character;
    public GameObject CharacterModelForCharacterCanvas;
    public DeckSO Deck;
}
