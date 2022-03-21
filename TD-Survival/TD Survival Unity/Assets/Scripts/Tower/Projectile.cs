using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage = 20f;

    private void Start()
    {
        damage = 20f;
        Destroy(gameObject, 10f);
    }
    private void Update(){
        transform.position += transform.right * .175f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Enemy")  
        {
            Debug.Log("gegner kassiert " + damage);
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
