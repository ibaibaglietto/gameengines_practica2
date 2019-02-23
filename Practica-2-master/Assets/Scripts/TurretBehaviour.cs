using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    //Cañón de la torreta
    public Transform cannon;
    //Jugador
    public Transform player;
    //Bala
    public GameObject bullet;
    //Rango maximo en el que el jugador es detectado
    public float shootRange;
    //Frecuencia de disparo
    public float shootFrequency;

    //Último disparo realizado
    float lastShot;


    // Update is called once per frame
    void Update()
    {
        //Comparamos la distancia entre la torreta y el jugador
        float distPlayer = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2));
        //Si la distancia es menor al rango el cañón mira al jugador y dispara
        if (distPlayer < shootRange)
        {
            cannon.LookAt(player);
            if(lastShot >= shootFrequency) shot();
        }
        lastShot += 0.01f;

        
    }
    //Función para gestionar el disparo de la torreta
    void shot()
    {
        //Actualizamos el tiempo del último disparo
        lastShot = 0.0f;
        //Ponemos la posición y el tag correspondiente a la bala y la instanciamos
        bullet.transform.position = transform.position;
        bullet.tag = tag;
        Instantiate(bullet).GetComponent<BulletBehaviour>().setDirection(cannon.forward);

    }
}
