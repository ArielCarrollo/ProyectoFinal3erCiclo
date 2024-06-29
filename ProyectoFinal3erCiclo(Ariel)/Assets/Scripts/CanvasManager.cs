using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject MusicSettings;
    public bool Onview = false;

    public void ShowAudioSettings()
    {
        if (Onview == false || Input.GetKey(KeyCode.Escape))
        {
            Onview = true;
            MusicSettings.GetComponent<TransitionSettings>().Move();
        }
        else
        {
            Onview = false;
            //MusicSettings.SetActive(false);
            MusicSettings.GetComponent<TransitionSettings>().ReverseMove();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
