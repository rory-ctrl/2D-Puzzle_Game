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
            GameValues.score += this.amount;
            Destroy(this.gameObject);
        }
    }

}
