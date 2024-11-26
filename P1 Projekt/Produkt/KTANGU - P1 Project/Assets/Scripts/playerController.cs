using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float speed = 20f; 
    private Rigidbody2D rb;
    private UnityEngine.Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   void Update()
   {
        direction = new UnityEngine.Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
   }

   private void FixedUpdate()
   {
        rb.velocity = direction * speed;
   }
}
