using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public float playerScore;
    public float PointPerHit;
    public Canvas winCanvas;
    public Text displayScore;
   public int enemyInNumber;
    int enemyKill = 1;


    void Start()
    {
        displayScore.text = playerScore.ToString();
        winCanvas.enabled = false;
    }
    public void IncreaseInEnemy()
    {
        enemyInNumber++;
    }
    public void DecreaseInEnemy()
    {
        enemyInNumber--;
        if(enemyInNumber<=0)
        {
            winCanvas.enabled = true;
            Invoke("TimeToDelay", 3f);
        }
    }

    public void IncreasePlayerScore()
    {
        playerScore += PointPerHit;
    }

 private void TimeToDelay()
    {
        Time.timeScale = 0f;
    }
   void Update()
   {
        displayScore.text = playerScore.ToString();
   }
}
