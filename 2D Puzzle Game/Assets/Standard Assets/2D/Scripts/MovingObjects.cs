using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MovingObjects : MonoBehaviour
{
    /*
     * This script is used to pick up and move objects within the scene 
     */
    public Transform inFrontOfPlayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    /*
     * This is triggered when player mouseclicks on an object and holds the mouseclick
     * It sets the objects ridigbody useAutoMass boolean to false and changes the position
     * of the object to the position of the transform inFrontofPlayer. It then sets the parent
     * of the object to be the gameobject ObjectHold, which is attached to the player
     */
    private void OnMouseDown()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().mass = 20;
        this.transform.position = inFrontOfPlayer.position;
        this.transform.parent = GameObject.Find("ObjectHold").transform;

    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        this.transform.parent = null;
        GetComponent<Rigidbody2D>().mass = 200;
    }
}
