public class Bleed : Debuff
{ 
    private int _givenDamage;

    public Bleed(Character host, int givenDamage) : base(host)
    {
        _host = host;
        _givenDamage = givenDamage;
        Subscribe();
    }

    protected override void Subscribe()
    {
        AddModifierToHost();
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
