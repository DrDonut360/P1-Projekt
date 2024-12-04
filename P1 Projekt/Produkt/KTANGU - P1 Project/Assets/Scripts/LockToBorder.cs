using Unity.VisualScripting;
using UnityEngine;

public class SpriteBorderLock : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 offset;
    private Vector2 borderPosition = new Vector2(0f, 1f);

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        PositionSpriteOnBorder();
    }

    void PositionSpriteOnBorder()
    {
        // Convert viewport position to world position
        Vector3 viewportPosition = new Vector3(borderPosition.x, borderPosition.y, 0);
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        // Apply the new position to the sprite + offset
        transform.position = worldPosition + offset;

        // z axis shenanigans
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void Update()
    {
        PositionSpriteOnBorder();
    }
}
