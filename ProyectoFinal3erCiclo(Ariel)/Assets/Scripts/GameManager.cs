using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Update()
    {
        
    }
    public void ShowGoodEnding()
    {
         SceneManager.LoadScene("Good");
    }
    public void ShowBadEnding()
    {
         SceneManager.LoadScene("Bad");
    }
}
