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
    bool WStage1 = false;
    bool WStage2 = false;
    bool WStage3 = false;
    private void Update()
    {
        if (SHP < 75)
        {
            WStage1 = true;
            InventoryCounter.SetStoneAmount(StoneGained);
        }
        if (SHP < 50)
        {
            WStage2 = true;
            InventoryCounter.SetStoneAmount(StoneGained);
        }
        if (SHP < 25 )
        {
            WStage3 = true;
            InventoryCounter.SetStoneAmount(StoneGained);
        }
        if (SHP <=0)
        {
            InventoryCounter.SetStoneAmount(StoneGained);
            Destroy(gameObject);
        }
    }
}
