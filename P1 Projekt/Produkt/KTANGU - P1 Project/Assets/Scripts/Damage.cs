using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;
    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerHealth == null) //Lets the game object player find the health script if/when it spawns in
            {
               playerHealth = collision.gameObject.GetComponent<Health>();

            }
            playerHealth.TakeDamage(damage);
        }
    }
}
