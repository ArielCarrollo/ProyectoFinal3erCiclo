using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecControlller : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GM;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "SafeObject")
        {
            if (Player.GetComponent<PlayerController>().SafeObjects <= 1)
            {
                GM.GetComponent<GameManager>().ShowGoodEnding();
            }
            else
            {
                Player.GetComponent<PlayerController>().SafeObjects = Player.GetComponent<PlayerController>().SafeObjects - 1;
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "UnSafeObject")
        {
            if (Player.GetComponent<PlayerController>().UnSafeObjects <= 1)
            {
                GM.GetComponent<GameManager>().ShowBadEnding();
            }
            else
            {
                Player.GetComponent<PlayerController>().UnSafeObjects = Player.GetComponent<PlayerController>().UnSafeObjects - 1;
                Destroy(this.gameObject);
            }
        }
    }
}
