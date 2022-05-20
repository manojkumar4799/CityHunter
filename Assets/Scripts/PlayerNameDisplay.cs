using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerNameDisplay : MonoBehaviour
{
    public InputField playername;
    public InputField playerEmail;
    public InputField playerAge;
    public InputField playerdate;
    public InputField playerMonth;
    public InputField playerYear;
    public Button playButton;
   
    private void Start()
    {
        
    }
    private void Update()
    {
        playButton.interactable = true;
    }
    public void DisplayPlayerName()
    {
        Debug.Log("player name is: " + playername.text);
        PlayerHealth.playerName = playername.text;
       playButton.interactable = true;
        if (playername.text == "")playButton.interactable = false;
        
        else if(playerEmail.text == "") playButton.interactable = false;
        else if (playerAge.text == "") playButton.interactable = false;
        else if (playerdate.text == "") playButton.interactable = false;
        else if (playerMonth.text == "") playButton.interactable = false;
        else if (playerYear.text == "") playButton.interactable = false;


        else
        {
            SceneManager.LoadScene(2);
        }
       
 
    }
    
}
