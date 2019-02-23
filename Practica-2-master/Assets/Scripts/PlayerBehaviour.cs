using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Número de vidas del jugador
    int lifes = 3;
    //Número de bases descubiertas
    int bases = 0;
    
    //Aceleración líneal del jugador
    public float aceleration;
    //Aceleración angular del jugador
    public float rotationAceletarion;
    //Bala
    public GameObject bullet;
    //Frecuencia de disparo
    public float shootFrequency;

    //Último disparo realizado, se inicializa a 1 para poder disparar nada más empezar a jugar
    float lastShot = 1.0f;
    
    public void shot()
    {
        //Actualizamos el tiempo del último disparo
        lastShot = 0.0f;
        //Ponemos la posición y el tag correspondiente a la bala y la instanciamos
        bullet.transform.position = transform.position;
        bullet.tag = tag;
        Instantiate(bullet).GetComponent<BulletBehaviour>().setDirection(transform.forward);

    }
    //Función para gestionar el encuentro de bases nuevas
    public void baseFounded()
    {
        //Actualizamos el número de bases encontradas
        bases += 1;
        //Recargamos las vidas del jugador
        lifes = 3;
        //Si el número de bases es 4 termina el juego
        if(bases ==4) print("¡Fin del juego!");
    }
    //Función para gestionar el momento en el que el jugador es alcanzado por una bala enemiga
    public void hit(GameObject other)
    {
        //Conseguimos el rigidbody del jugador
        Rigidbody rb = GetComponent<Rigidbody>();
        //Restamos una vida
        lifes -= 1;
        //Si el número de vidas es igual a cero desactivamos al jugador
        if (lifes == 0)
        {
            gameObject.SetActive(false);
        }
        //Si no le aplicamos una fuerza explosiva al jugador
        else
        {
            print("Player: Daño recibido");
            rb.AddExplosionForce(100.0f, other.transform.position, 3.5f);
        }
    }


    
    void FixedUpdate()
    {
        //Conseguimos el rigidbody del jugador
        Rigidbody rb = GetComponent<Rigidbody>();
        //Gestionamos el movimiento del jugador mediante las flechas de dirección aplicandole fuerzas según que tecla es pulsada
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.forward * aceleration);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.forward * aceleration);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(0, -rotationAceletarion, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(0, rotationAceletarion, 0);
        }
        //Si pulsamos la barra espaciadora llamaremos a la función de disparar siempre que se cumpla con el requisito de la frecuencia de disparo
        if (Input.GetKey(KeyCode.Space))
        {
            if (lastShot >= shootFrequency) shot();
            lastShot += 0.1f;
        }
        //Al pulsar la tecla R colocaremos al jugador en la posición 0,0 y le quitaremos todas las fuerzas
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
