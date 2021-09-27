using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject a;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "танк1")
        {
            a.transform.Rotate(Vector3.up * 2);
        }
    }
}
