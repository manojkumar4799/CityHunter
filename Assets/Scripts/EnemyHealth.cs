using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    
    Manager _manager;

    enemy enemyScript;
    void Start()
    {
     
       enemyScript = GetComponentInParent<enemy>();
        _manager = FindObjectOfType<Manager>();
        _manager.IncreaseInEnemy();
    }

   

  public void EnemyHealthDamage(float damageReceive)
  {
        enemyHealth -= damageReceive;
        _manager.IncreasePlayerScore();
        enemyScript.TookDamage();
        if(enemyHealth<=0)
        {
            _manager.DecreaseInEnemy();
            enemyScript.EnemyDead();
            GetComponentInParent<Animator>().SetBool("WALK", false);
            GetComponentInParent<Animator>().SetTrigger("DEATH");
           
        }
  }
    
}
