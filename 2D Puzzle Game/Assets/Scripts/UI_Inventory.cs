using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    // private Inventory inventory;
    // private Transform itemSlotContainer;
    // private Transform itemSlotTemplate;

    // private int m_Currency;
    // private Item Weapon;
    // private Item Bullet;

    // private void Awake(){
    //     m_Currency = 0;
    //     // itemSlotContainer = transform.Find("ItemSlotContainer");
    //     // itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    // }

    // public void addCurrency(int amount){
    //     m_Currency += amount;
    // }

    // public void setInventory(Inventory inventory){
    //     this.inventory = inventory;
    //     RefreshInventoryItems();
    // }

    // private void RefreshInventoryItems(){
    //     int x = 0;
    //     int y = 0;
    //     float itemSlotCellSize = 30f;

    //     foreach(Item item in inventory.GetItemList()){
    //         RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
    //         itemSlotRectTransform.gameObject.SetActive(true);
    //         itemSlotRectTransform.anchoredPosition = new Vector2(x*itemSlotCellSize, y*itemSlotCellSize);
    //         x++;

    //     }
    // }
}
