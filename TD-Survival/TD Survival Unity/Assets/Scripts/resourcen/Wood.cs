using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood: MonoBehaviour
{
    public int WHP = 100;
    private int WoodGained = 10;
    /*public void SetWHP (int WHPW)
    {
        WHP += WHPW;
    }*/
    public int GetWHP ()
    {
        return WHP;
    }
    private void WoodDMG (int WHPC)
    {
        WHP -= WHPC;
    }
    bool WStage1 = false;
    bool WStage2 = false;
    bool WStage3 = false;
    private void Update()
    {
        if (WHP < 75)
        {
            WStage1 = true;
            InventoryCounter.SetWoodAmount(WoodGained);
        }
        if (WHP < 50)
        {
            WStage2 = true;
            InventoryCounter.SetWoodAmount(WoodGained);
        }
        if (WHP < 25 )
        {
            WStage3 = true;
            InventoryCounter.SetWoodAmount(WoodGained);
        }
        if (WHP <=0)
        {
            InventoryCounter.SetWoodAmount(WoodGained);
            Destroy(gameObject);
        }
    }
}