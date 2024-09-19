using UnityEngine;

public class DotProductGeneral : MonoBehaviour
{
    [Header("Datas")]
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    [SerializeField, Range(1.0f,10.0f)] private float ReferenceRange = 5;

    [Header("Vectors")]
    [SerializeField] private Vector3 VecA;
    [SerializeField] private Vector3 VecB;
    [SerializeField] private float LenA;
    [SerializeField] private float LenB;

    [Header("Normalized vectors")]
    [SerializeField, Range(0.04f, 0.5f), Tooltip("Tip of the arrow of the normalized vectors")] float NormalizedVectorTipSize = 0.08f;
    [SerializeField] private Vector3 NormalizedVecA;
    [SerializeField] private Vector3 NormalizedVecB;

    [Header("Dot product")]
    [SerializeField] float DotProductResult;
    [SerializeField, Tooltip("Caparatively to the dot product, this value indicate a distance between a " +
        "point and the projection of the other one on ourself")] 
    private float ScalarProjectionResult;
    [SerializeField, Tooltip("Represent the precise impact point of the projection of B on A")]
    private Vector3 VectorProjectionResult;
    [SerializeField, Range(0.04f, 0.5f), Tooltip("Tip of the arrow of the normalized vectors")] float NormalizedVectorProjectionResultSize = 0.08f;

    private void OnDrawGizmos()
    {
        DrawStartingDatas();

        //Length
        LenA = Mathf.Sqrt(VecA.x * VecA.x + VecA.y * VecA.y + VecA.z * VecA.z);
        LenB = VecB.magnitude;

        //Normalization
        NormalizedVecA = VecA / LenA;
        NormalizedVecB = VecB.normalized;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.localPosition + NormalizedVecA, NormalizedVectorTipSize);
        Gizmos.DrawWireSphere(transform.localPosition + NormalizedVecB, NormalizedVectorTipSize);

        //Dot product
        //DotProductResult = Vector3.Dot(VecA, VecB);
        DotProductResult = VecA.x * VecB.x + VecA.y * VecB.y + VecA.z * VecB.z;

        //Scalar projection -> B is projected on to A, value represent the impact distance on A
        ScalarProjectionResult = Vector3.Dot(NormalizedVecA, VecB);

        //Vector projection -> result is the exact point of impact, or the representation of the vector leading to it
        VectorProjectionResult = NormalizedVecA * ScalarProjectionResult;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(VectorProjectionResult, NormalizedVectorProjectionResultSize);
    }

    private void DrawStartingDatas()
    {
        //Reference
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * ReferenceRange);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * ReferenceRange);

        //Vectors
        VecA = PointA.localPosition;
        VecB = PointB.localPosition;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.localPosition, transform.localPosition + PointA.localPosition);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.localPosition, transform.localPosition + PointB.localPosition);
    }
}