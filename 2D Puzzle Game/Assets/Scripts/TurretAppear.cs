using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAppear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject g;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(g==null){
            gameObject.GetComponent<TurretFire>().enabled=true;
            gameObject.GetComponent<SpriteRenderer>().enabled=true;
        }
    }
}
