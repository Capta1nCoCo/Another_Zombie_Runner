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

    private void OnDisable()
    {
        ZoomOut();
    }

    void Start()
    {
        cameraChild = GetComponentInParent<Camera>();
        fpc = GetComponentInParent<FirstPersonController>();
    }

    void Update()
    {
        ProcessZoom();
    }

    public void ProcessZoom()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ZoomIn();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        cameraChild.fieldOfView = zoomOut;
        fpc.ChangeMouseSensitivity(zoomOutSens, zoomOutSens);
    }

    private void ZoomIn()
    {
        cameraChild.fieldOfView = zoomIn;
        fpc.ChangeMouseSensitivity(zoomInSens, zoomInSens);
    }
}
