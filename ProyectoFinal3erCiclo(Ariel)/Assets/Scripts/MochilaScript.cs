using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AgarrarObjeto : MonoBehaviour
{
    public Transform jugador; 

    private bool agarrado = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            transform.SetParent(jugador);

            transform.localPosition = new Vector3(0.2f, 0.0f, 0.1f);

            Quaternion rotacionJugador = jugador.rotation;

            transform.rotation = rotacionJugador;
            transform.Rotate(Vector3.up, -180f);
            transform.Rotate(Vector3.right, -90f);
        }
    }
}

