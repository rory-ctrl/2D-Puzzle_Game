using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private UI_Inventory inventory;

    // public void Awake(){
    //     inventory = GameObject.Find("UI_TopBar");
    // }

    [SerializeField]
    public enum ItemType {
        Weapon,
        Bullet,
        Currency
    }

    public ItemType itemType;

    [SerializeField]
    public int amount;

    void OnTriggerEnter2D(Collider2D trigger){
        GameObject player = GameObject.Find("TimeAgentPlayer");

        if(player!= null){
            // Interact();
            pickUp();
        }
    }

    public void pickUp(){
        if(this.itemType == ItemType.Currency){
            inventory.addCurrency(amount);
            Debug.Log(amount);
            Destroy(this);
        }
    }
}
