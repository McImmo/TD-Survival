using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10f);
    }
    private void Update(){
        transform.position += transform.right * .25f;
    }
}
