using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    

    //public Transform WeaponPoint;
    public float attackRange=0.5f;
    GameObject item;
    public Transform WeaponPoint;
    public Transform PickupPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")){
           if(item!=null){
               foreach (Transform child in transform)
                    {
                    Instantiate(child.gameObject,PickupPoint.position,PickupPoint.rotation);
                    Destroy(child.gameObject);
                     }
               Instantiate(item,WeaponPoint.position,WeaponPoint.rotation).transform.parent=gameObject.transform;
               }
           Destroy(item);
        }
    }
    void OnTriggerEnter2D(Collider2D target){
        Debug.Log("test");
        if(target.tag=="Weapon"){
           item=target.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D target){
         if(target.tag=="Weapon"){
           item=null;
        }
    }
}
