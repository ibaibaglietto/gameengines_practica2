using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    bool detected = false;

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !detected)
        {
            print("Base encontrada");
            detected = true;
            Material mat = GetComponent<Renderer>().materials[1];
            mat.SetColor("_EmissionColor", Color.green);
            transform.GetChild(0).gameObject.SetActive(true);
            other.GetComponent<PlayerBehaviour>().baseFounded();
            
        }
    }
}
