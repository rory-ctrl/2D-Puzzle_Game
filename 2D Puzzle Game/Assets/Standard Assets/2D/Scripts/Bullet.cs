using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed =20f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity=transform.right*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(){
        Destroy(gameObject);
    }
}
