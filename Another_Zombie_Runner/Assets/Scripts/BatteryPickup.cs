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
        flashlightSystem = FindObjectOfType<FlashlightSystem>();
        flashlightSystem.RestoreLightAngle(restoreAngle);
        flashlightSystem.RestoreLightIntensity(intensityAmount);
        Destroy(gameObject);
    }
}
