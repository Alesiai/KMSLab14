using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivPav : MonoBehaviour
{
   
    public GameObject prefub;
   
    void Start()
    {
      

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
            Vector3 forwardofstvol = transform.position +
            transform.TransformDirection(Vector3.forward * 7.5f);
            Instantiate(prefub, forwardofstvol, transform.rotation); 
        }
    }
}
