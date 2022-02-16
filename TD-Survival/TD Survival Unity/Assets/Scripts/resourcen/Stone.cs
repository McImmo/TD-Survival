using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone: MonoBehaviour
{
    public int SHP = 100;
    private int StoneGained = 10;
    /*public void SetSHP (int SHPW)
    {
        SHP += SHPW;
    }*/
    public int GetSHP ()
    {
        return SHP;
    }
    private void StoneDMG (int SHPC)
    {
        SHP -= SHPC;
    }
    bool SStage1 = false;
    bool SStage2 = false;
    bool SStage3 = false;
    private void Update()
    {
        if (SStage1 = false && SHP < 75)
        {
            SStage1 = true;
            InventoryCounter.SetStoneAmount(StoneGained);
        }
        if (SStage2 = false && SHP < 50)
        {
            SStage2 = true;
            InventoryCounter.SetStoneAmount(StoneGained);
        }
        if (SStage3 = false && SHP < 25 )
        {
            SStage3 = true;
            InventoryCounter.SetStoneAmount(StoneGained);
        }
        if (SHP <=0)
        {
            InventoryCounter.SetStoneAmount(StoneGained);
            Destroy(gameObject);
        }
    }
}
