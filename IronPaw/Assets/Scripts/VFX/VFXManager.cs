using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    public Camera _mainCamera;
    public CameraShake CameraShake;

    void Start()
    {
        CameraShake = _mainCamera.GetComponent<CameraShake>();
    }


}
