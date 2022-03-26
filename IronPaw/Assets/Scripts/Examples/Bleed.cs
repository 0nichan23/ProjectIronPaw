public class Bleed
{

    int _bleedDamage;

    public Character Host;


    public Bleed(Character givenHost, int amount)
    {
        Host = givenHost;
        _bleedDamage = amount;
        Subscibre();
    }


    private void Subscibre()
    {
        Host.OnStartTurn += Bleeding;
    }
    private void UnSubscibre()
    {
        Host.OnStartTurn -= Bleeding;
    }


    public void Bleeding()
    {
        Host.TakeDmg(_bleedDamage);
        _bleedDamage--;
        if (_bleedDamage <= 0)
        {
            UnSubscibre();
        }

    }


}
