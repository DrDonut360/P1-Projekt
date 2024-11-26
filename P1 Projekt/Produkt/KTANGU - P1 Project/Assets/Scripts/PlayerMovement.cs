using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update

    private bool canMove = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // gets move input
        UnityEngine.Vector2 inputDir = new UnityEngine.Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        // moves player if conditions are met
        if (Mathf.Abs(inputDir.x) == 1 || Mathf.Abs(inputDir.y) == 1)
        {
            // prevents diagonal movement
            if (Mathf.Abs(inputDir.x) == Mathf.Abs(inputDir.y))
            {
                return;
            }

            if (!canMove)
            {
                return;
            }

            // checks if desired move is blocked
            if (Physics2D.OverlapCircle(rb.position + inputDir, 0.1f))
            {
                Debug.Log("cant move to here");
                return;
            }

            StartCoroutine(MoveGradually(inputDir));
        }
    }

    // moves player to desired tile over time
    IEnumerator MoveGradually(UnityEngine.Vector2 moveDir) 
    {
        canMove = false;

        UnityEngine.Vector2 targetPos = rb.position + moveDir;
        while (rb.position != targetPos)
        {
            rb.position += moveDir * 0.1f;
            yield return new WaitForSeconds(.01f);
        }
        
        canMove = true;
    }
}
