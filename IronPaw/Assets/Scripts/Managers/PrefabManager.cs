using UnityEngine;

public class PrefabManager : Singleton<PrefabManager>
{
    public GameObject PlainCardDispaly;
    public GameObject DamagePopup;

    public GameObject EffectSlot;
    Sprite BleedIcon;

    public Sprite GetSprite(Modifier mod)
    {
        return BleedIcon;
    }
}
