using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    


    GameObject item;
    public Transform WeaponPoint;
    public Transform PickupPoint;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.name);
    }

    
    void Update()
    {
        if(Input.GetKeyDown("e")){
           if(item!=null){
               //Places a copy of the currently held wepaon on the ground before deleteing it from the player
               foreach (Transform child in transform)
                    {
                    Instantiate(child.gameObject,PickupPoint.position,PickupPoint.rotation);
                    Destroy(child.gameObject);
                     }
                //Places a copy of the item being picked up as a child of the player
               Instantiate(item,WeaponPoint.position,WeaponPoint.rotation).transform.parent=gameObject.transform;
               GameValues.hasGun = true;
               }
               //Destroys the item the player picked up
           Destroy(item);
        }
    }

    //If the object being collided with is tagged as a weapon it is stored in a game object
    //This allows the object to be instatiated if needed
    void OnTriggerEnter2D(Collider2D target){
        if(target.tag=="Weapon"){
           item=target.gameObject;
        }
    }
    //Removes the game object from the variable so the player cannot pickup items when they are not in range
    void OnTriggerExit2D(Collider2D target){
         if(target.tag=="Weapon"){
           item=null;
        }
    }
}
