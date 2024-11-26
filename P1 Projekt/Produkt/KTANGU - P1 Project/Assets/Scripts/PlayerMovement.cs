using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // gets move input
        UnityEngine.Vector2 inputDir = new UnityEngine.Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(inputDir.x) == 1 || Mathf.Abs(inputDir.y) == 1)
        {
            // THIS SHOULD BE CHANGED!!!
            if (!Input.anyKeyDown)
            {
                return;
            }

            // checks if desired move is passable 
            if (Physics2D.OverlapCircle(rb.position + inputDir, 0.1f))
            {
                Debug.Log("cant move to here");
                return;
            }

            Move(inputDir);
        }
    }

    private void Move(UnityEngine.Vector2 inputDir)
    {
            rb.position += inputDir;
    }

    /*IEnumerator MoveGradually(UnityEngine.Vector2 targetPos)
    {
        trans.position = new UnityEngine.Vector2((targetPos.x - trans.position.x) *0.1f, (targetPos.y - trans.position.y) *0.1f);
    }*/
}
