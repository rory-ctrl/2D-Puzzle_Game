using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private double fireRate=0.4;

     private double lastShot = 0.0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //checks that the weapon is a child of the player before allowing it to be fired.
            if((gameObject.transform.parent!=null)){
                if(gameObject.transform.parent.tag=="Player"){
                    fire();
                    
            }
        }
        }
    }
    void fire()
    {
        //only fires if the attack speed time has passed.
        if (Time.time > fireRate + lastShot)
     {
         Instantiate(bullet, firePoint.position, firePoint.rotation);  
         lastShot = Time.time;
     }
        
    }
}
