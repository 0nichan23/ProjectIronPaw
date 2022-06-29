using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    public Camera _mainCamera;
    public CameraShake CameraShake;


    [SerializeField] private GameObject HitParticle;
    [SerializeField] private GameObject HealingParticle;
    [SerializeField] private GameObject DeathParticle;
    [SerializeField] private GameObject HealingPopup;
    [SerializeField] private GameObject DamagePopup;

    

    void Start()
    {
        CameraShake = _mainCamera.GetComponent<CameraShake>();
    }


    public void CreateDamagePopup(Vector3 pos, int amount)
    {
        pos = new Vector3(pos.x, pos.y + 1, pos.z - 4);
        DamagePopup popup = Instantiate(DamagePopup, pos, Quaternion.identity).GetComponentInChildren<DamagePopup>();
        popup.Setup(amount);
    }

    public void CreateHealingPopup(Vector3 pos, int amount)
    {
        pos = new Vector3(pos.x, pos.y + 1, pos.z - 4);
        DamagePopup popup = Instantiate(HealingPopup, pos, Quaternion.identity).GetComponentInChildren<DamagePopup>();
        popup.Setup(amount);
    }


    public void CreateHitParticle(Vector3 pos)
    {
        pos = new Vector3(pos.x, pos.y + 1, pos.z);
        GameObject Particle = Instantiate(HitParticle, pos, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(Particle, 2f);
    }

    public void CreateDeathParticle(Vector3 pos)
    {
        pos = new Vector3(pos.x, pos.y + 1, pos.z);
        GameObject Particle = Instantiate(DeathParticle, pos, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(Particle, 2f);
    }

    public void CreateHealingParticle(Vector3 pos)
    {
        pos = new Vector3(pos.x, pos.y, pos.z);
        GameObject Particle = Instantiate(HealingParticle, pos, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(Particle, 2f);
    }



}
