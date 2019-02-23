using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    /* Variables publicas
     * - Variable objetivo (player)
     * - ALtura mínima (4f)
     * - Factor de altura
     */
    public GameObject player;
    public float minHeight;
    public float heightFact;

    /* Variables privadas
     * - Altura
    */
    float height;

    // Update is called once per frame
    void LateUpdate()
    {
        //Calculamos la posición de la cámara
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + height, player.transform.position.z);
        //Conseguimos el rigidbody
        Rigidbody rb = player.GetComponent<Rigidbody>();
        //Calculamos la nueva altura de la cámara
        height = minHeight * (1 + rb.velocity.magnitude / heightFact);
    }
}
