using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : MonoBehaviour
{
    public Transform player;
    public float runAtDistance;
    public AudioClip publicScreamSFX;
    public float civilianHealth;
    
   
    NavMeshAgent navMesh;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        navMesh = GetComponentInParent<NavMeshAgent>();
        GetComponentInParent<Animator>().SetBool("IDLE", true);
    }

    // Update is called once per frame
    void Update()
    {
        RunAway();
    }

    public void HealthDamage(float damageReceive)
    {
        civilianHealth-=damageReceive;
        if(civilianHealth<=0)
        {
            GetComponentInParent<Animator>().SetBool("IDLE", false);
            GetComponentInParent<Animator>().SetTrigger("DEATH");
            enabled = false;
            navMesh.enabled = false;
        }
    }
     
   

    private void RunAway()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < runAtDistance)
        {
            GetComponentInParent<Animator>().SetBool("IDLE", false);
            GetComponentInParent<Animator>().SetTrigger("RUNAWAY");
            Vector3 dirToRun = transform.position - player.position;
            Vector3 newPos = (transform.position + dirToRun);
            navMesh.SetDestination(newPos);
            if(!AS.isPlaying)
            {
                AS.PlayOneShot(publicScreamSFX);
            }

        }
        else
        {
            GetComponentInParent<Animator>().SetBool("IDLE", true);
            AS.Stop();
        }
    }
}
