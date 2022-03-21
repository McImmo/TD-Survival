using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
    [SerializeField] private Transform toggleUI;

    private bool isActive = false;


    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab) && (isActive == false)){
            toggleUI.gameObject.SetActive(true);
            isActive = true;
            RefreshInventoryItems();
        }

        if(Input.GetKeyDown("i") && (isActive == true)){
            toggleUI.gameObject.SetActive(false);
            isActive = false;
        }
    }

    private void Start(){
        isActive = false;
    }

    public void SetInventory(Inventory inventory){
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
        foreach (Transform child in itemSlotContainer){
            if(child == itemSlotTemplate){
                continue;
            }
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 112;

        foreach (Item item in inventory.GetItemList()){
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 0){
                uiText.SetText(item.amount.ToString());
            }
            else{
                uiText.SetText("0");
            }

            x++;
        }
    }

}
