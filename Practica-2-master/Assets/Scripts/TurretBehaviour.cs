using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform cannon;
    public Transform player;
    public GameObject bullet;
    public float shootRange;
    public float shootFrequency;

    float maxRange;
    float lastShot;


    // Update is called once per frame
    void Update()
    {
        float distPlayer = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2));
        if (distPlayer < shootRange)
        {
            cannon.LookAt(player);
            if(lastShot >= shootFrequency) shot();
        }
        lastShot += 0.01f;

        
    }

    void shot()
    {
        lastShot = 0.0f;
        bullet.transform.position = transform.position;
        bullet.tag = tag;
        Instantiate(bullet).GetComponent<BulletBehaviour>().setDirection(cannon.forward);

    }
}
