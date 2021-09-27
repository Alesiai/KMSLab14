using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Camera cam1;
    // Start is called before the first frame update
    void Start()
    {
        cam1 = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //откуда луч
        Vector3 point = new Vector3(cam1.pixelWidth / 2, cam1.pixelHeight * 0.4f, 0);
        //луч
        Ray ray = cam1.ScreenPointToRay(point);
        RaycastHit hit;

        //направляет луч через raycast б hit - броосает луч
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            RUN target1 = hitObject.GetComponent<RUN>();

            if (target1 != null)
            {
                //луч направляется и вызывает ReactToHit() 
                target1.ReactToHit();
            }
        }

    }
}