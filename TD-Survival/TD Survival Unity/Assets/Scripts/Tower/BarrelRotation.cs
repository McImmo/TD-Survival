using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
{   
    public Transform pivot;
    public Transform barrel;

    public Tower tower;
    void Update()
    {
        if(tower != null){
            
            if(tower.currentTarget != null) {
                
                Vector2 relative = tower.currentTarget.transform.position - pivot.position; //Vektor von pivot zu ziel
        
                float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg; //Winkel in Rad

                Vector3 newRotation = new Vector3(0,0, angle);
                Debug.Log("daite " + newRotation.z);
                
                pivot.localRotation = Quaternion.Euler(newRotation);
            }
        }
    }
}
