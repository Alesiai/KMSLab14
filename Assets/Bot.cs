using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{

    float movespeed = 0.5f; // скорость передвижения танка-бота
    float rotspeedtank = 0.5f; // скорость поворота танка-бота
    float rotspeedbash = 0.5f; // скорость поворота башни танка-бота
    float speedcore = 0.1f; // скорость снаряда танка-бота
    public Transform bash; // для управления башней
    public Transform stvol; // для управления стволом
    public GameObject core; // для ссылки на префаб снаряда
    bool canshoot = true; // для определения, может ли танк-бот произвести выстрел
    int life = 6;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            // определяем вектор направления между игроком и ботом
            Vector3 relativePos = other.transform.position - transform.position;
            // по найденному вектору определяем кватернион для поворота башни бота
            Quaternion newrot = Quaternion.LookRotation(relativePos);
            //ПЛАВНО ПОВОРАЧИВАЕМ БАШНЮ ТАНКА-БОТА В СТОРОНУ ТАНКА-ИГРОКА
            bash.rotation = Quaternion.Slerp(bash.rotation, newrot, Time.deltaTime * rotspeedbash);
            //переменная для определения объекта попадания «луча»
            RaycastHit hit;
            //если выпущен луч из башни в направлении относительно нее – вперед
            if (Physics.Raycast(stvol.position, stvol.TransformDirection(Vector3.forward), out hit))
            {
                //если луч попал в коллайдер игрока и можно выстрелить
                if ((hit.transform.tag == "Player") && canshoot)
                {
                    //запускаем короутину для выстрела танка-бота
                    StartCoroutine(botshoot());
                }
            }


            // вычисляем дистанцию бота до игрока
            float distance = Vector3.Distance(other.transform.position, transform.position);
            if (distance < 50)
            {
                //плавно поворачиваем танк-бот в сторону танка-игрока с заданной скоростью
                transform.rotation = Quaternion.Slerp(transform.rotation, newrot, Time.deltaTime * rotspeedtank);
                // плавно двигаем танк-бота в сторону игрока
                if (Physics.Raycast(stvol.position, stvol.TransformDirection(Vector3.forward), out hit))
                {
                    transform.position = Vector3.Lerp(transform.position, other.transform.position, Time.deltaTime * movespeed);
                }
            }


        }
    }
    IEnumerator botshoot()
    {
        canshoot = false;//указываем, что танк-бот стрелять пока не может
                         //определяем координату для положения снаряда танка-бота
        Vector3 forwardofstvol = stvol.transform.position + stvol.transform.TransformDirection(Vector3.forward * 8f);
        //создаем снаряд из префаба снаряда в требуемой координате относительно ствола
        GameObject newcore = Instantiate(core, forwardofstvol, stvol.rotation);
        //ждем 3 секунды (время «перезарядки»)
        yield return new WaitForSeconds(3f);
        //указываем, что танк может сделать выстрел
        canshoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "core")
        {
            life--;
            if (life < 1) Destroy(gameObject);
        }
    }
}