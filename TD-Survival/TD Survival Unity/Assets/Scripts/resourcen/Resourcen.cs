using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourcen : MonoBehaviour
{
    public float HP = 100;
    public int ResourceGained = 10;
    public string Type = "NA";
    public Object player;
    public PlayerMovement playerM;
    /*public void SetHP (int HPW)
    {
        HP += HPW;
    }*/
    public float GetHP ()
    {
        return HP;
    }
    public void DMG (float dmg)
    {
        HP -= dmg;
    }
    bool Stage1 = false;
    bool Stage2 = false;
    bool Stage3 = false;
    private void Update()
    {
        if (Stage1 == false && HP <= 75 )
        {
            Stage1 = true;
            if (Type == "Wood") InventoryCounter.SetWoodAmount(ResourceGained);
            if (Type == "Stone") InventoryCounter.SetStoneAmount(ResourceGained);
        }
        if (Stage2 == false && HP <= 50 )
        {
            Stage2 = true;
            if (Type == "Wood") InventoryCounter.SetWoodAmount(ResourceGained);
            if (Type == "Stone") InventoryCounter.SetStoneAmount(ResourceGained);
        }
        if (Stage3 == false && HP <= 25 )
        {
            Stage3 = true;
            if (Type == "Wood") InventoryCounter.SetWoodAmount(ResourceGained);
            if (Type == "Stone") InventoryCounter.SetStoneAmount(ResourceGained);
        }
        if (HP <=0)
        {
            if (Type == "Wood") InventoryCounter.SetWoodAmount(ResourceGained);
            if (Type == "Stone") InventoryCounter.SetStoneAmount(ResourceGained);
            playerM.SetBautAb(false);
            Destroy(gameObject);
        }
    }
}
