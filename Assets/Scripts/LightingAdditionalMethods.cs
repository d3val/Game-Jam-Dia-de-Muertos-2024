using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightingAdditionalMethods : MonoBehaviour
{
    [SerializeField] List<Color> lightingColors;
    Light2D light2D;

    private void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    public void ChangeLightColor(int colorIndex)
    {
        light2D.color = lightingColors[colorIndex];
    }

    public void ChangeLightColor(Color newColor)
    {
        light2D.color = newColor;
    }
}
