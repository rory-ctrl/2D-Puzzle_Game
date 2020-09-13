using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed =20f;
    public float lifeTime = 5f;
    // Start is called before the first frame update
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb.velocity=transform.right*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target){
        switch(target.tag){
            case "Terrain":
                 Destroy(gameObject);
                 break;
            default:
                break;
        
    }
    }
}
