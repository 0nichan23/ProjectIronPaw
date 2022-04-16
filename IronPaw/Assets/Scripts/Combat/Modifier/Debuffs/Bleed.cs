public class Bleed : Debuff
{ 
    private int _givenDamage;


    
    public Bleed(Character host, int givenDamage) : base(host)
    {
        ModType = ModifierType.Bleed;
        _host = host;
        _givenDamage = givenDamage;
        InitializeStatusEffect();
    }

    protected override void Subscribe()
    {
        _host.OnStartTurn += Bleeding;
    }

    protected override void UnSubscribe()
    {
        RemoveModifierFromHost();
        _host.OnStartTurn -= Bleeding;
    }
    public void Bleeding()
    {
        _host.TakeDmg(new Damage(_givenDamage, _host, false));
        _givenDamage--;
        if (_givenDamage <= 0)
        {
            UnSubscribe();
        }
    }


}
