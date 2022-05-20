using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerhealth;
    public AudioClip damageSound;
    public static string playerName;
    public Text nameDisplay;
    public Text healthDisplay;
    public Canvas deathCanvas;
   
    
    AudioSource AS;

    void Start()
    {
        deathCanvas.enabled = false;
        nameDisplay.text = playerName;
        AS = GetComponent<AudioSource>();
        healthDisplay.text = playerhealth.ToString();
    }
    public void PlayerHealthDamage(float damageReceive)
    {
        playerhealth-=damageReceive;
        healthDisplay.text = playerhealth.ToString();
        AS.PlayOneShot(damageSound);
        if(playerhealth<=0)
        {
            deathCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }

   
    void Update()
    {
        
    }
}
