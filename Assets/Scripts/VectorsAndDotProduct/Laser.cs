using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField, Range(0.5f, 10.0f)] float LaserRange = 10.0f;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 direction = transform.right;
        Gizmos.color = Color.red;

        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, LaserRange))
        {
            Gizmos.DrawLine(transform.position, hit.point);
        }
    }
#endif
}