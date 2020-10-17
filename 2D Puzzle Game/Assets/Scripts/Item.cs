using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // [SerializeField] private UI_Inventory inventory;

    // public void Awake(){
    //     inventory = GameObject.Find("UI_TopBar");
    // }

    // [SerializeField]
    // public enum ItemType {
    //     Weapon,
    //     Bullet,
    //     Currency
    // }

    // public ItemType itemType;

    [SerializeField]
    public int amount;

    void OnTriggerEnter2D(Collider2D trigger){
        GameObject player = GameObject.Find("TimeAgentPlayer");

        if(trigger.tag == "Player"){
            // Interact();
            Debug.Log("Collision");
            GameValues.score += this.amount;
            // trigger.gameObject.GetComponent<PlatformerCharacter2D>().addCrystals(this.amount);
            Destroy(this.gameObject);
        }
    }

    // public void pickUp(){
    //     if(this.itemType == ItemType.Currency){
    //         inventory.addCurrency(amount);
    //         Debug.Log(amount);
    //         Destroy(this);
    //     }
    // }
}
