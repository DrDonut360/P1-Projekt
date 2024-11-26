using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 playerInput;
    float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   private void Update()
   {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
   }

   private void FixedUpdate()
   {
    rb.AddForce(playerInput);
   }
}
