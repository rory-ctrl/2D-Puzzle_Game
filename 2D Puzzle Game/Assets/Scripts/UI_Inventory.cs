using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake(){
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void setInventory(Inventory inventory){
        this.inventory = inventory;
    }

    private void RefreshInventoryItems(){
        foreach(Item item in inventory.GetItemList()){
            
        }
    }
}
