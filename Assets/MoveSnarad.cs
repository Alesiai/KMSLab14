using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnarad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    public GameObject explosion;
    public float coreSpeed = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward * coreSpeed);
    }
    //public Collision collision;
    //public AudioSource Babah;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "goal" || col.gameObject.tag=="Player")
        {
            GetComponent<Renderer>().enabled = false;
            col.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
            Instantiate(explosion, gameObject.transform);
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
            //Babah.Play();

        }
    }
}
