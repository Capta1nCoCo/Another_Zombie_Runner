using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    
    public void DisplayDamageCanvas()
    {
        StartCoroutine(ProcessDisplayDamage());
    }

    IEnumerator ProcessDisplayDamage()
    {
        enabled = true;
        yield return new WaitForSeconds(.3f);
        enabled = false;
    }
}
