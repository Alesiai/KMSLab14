using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    Transform corpus;
    Transform bashnya;
    Transform stvol;
    public float TankMoveSpeed = 0.06f;
    public AudioSource zvtank;
    float RotateSpeed = 1f;
    float min = 350f;
    float max = 359f;
    Rigidbody rigidbody;
    bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        corpus = gameObject.transform.Find("танк");
        bashnya = gameObject.transform.Find("Box002");
        stvol = bashnya.transform.Find("trunk");
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // W  and S
        float z = Input.GetAxis("Vertical"); // w s 
        //взгляд всегда прямо вперед
        transform.position += transform.TransformDirection(Vector3.forward * TankMoveSpeed * z);

        float x = Input.GetAxis("Horizontal");    //  A и D

        // поворот башни по  Y
        //угол поворота, минимальный и максимальный
        transform.localEulerAngles += new Vector3(0, x * 0.5f, 0);


        //////////////////////////////////////////////////
        float h = Input.GetAxis("Mouse X");

        bashnya.Rotate(0f, h * RotateSpeed, 0f);


        float v = Input.GetAxis("Mouse Y");
        if (v != 0)
        {
            //угол поворота, минимальный и максимальный
            float stvol_angle =
            Mathf.Clamp(stvol.transform.localEulerAngles.x, min, max);

            stvol.localEulerAngles = new Vector3(stvol_angle, 0f, 0f);

            stvol.transform.Rotate(-v * RotateSpeed, 0f, 0f);
        }
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !isPlaying)
        { zvtank.Play(); isPlaying = true; }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && isPlaying)
        { zvtank.Stop(); isPlaying = false; }

    }
    float h;
    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, h, 300, 300));
        GUI.Box(new Rect(10, 0, 250, 200), "Панель управления");
        GUI.Label(new Rect(15, 30, 200, 30), "Скорость танка " + TankMoveSpeed + " ");
        TankMoveSpeed = GUI.HorizontalSlider(new Rect(15, 50, 170, 30), TankMoveSpeed, 0.0f, 1.0f);
        GUI.Label(new Rect(15, 60, 200, 30), "Скорость поворота башни " + RotateSpeed + " ");
        RotateSpeed = GUI.HorizontalSlider(new Rect(15, 100, 200, 30), RotateSpeed, 0.0f, 1.0f);
        if (GUI.Button(new Rect(10, 170, 90, 20), "Скрыть ПУ"))
        {
            Hide();
        }
        if (GUI.Button(new Rect(100, 170, 90, 20), "Показать ПУ"))
        {
            Show();
        }
        GUI.EndGroup();
    }
    public void Hide()
    {
        h = -170;
    }
    public void Show()
    {
        h = 0;
    }
}
