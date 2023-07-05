using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Controller
{

    public Hand Hand;
    public Deck Deck;
    public DiscardPile DiscardPile;
    public ExiledPile ExiledPile;

    [SerializeField] private TextMeshProUGUI _numberOfCardsInDiscardPile;
    [SerializeField] private TextMeshProUGUI _numberOfCardsInDrawPile;
    public Button UltimateButton;

    public float UltimateCharge;
    public float MaximumUltimateCharge = 10;
    public int MaxEnergy;
    private int _currentEnergy;
    public int CurrentEnergy
    {
        get => _currentEnergy;
        set
        {
            _currentEnergy = value;
            UpdatePlayerUI();
        }
    }

    public bool UltimateReady 
    { 
        get
        {
            return UltimateCharge == MaximumUltimateCharge;
        }
    }


    [SerializeField]
    TextMeshProUGUI EnergyText;

    [SerializeField] private List<Transform> _heroesPositions = new List<Transform>();

    public List<Transform> HeroesPositions { get => _heroesPositions; set => _heroesPositions = value; }
    





    private void Awake()
    {
        //FillPlayerControllerHeroes();

        OnStartTurn += BasicStartOfTurnTasks;
        OnEndTurn += BasicEndOfTurnTasks;

        TurnOnUltButtonOnSufficientUltCharge();

        UIManager.Instance.HUDCanvas.UltButton.FillUltimateChargeUI(UltimateCharge / MaximumUltimateCharge);
    }

    public void FillPlayerControllerHeroes()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                if(transform.GetChild(i).GetComponentInChildren<Hero>() != null)
                {
                    ControllerChracters.Add(transform.GetChild(i).GetComponentInChildren<Hero>());
                }                
            }
        }
    }


    private void BasicStartOfTurnTasks()
    {
        StartOfTurnDraw();
        StartOfTurnEnergyRegen();
        UpdatePlayerUI();
    }

    private void StartOfTurnDraw()
    {
        for (int i = 0; i < Hand.DrawAmount; i++)
        {
            Deck.Draw();
        }
    }

    private void StartOfTurnEnergyRegen()
    {
        CurrentEnergy = MaxEnergy;
    }

    private void BasicEndOfTurnTasks()
    {
        Hand.ClearHand();
    }

    public void GainUltimateCharge(int amountToGain)
    {
        if (UltimateCharge + amountToGain >= MaximumUltimateCharge)
        {
            UltimateCharge = MaximumUltimateCharge;
        }
        else
        {
            UltimateCharge += amountToGain;
        }

        UIManager.Instance.HUDCanvas.UltButton.FillUltimateChargeUI(UltimateCharge / MaximumUltimateCharge);
    }

    

    public void ResetUltimateCharge()
    {
        UltimateCharge = 0;
        UIManager.Instance.HUDCanvas.UltButton.FillUltimateChargeUI(UltimateCharge / MaximumUltimateCharge);
    }

    private void TurnOnUltButtonOnSufficientUltCharge()
    {
        if (UltimateCharge == MaximumUltimateCharge)
        {
            // TODO: Animation
        }
    }


    

    public void UpdatePlayerUI()
    {
        UpdateEnergyUI();
        _numberOfCardsInDiscardPile.text = DiscardPile.Cards.Count.ToString();
        _numberOfCardsInDrawPile.text = Deck.Cards.Count.ToString();
    }

    private void UpdateEnergyUI()
    {
        EnergyText.text = CurrentEnergy.ToString() + "/" + MaxEnergy.ToString();
        UIManager.Instance.DetermineTextColorBasedOnRule(EnergyText, CurrentEnergy > 0, Color.white, Color.red);
    }


}
