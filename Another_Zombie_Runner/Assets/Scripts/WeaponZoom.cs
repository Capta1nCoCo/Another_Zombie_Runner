using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] int zoomIn = 20;
    [SerializeField] int zoomOut = 60;

    Camera cameraChild;

    void Start()
    {
        cameraChild = GetComponentInChildren<Camera>();
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
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            cameraChild.fieldOfView = zoomOut;
        }
    }

}
