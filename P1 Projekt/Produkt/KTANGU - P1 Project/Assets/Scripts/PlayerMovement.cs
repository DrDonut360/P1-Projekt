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
    [SerializeField] TileManager tileManager;
    // Start is called before the first frame update

    private bool canMove = true;
    public UnityEngine.Vector2 inputDir;
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

            UnityEngine.Vector2 targetPosition = rb.position + inputDir;

            // Calculate the tile position  (tak chatgpt)
            Vector3Int tilePosition = new Vector3Int(
                Mathf.FloorToInt(targetPosition.x),
                Mathf.FloorToInt(targetPosition.y),
                0
            );

            if (Physics2D.OverlapCircle(targetPosition, 0.1f, LayerMask.GetMask("Hazard")))
            {
                GetComponent<Health>().TakeDamage(1);

                tileManager.MakeHazardSafe(tilePosition);

                return;
            }

            if (Physics2D.OverlapCircle(targetPosition, 0.1f, LayerMask.GetMask("Safe")))
            {
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
        yield return new WaitForSeconds(.05f); // endlag
        canMove = true;
    }
}
