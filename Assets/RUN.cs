using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUN : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReactToHit()
    {
        this.transform.Translate(-1, 0, 1);
    }
}
