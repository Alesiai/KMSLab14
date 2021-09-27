using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1 : MonoBehaviour
{
    public Light a;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "танк1")
        {
            a.intensity = 100;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "танк1")
        {
            a.intensity = 0;
        }
    }
}
