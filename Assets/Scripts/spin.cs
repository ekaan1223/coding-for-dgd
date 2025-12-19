using UnityEngine;

public class SpinningObstacleSimple : MonoBehaviour
{
    [SerializeField] private float spinSpeedDegreesPerSecond = 100f;
    [SerializeField] private Vector3 localSpinAxis = Vector3.up;

    private void Update()
    {
        Vector3 axis = localSpinAxis.sqrMagnitude > 0f ? localSpinAxis.normalized : Vector3.up;
        transform.Rotate(axis, spinSpeedDegreesPerSecond * Time.deltaTime, Space.Self);
    }
}
