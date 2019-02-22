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

    float lastShot;


    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2));
        print(dist);
        if (dist < shootRange)
        {
            cannon.LookAt(player);
            shot();

        }
    }

    void shot()
    {

    }
}
