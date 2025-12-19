using UnityEngine;

public class PlayerMoveRotate_Legacy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;     // units/sec
    [SerializeField] private float turnSpeed = 180f;   // degrees/sec

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
