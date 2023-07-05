using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : Singleton<MissionManager>
{
    public List<CharacterSO> HeroesToLoad;

    void Start()
    {
        CreateHeroes();
    }

    public void CreateHeroes()
    {
        CharacterHighlightCanvas characterCanvas = UIManager.Instance.CharacterCanvas.CharacterHighlightCanvas;
        CharacterStatusEffectsInfoScreen characterStatusEffectsCanvas = UIManager.Instance.CharacterCanvas.CharacterStatusEffectsInfoScreen;

        List<Transform> heroesPositions = PlayerWrapper.Instance.PlayerController.HeroesPositions;

        for (int i = 0; i < HeroesToLoad.Count; i++)
        {
            // Instantiate the Actual Hero Prefab
            GameObject instantiatedHero = Instantiate(HeroesToLoad[i].Character, heroesPositions[i]);
            // Making Sure the Hero is the child of the player's controller
            instantiatedHero.transform.parent = PlayerWrapper.Instance.PlayerController.transform;

            // Instantiate the Rotatable Hero Model for the character highlight menu (passive + ult screen)
            Instantiate(HeroesToLoad[i].CharacterModelForCharacterCanvas, characterCanvas.HeroesContainer.transform);

            // Instantiate the Rotatable Hero Model for the character's status effect menu
            Instantiate(HeroesToLoad[i].CharacterModelForCharacterCanvas, characterStatusEffectsCanvas.HeroesContainer.transform);
        }

        SetHeroReferences();

        // Adding Heroes' Decks to player's Deck
        LoadHeroDecks();

    }

    private void LoadHeroDecks()
    {
        Deck playerDeck = PlayerWrapper.Instance.PlayerController.Deck;

        playerDeck.DecksGiven.Clear();

        for (int i = 0; i < HeroesToLoad.Count; i++)
        {
            playerDeck.DecksGiven.Add(HeroesToLoad[i].Deck);
        }

        playerDeck.SetDeckForStartOfGame();
    }

    public void SetHeroReferences()
    {
        PlayerWrapper.Instance.PlayerController.FillPlayerControllerHeroes();
        CombatManager.Instance.SetHeroes();
    }
}
