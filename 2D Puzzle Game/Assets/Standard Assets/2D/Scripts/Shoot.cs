﻿using System.Collections;
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
            fire();
            }
    }
    void fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
