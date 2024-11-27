using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (inventory != null)
            {
                inventory.AddCollectable(gameObject.name);
                
                // Destroy this collectable object after adding to inventory
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Inventory is not assigned!");
            }
        }
    }
}
