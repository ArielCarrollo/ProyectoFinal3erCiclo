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
    void Update()
    {
        Times = Times - Time.deltaTime;
        Times = Mathf.Clamp(Times, 0f, 60f);
        TimeText.text = "Tiempo: " + Times.ToString("F0");
        if(Times <= 0)
        {
            SceneManager.LoadScene("Final");
        }
    }
}
