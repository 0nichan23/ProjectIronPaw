using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Controller
{

    public Hand Hand;
    public Deck Deck;
    public DiscardPile DiscardPile;
    public ExiledPile ExiledPile;

    public Button UltimateButton;

    public float UltimateCharge;
    public float MaximumUltimateCharge = 10;
    public int MaxEnergy;
    public int CurrentEnergy;

    [SerializeField]
    TextMeshProUGUI ManaText;

    [SerializeField]
    CardCloseUp CardCloseUpField;

    [SerializeField] private GameObject _darkFilter;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            ControllerChracters.Add(transform.GetChild(i).GetComponentInChildren<Hero>());
        }

        OnStartTurn += BasicStartOfTurnTasks;
        OnEndTurn += BasicEndOfTurnTasks;

        ToggleUltButton(false);
        TurnOnUltButtonOnSufficientUltCharge();
    }


    private void BasicStartOfTurnTasks()
    {
        StartOfTurnDraw();
        StartOfTurnEnergyRegen();
        UpdateEnergyUi();
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
        Hand.DiscardHand();
    }

    public void GainUltimateCharge(int amountToGain)
    {
        if (UltimateCharge + amountToGain >= MaximumUltimateCharge)
        {
            UltimateCharge = MaximumUltimateCharge;
            ToggleUltButton(true);
        }
        else
        {
            UltimateCharge += amountToGain;
        }
    }

    public void ResetUltimateCharge()
    {
        UltimateCharge = 0;
        ToggleUltButton(false);
    }

    private void ToggleUltButton(bool state)
    {
        UltimateButton.gameObject.SetActive(state);
    }

    private void TurnOnUltButtonOnSufficientUltCharge()
    {
        if (UltimateCharge == MaximumUltimateCharge)
        {
            ToggleUltButton(true);
        }
    }


    public void ToggleCardCloseUpPanel(CardScriptableObject givenCard, bool panelState, CardUI self)
    {
        CardCloseUpField.gameObject.SetActive(panelState);
        _darkFilter.SetActive(panelState);
        if (CardCloseUpField.gameObject.activeSelf)
        {   
            CardCloseUpField.InitializeDisplay(givenCard, self);
        }
    }

    public void UpdateEnergyUi()
    {
        ManaText.text = CurrentEnergy.ToString() + "/" + MaxEnergy.ToString();
    }


}
