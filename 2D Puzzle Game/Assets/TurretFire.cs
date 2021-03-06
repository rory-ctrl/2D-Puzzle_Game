﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public BoxCollider2D box;
    public Animator animator;
    public Transform firePoint;
    public GameObject bullet;
    public double fireRate=1;
    public AudioSource audioData;
     private double lastShot = 0.0;
    public int health=100;
    // Update is called once per frame\
    private bool dead=false;
    
    public void TakeDamage(int dmg)
    {
        health=health-dmg;
        if(health<=0){
            dead=true;
            animator.SetBool("dead",true);
            box.enabled=false;
        }
    }
    
    void Update()
    {
        // if(GameValues.shouldShoot == true){
        //    fire(); 
        // }
        fire();
        
    }
    void fire()
    {
        //only fires if the attack speed time has passed.
        if(!dead && GameValues.shouldShoot){
        if (Time.time > fireRate + lastShot)
     {
         Instantiate(bullet, firePoint.position, firePoint.rotation);  
         lastShot = Time.time;
         audioData.Play(0);
     }
    }
    }

    // void OnTriggerEnter2D(Collider2D trigger){
    //     GameObject player = GameObject.Find("TimeAgentPlayer");

    //     if(player!= null){
    //         shouldFire = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D trigger){
    //     GameObject player = GameObject.Find("TimeAgentPlayer");

    //     if(player!= null){
    //         shouldFire = false;
    //     }
    // }
}
