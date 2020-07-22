using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] int zoomIn = 20;
    [SerializeField] int zoomOut = 60;
    [SerializeField] float zoomInSens = 0.5f;
    [SerializeField] float zoomOutSens = 2f;

    Camera cameraChild;
    FirstPersonController fpc;

    void Start()
    {
        cameraChild = GetComponentInParent<Camera>();
        fpc = GetComponentInParent<FirstPersonController>();
    }

    void Update()
    {
        ZoomInOut();
    }

    public void ZoomInOut()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            cameraChild.fieldOfView = zoomIn;
            fpc.ChangeMouseSensitivity(zoomInSens, zoomInSens);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            cameraChild.fieldOfView = zoomOut;
            fpc.ChangeMouseSensitivity(zoomOutSens, zoomOutSens);
        }
    }

}
