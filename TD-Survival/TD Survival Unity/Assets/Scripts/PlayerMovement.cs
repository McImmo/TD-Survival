using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    bool bautAb = false;

    // Update is called once per frame
    void Update()
    {
        //Input wird verarbeitet
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Erste String (z.B. Horizontal) wird auf den Wert der zweiten Variable (z.B. movement.x) gesetzt
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("BautAb", bautAb);
    }

    //Wird eine festgelegte Anzahl pro Sekunde aufgerufen
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Player wird bewegt
    }

    public bool GetBautAb()
    {
        return bautAb;
    }

    public void SetBautAb(bool set)
    {
        bautAb = set;
    }
    
    private Inventory inventory;

    private void Awake(){
        inventory = new Inventory();
    }
}
