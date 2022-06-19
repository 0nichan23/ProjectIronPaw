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

    





    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                ControllerChracters.Add(transform.GetChild(i).GetComponentInChildren<Hero>());
            }
        }

        OnStartTurn += BasicStartOfTurnTasks;
        OnEndTurn += BasicEndOfTurnTasks;

        TurnOnUltButtonOnSufficientUltCharge();

        UIManager.Instance.HUDCanvas.UltButton.FillUltimateChargeUI(UltimateCharge / MaximumUltimateCharge);
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
        EnergyText.text = CurrentEnergy.ToString() + "/" + MaxEnergy.ToString();
        _numberOfCardsInDiscardPile.text = DiscardPile.Cards.Count.ToString();
        _numberOfCardsInDrawPile.text = Deck.Cards.Count.ToString();
    }


}
