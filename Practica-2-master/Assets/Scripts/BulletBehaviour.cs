using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    //Velocidad de la bala
    public float speed;

    //Distancia máxima que puede recorrer la bala
    float distance = 1.0f;
    //Distancia que a recorrido actualmente
    float actualDistance = 0.0f;
    //Dirección de la bala
    Vector3 direction;

    //Función para ponerle dirección a la bala
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        //Conseguimos la nueva posición de la bala cada frame
        transform.position += speed * direction;

        //Calculamos la distancia actual y si es mayor que la máxima destruimos la bala
        actualDistance += 0.01f;
        if (actualDistance > distance) Destroy(gameObject);
    }
    //Función para gestionar las colisiones de las balas
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != tag)
        {
            //Si la bala es disparada por el jugador y choca con una torreta esta será destruida y se imprimirá un mensaje
            if (other.tag == "Turret")
            {
                print($"Destruida unidad {other.name}");
                other.gameObject.SetActive(false);
            }
            //Si la bala es disparada por una torreta y choca con el jugador llamaremos a la función hit del jugador
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerBehaviour>().hit(gameObject);
            }
            //Destruimos la bala
            Destroy(gameObject);
        }
    }
}
