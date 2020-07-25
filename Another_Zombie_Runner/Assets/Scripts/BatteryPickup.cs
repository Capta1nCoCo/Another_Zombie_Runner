using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float intensityAmount = 2f;

    FlashlightSystem flashlightSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flashlightSystem = FindObjectOfType<FlashlightSystem>();
            flashlightSystem.RestoreLightAngle(restoreAngle);
            flashlightSystem.AddLightIntensity(intensityAmount);
            Destroy(gameObject);
        }        
    }
}
