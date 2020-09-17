using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //checks that the weapon is a child of the player before allowing it to be fired.
            if(gameObject.transform.parent!=null){
                if(gameObject.transform.parent.tag=="Player"){
            fire();
            }
        }
        }
    }
    void fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
