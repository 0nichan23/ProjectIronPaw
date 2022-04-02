using TMPro;
using UnityEngine;
public class DamagePopup : MonoBehaviour
{
    TextMeshPro textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        Invoke("Delete", 1f);
    }
    public static DamagePopup Create(Vector3 pos, int amount)
    {
        GameObject dmgPopupObject = Instantiate(PrefabManager.Instance.DamagePopup, pos, Quaternion.identity);
        DamagePopup damagePopup = dmgPopupObject.GetComponent<DamagePopup>();
        damagePopup.Setup(amount);
        return damagePopup;
    }

    public void Setup(int amount)
    {
        textMesh.SetText(amount.ToString());
    }

    void Delete()
    {
        Destroy(gameObject);
    }

}
