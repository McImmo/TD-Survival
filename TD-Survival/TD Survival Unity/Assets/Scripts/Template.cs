using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : MonoBehaviour
{
    [SerializeField]private GameObject finalObject;

    [SerializeField]private GameObject errorObject;
    private Vector2 mousePos;
    [SerializeField]
    private LayerMask allTilesLayer;
    [SerializeField]
    private LayerMask Grass;
    [SerializeField]private int costWood;
    [SerializeField]private int costStone;



    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //damit es mit den anderen Tiles "aligned" das ganze + 0.5f
        mousePos.x -= 0.5f;
        mousePos.y -= 0.5f;
        transform.position = new Vector2(Mathf.Round(mousePos.x) + 0.5f, Mathf.Round(mousePos.y) + 0.5f);

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            mousePos.x += 0.5f; //damit der Raycast trotzdem akkurat ist
            mousePos.y += 0.5f;
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, allTilesLayer); // Gebaeude darunter?
            RaycastHit2D rayHit2 = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, Grass);
            if (rayHit.collider == null)
            {
                
                if((rayHit2.collider != null) && (InventoryCounter.GetWoodAmount() >= costWood)
                && (InventoryCounter.GetStoneAmount() >= costStone))
                {
                    InventoryCounter.SetStoneAmount(-costStone);
                    InventoryCounter.SetWoodAmount(-costWood);
                    Debug.Log("Holz: " + InventoryCounter.GetWoodAmount() + "Stein: " + InventoryCounter.GetStoneAmount());
                    Instantiate(finalObject, transform.position, Quaternion.identity);
                }
            }
            else Instantiate(errorObject, transform.position, Quaternion.identity);
        }
}
}
