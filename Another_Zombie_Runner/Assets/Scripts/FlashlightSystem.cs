using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 1f;
    [SerializeField] float angleDecay = 3f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }


    void Update()
    {
        while (myLight.intensity != 0)
        {
            var waitForSeconds = new WaitForSeconds(2f);
            DecreaseLightAngle();
            DecreaseLightIntensity();
        }
        
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle > minAngle)
        {
            myLight.spotAngle -= angleDecay;
        }        
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay;
    }
}
