using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    float frameCount = 0f;
    float dt = 0f;
    float fps = 0f;
    float updateRate = 4f;  // 4 updates per sec.

    public float FPS { get => fps;}

    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1f / updateRate;

            UIManager.Instance.UpdateFPSCounter((int)fps);
        }
    }
}
