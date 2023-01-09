using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript_V1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void restartGame()
    {
        Debug.Log("Restarting Game!");
        SceneManager.LoadScene("RandomLevelGenTest_V1");
    }
}
