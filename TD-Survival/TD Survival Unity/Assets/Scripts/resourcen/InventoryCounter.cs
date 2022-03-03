using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryCounter 
{
    public static int WoodAmount = 0;
    public static int StoneAmount = 0;
    public static void SetWoodAmount(int W)
    {
        WoodAmount += W; 
    }
    public static int GetWoodAmount()
    {
        return WoodAmount;
    }
    public static void SetStoneAmount(int S)
    {
        StoneAmount += S;
    }
    public static int GetStoneAmount()
    {
        return StoneAmount;
    }

}
