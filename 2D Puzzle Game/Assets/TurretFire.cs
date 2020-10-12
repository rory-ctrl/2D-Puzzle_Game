using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public double fireRate=1;
    public AudioSource audioData;
     private double lastShot = 0.0;

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    void fire()
    {
        //only fires if the attack speed time has passed.
        if (Time.time > fireRate + lastShot)
     {
         Instantiate(bullet, firePoint.position, firePoint.rotation);  
         lastShot = Time.time;
         audioData.Play(0);
     }
        
    }
}
