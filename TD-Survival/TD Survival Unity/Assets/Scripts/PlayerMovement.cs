using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator animator;

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
    }

    //Wird eine festgelegte Anzahl pro Sekunde aufgerufen
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Player wird bewegt
    }
}
