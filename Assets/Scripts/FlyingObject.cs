using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    [Header("Target (optional)")]
    [SerializeField] private Transform target;  // assign Player here if you want auto-start

    [Header("Movement")]
    [SerializeField] private float speed = 6f;          // units per second
    [SerializeField] private float arriveDistance = 0.05f; // how close is “close enough”

    private Vector3 targetPosition;
    private bool isMoving;

    private void Start()
    {
        // If a target Transform is assigned, lock the target position at spawn time.
        if (target != null)
            SetTarget(target.position);
    }

    private void Update()
    {
        if (!isMoving) return;

        // Move towards the target position without overshooting.
        Vector3 newPos = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        transform.position = newPos;

        // Arrival check (no sqrt)
        float arriveDistSqr = arriveDistance * arriveDistance;
        if ((targetPosition - newPos).sqrMagnitude <= arriveDistSqr)
        {
            // Snap exactly to target and destroy.
            transform.position = targetPosition;
            isMoving = false;
            Destroy(gameObject);
        }
    }

    // Keeps your original API: set a target position and start moving.
    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    // Optional convenience: set a target Transform (locks to its current position).
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        SetTarget(newTarget.position);
    }
}
