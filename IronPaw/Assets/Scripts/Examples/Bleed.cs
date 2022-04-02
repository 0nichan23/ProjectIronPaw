public class Bleed
{

    int _bleedDamage;

    public Character Host;

    private Damage _givenDamage;



    public Bleed(Character givenHost, Damage givenDamage)
    {
        Host = givenHost;
        _givenDamage = givenDamage;
        Subscribe();
    }


    private void Subscribe()
    {
        Host.OnStartTurn += Bleeding;
    }
    private void UnSubscribe()
    {
        Host.OnStartTurn -= Bleeding;
    }


    public void Bleeding()
    {
        Host.TakeDmg(_givenDamage);
        _givenDamage.GivenDamage--;
        if (_givenDamage.GivenDamage <= 0)
        {
            UnSubscribe();
        }

    }


}
