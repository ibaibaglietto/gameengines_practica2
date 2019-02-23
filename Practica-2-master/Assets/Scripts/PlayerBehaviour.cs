using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    int lifes = 3;
    int bases = 0;
    

    public float aceleration;
    public float rotationAceletarion;
    public GameObject bullet;
    public float shootFrequency;

    float lastShot = 1.0f;
    
    public void shot()
    {
        lastShot = 0.0f;
        bullet.transform.position = transform.position;
        bullet.tag = tag;
        Instantiate(bullet).GetComponent<BulletBehaviour>().setDirection(transform.forward);

    }

    public void baseFounded()
    {
        bases += 1;
        lifes = 3;
        if(bases ==4) print("¡Fin del juego!");
    }

    public void hit(GameObject other)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        lifes -= 1;
        if (lifes == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            print("Player: Daño recibido");
            rb.AddExplosionForce(100.0f, other.transform.position, 3.5f);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.Space))
        {
            if (lastShot >= shootFrequency) shot();
            lastShot += 0.1f;
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
