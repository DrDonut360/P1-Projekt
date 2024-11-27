using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    private List<string> collected = new List<string>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddCollectable(string collectable)
    {
        collected.Add(collectable);
        Debug.Log("Collected items: " + string.Join(", ", collected));
    }
}
