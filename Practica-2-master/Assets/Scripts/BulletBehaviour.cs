using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;

    Vector3 direction;

    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }
    
    void FixedUpdate()
    {
        transform.position += speed * direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != tag)
        {
            if (other.tag == "Turret")
            {
                print($"Destruida unidad {other.name}");
                other.gameObject.SetActive(false);
            }
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerBehaviour>().hit(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
