using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    //Boolean para ver si la base a sido detectada
    bool detected = false;

    

    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador entra en el trigger y la base no ha sido detectada
        if(other.tag == "Player" && !detected)
        {
            //Imprimimos un mensaje
            print("Base encontrada");
            //Activamos el boolean
            detected = true;
            //Cambiamos el material emisor de la base y activamos la luz
            Material mat = GetComponent<Renderer>().materials[1];
            mat.SetColor("_EmissionColor", Color.green);
            transform.GetChild(0).gameObject.SetActive(true);
            other.GetComponent<PlayerBehaviour>().baseFounded();
            
        }
    }
}
