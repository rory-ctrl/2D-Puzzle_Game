using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlot : MonoBehaviour
{
    private Transform image;
    // Start is called before the first frame update
    void Start()
    {
        image = transform.Find("BulletImage");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameValues.hasGun){
            image.gameObject.SetActive(true);
        }
    }
}
