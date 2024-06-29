using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackpackScript : MonoBehaviour
{
    public GameObject MochilaGauge;
    public GameObject lightBackpack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            this.gameObject.SetActive(false);
            lightBackpack.SetActive(false);
            MochilaGauge.GetComponent<TransitionGauge>().Move();
        }
    }
}

