using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    private void Awake(){
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private int Stone;
    private int Wood;
    private int WoodInInventory;
    private int StoneInInventory;

    private void Update(){
        Wood = InventoryCounter.GetWoodAmount();
        Stone = InventoryCounter.GetStoneAmount();
        if (Wood > WoodInInventory){
            inventory.AddItem(new Item {itemType = Item.ItemType.Wood, amount = 1});
            StoneInInventory = Stone;   
        }
        if (Stone > StoneInInventory){
            inventory.AddItem(new Item {itemType = Item.ItemType.Stone, amount = 1});
            StoneInInventory = Stone;   
        }

    }

}
