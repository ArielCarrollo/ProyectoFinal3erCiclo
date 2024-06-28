using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject MusicSettings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAudioSettings()
    {
        if (MusicSettings.activeSelf == false)
        {
            MusicSettings.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            MusicSettings.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
