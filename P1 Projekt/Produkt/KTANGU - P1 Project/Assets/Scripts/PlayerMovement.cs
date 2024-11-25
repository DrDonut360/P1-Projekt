using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform trans;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionStay2D(Collision2D collider) {
        Debug.Log(collider.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            trans.position = new Vector2(trans.position.x + 1, trans.position.y);
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            trans.position = new Vector2(trans.position.x - 1, trans.position.y);
        }
    }
}
