using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float playerBulletRange;
    public float playerBulletDamage;
    public ParticleSystem muzzleFlash;
    public AudioClip fireSound;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //WeaponFire();
    }

    public void WeaponFire()
    {
       // if (Input.GetMouseButtonDown(0))
       // {
            RaycastHit hitObject;
        muzzleFlash.Play();
        audioSource.PlayOneShot(fireSound);

        if (Physics.Raycast(transform.position, transform.forward, out hitObject, playerBulletRange))
            {
            
            Debug.Log("hit object is: " + hitObject.transform.name);
                EnemyHealth eHealth = hitObject.transform.GetComponent<EnemyHealth>();
                Civilian Civ = hitObject.transform.GetComponent<Civilian>();

                if (hitObject.transform.tag == "Enemy")
                {
                    eHealth.EnemyHealthDamage(playerBulletDamage);
                }
                else if(hitObject.transform.tag=="CIV")
                {
                    Civ.HealthDamage(playerBulletDamage);
                }
            }
            else return;
        //}
    }
}
