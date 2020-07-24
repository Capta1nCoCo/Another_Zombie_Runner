using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }
    
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle > minAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }        
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
