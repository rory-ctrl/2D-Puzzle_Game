using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPositionRef : MonoBehaviour
{

    public GameObject Player;
    public static Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
        position = Player.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
       
        

    }
}
