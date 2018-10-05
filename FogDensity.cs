using UnityEngine;
using System.Collections;

public class FogDensity : MonoBehaviour
{

    public float fogDensity;
    float previousFogDensity;

    void OnPreRender()
    {
        previousFogDensity = RenderSettings.fogDensity;
        RenderSettings.fogDensity = fogDensity;
    }

    void OnPostRender()
    {
        RenderSettings.fogDensity = previousFogDensity;
    }
}