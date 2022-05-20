using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sceneloader : MonoBehaviour
{
    void Start()
    {

    }

    public void LoadRegistrationScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
       SceneManager.LoadScene(2);
    }
    public void LoadPlayScene()
    {
        FindObjectOfType<PlayerNameDisplay>().DisplayPlayerName();
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
