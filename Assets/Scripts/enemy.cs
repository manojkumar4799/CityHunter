using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target;
    public float enemyRange;
    public float enemyBulletRange;
    public float enemyBulletDamage;
    public ParticleSystem muzzleFlash;
    public AudioClip fireSound;
    

    [HideInInspector]
    public float playerToEnemyDist = Mathf.Infinity;

    bool isProvoked=false;
    bool canShoot=true;

    NavMeshAgent navMesh;
    AudioSource AS;
  
    void Start()
    {
        AS = GetComponent<AudioSource>();
        GetComponent<Animator>().SetBool("IDLE", true);
        navMesh = GetComponent<NavMeshAgent>();
    }

    public void EnemyDead()
    {
        enabled = false;
        navMesh.enabled = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyRange);
    }
    void Update()
    {
        playerToEnemyDist = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            
            EnemyProvoked();
        }
        else if(playerToEnemyDist<=enemyRange)
        {
           
            isProvoked = true;
        }
    }

    public void TookDamage()
    {
        isProvoked = true;
    }
    private void TurnAtEnemy()
    {
        Vector3 directionToTurn = (target.position - transform.position).normalized;
        Quaternion rotaionDir = Quaternion.LookRotation(new Vector3(directionToTurn.x, 0, directionToTurn.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotaionDir, 3f);
    }
    private void EnemyProvoked()
    {
        TurnAtEnemy();
        GetComponent<Animator>().SetBool("IDLE", false);
        GetComponent<Animator>().SetBool("WALK", true);
        if (playerToEnemyDist <= navMesh.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("WALK", false);
            
            if (canShoot == true)
            {
              
                StartCoroutine(EnemyFire());
            }
        }

        if(playerToEnemyDist > navMesh.stoppingDistance)
        {
            ChasePlayer();
        }
    }


    IEnumerator EnemyFire()
    {
        
        Bulletprocess();
        yield return new WaitForSeconds(3);
        canShoot = true;
        
    }

    private void Bulletprocess()
    {
       
        canShoot = false;
        RaycastHit playerObject;
        if (Physics.Raycast(transform.position, transform.forward, out playerObject, enemyBulletRange))
        {
            GetComponent<Animator>().SetTrigger("FIRE");
            muzzleFlash.Play();
            AS.PlayOneShot(fireSound);
            Debug.Log("enemy fired at: " + playerObject.transform.name);
            PlayerHealth pHealth = playerObject.transform.GetComponent<PlayerHealth>();
            if (playerObject.transform.tag == "Player")
            {
                pHealth.PlayerHealthDamage(enemyBulletDamage);
            }
        }
        else
        {
            return;
        }
    }
    private void ChasePlayer()
    {
       navMesh.SetDestination(target.position);
    }

    
}
