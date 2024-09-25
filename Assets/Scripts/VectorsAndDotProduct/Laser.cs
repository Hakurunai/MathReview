using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField, Range(2f, 20.0f)] float LaserRange = 10.0f;
    [SerializeField, Range(1, 10)] int MaxBounces = 10;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.right;
        Ray ray = new Ray(transform.position, direction);

        for (int i = 0; i < MaxBounces; ++i)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, LaserRange))
            {
                Gizmos.DrawLine(ray.origin, hit.point);

                Vector3 reflected = Reflect(ray.direction, hit.normal);
                Gizmos.DrawLine(hit.point, hit.point + reflected);

                //new ray for next reflection
                ray.direction = reflected;
                ray.origin = hit.point;
            }
            else break;
        }

    }

    Vector3 Reflect(Vector3 inDirection, Vector3 normalSurface)
    {
        //r = dir - 2(dir DOT normal) * normal -> vectoriel projection of our reflection
        float proj = Vector3.Dot(inDirection, normalSurface);
        return inDirection - 2 * proj * normalSurface;
    }
#endif
}