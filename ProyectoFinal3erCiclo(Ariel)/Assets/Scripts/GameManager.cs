using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public float Times = 60f;
    public GameObject Backpack;
    void Update()
    {
        Times = Times - Time.deltaTime;
        Times = Mathf.Clamp(Times, Backpack.GetComponent<BackpackScript>().TimeLimiter, 60f);
        TimeText.text = "Tiempo: " + Times.ToString("F0");
        if(Times <= 0)
        {
           SceneManager.LoadScene("Final");
        }
    }
}
