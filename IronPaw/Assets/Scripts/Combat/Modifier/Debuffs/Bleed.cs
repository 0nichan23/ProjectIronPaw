public class Bleed : Debuff
{ 
    
    public Bleed(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.Bleed;
        CustomConstructor(host, numberOfTurns);
    }

    protected override void Subscribe()
    {
        _host.OnStartTurn += Bleeding;
    }

    protected override void UnSubscribe()
    {
        _host.OnStartTurn -= Bleeding;
    }
    public void Bleeding()
    {
        _host.TakeDmg(new Damage(TurnCounter, _host, false));
        TurnCounter--;
        if (TurnCounter <= 0)
        {
            RemoveStatusEffectFromHost();
        }
    }


}
