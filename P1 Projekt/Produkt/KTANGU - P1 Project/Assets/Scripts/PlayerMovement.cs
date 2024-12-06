using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] TileManager tileManager;
    [SerializeField] QuizManager quizManager;

    public bool canMove = true;
    public UnityEngine.Vector2 inputDir;
    public bool isMoving = false;
    public bool damageTaken = false;
    void Start()
    {
        // auto asigns quizManager
        if (quizManager == null)
        {
            foreach (GameObject obj in FindObjectsOfType<GameObject>())
            {
                if (obj.GetComponent<QuizManager>() != null)
                {
                    quizManager = obj.GetComponent<QuizManager>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // gets move input
        UnityEngine.Vector2 inputDir = new UnityEngine.Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // moves player if none of the conditions are met
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

            if (quizManager.showingQuiz)
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

                damageTaken = true;

                tileManager.MakeHazardSafe(tilePosition);

                return;
            }

            if (Physics2D.OverlapCircle(targetPosition, 0.1f, LayerMask.GetMask("Safe")))
            {
                damageTaken = false;
                return;
            }

            StartCoroutine(MoveGradually(inputDir));
        }
    }

    // moves player to desired tile over time
    IEnumerator MoveGradually(UnityEngine.Vector2 moveDir) 
    {
        canMove = false;
        isMoving = true;

        UnityEngine.Vector2 targetPos = rb.position + moveDir;
        while (rb.position != targetPos)
        {
            rb.position += moveDir * 0.1f;
            yield return new WaitForSeconds(.01f);
            
        }
        yield return new WaitForSeconds(.05f); // endlag
        canMove = true;
        isMoving = false;
        
    }
}
