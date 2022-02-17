using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood: MonoBehaviour
{
    public float WHP = 100;
    private int WoodGained = 10;
    /*public void SetWHP (int WHPW)
    {
        WHP += WHPW;
    }*/
    public float GetWHP ()
    {
        return WHP;
    }
    public void WoodDMG (float dmg)
    {
        WHP -= dmg;
    }
    bool WStage1 = false;
    bool WStage2 = false;
    bool WStage3 = false;
    private void Update()
    {
        if ( WStage1 == false && WHP <= 75 )
        {
            WStage1 = true;
            InventoryCounter.SetWoodAmount(WoodGained);
        }
        if (WStage2 == false && WHP <= 50 )
        {
            WStage2 = true;
            InventoryCounter.SetWoodAmount(WoodGained);
        }
        if (WStage3 == false && WHP <= 25 )
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
