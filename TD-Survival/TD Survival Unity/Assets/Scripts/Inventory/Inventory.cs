using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    private int Slot;

    public Inventory(){
        itemList = new List<Item>();
    }
    public void AddItem(Item item){
        if(Slot < 6){
            if(item.IsStackable()){
                bool itemAlreadyInInventory = false;
                foreach(Item inventoryItem in itemList){
                    if(inventoryItem.itemType == item.itemType){
                        if(inventoryItem.amount < 5){
                            inventoryItem.amount += item.amount;
                            itemAlreadyInInventory = true;
                        }
                        else if (inventoryItem.amount == 5){
                            if(inventoryItem.amount < 5){
                                inventoryItem.amount += item.amount;
                                itemAlreadyInInventory = true;
                            }
                        }               
                    }
                }
                if (!itemAlreadyInInventory){
                    if(Slot < 5){
                        itemList.Add(item);
                        Slot++;
                    }
                }
            }
            else{
                itemList.Add(item);
            }
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        
    }

    public List<Item> GetItemList(){
        return itemList;
    }


}
