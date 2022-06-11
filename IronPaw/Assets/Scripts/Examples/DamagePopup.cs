using TMPro;
using UnityEngine;
public class DamagePopup : MonoBehaviour
{
    TextMeshPro textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        Destroy(transform.parent.gameObject, 1);
    }

    public void Setup(int amount)
    {
        textMesh.SetText(amount.ToString());
    }

    

}
