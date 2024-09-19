using UnityEngine;

public class VectorsAndDotProductBasics : MonoBehaviour
{
    [Header("Datas")]
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;
    [SerializeField, Range(1.0f,10.0f)] float ReferenceRange = 5;

    [Header("Vectors")]
    [SerializeField] Vector3 VecA;
    [SerializeField] Vector3 VecB;
    [SerializeField] Vector3 VecAToB;
    [SerializeField] float LenA;
    [SerializeField] float LenB;

    [Header("Normalized vectors")]
    [SerializeField, Range(0.04f, 0.5f), Tooltip("Tip of the arrow of the normalized vectors")] 
    float NormalizedVectorTipSize = 0.08f;
    [SerializeField] Vector3 NormalizedVecA;
    [SerializeField] Vector3 NormalizedVecB;

    [Header("Dot product")]
    [SerializeField] float DotProductResult;
    [SerializeField, Tooltip("Caparatively to the dot product, this value indicate a distance between a " +
        "point and the projection of the other one on ourself")] 
    float ScalarProjectionResult;
    [SerializeField, Tooltip("Represent the precise impact point of the projection of B on A")]
    Vector3 VectorProjectionResult;
    [SerializeField, Range(0.04f, 0.5f), Tooltip("Tip of the arrow of the normalized vectors")] 
    float NormalizedVectorProjectionResultSize = 0.08f;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        DrawStartingDatas();
        VecAToB = VecB - VecA;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + VecA, VecAToB);

        //Length
        LenA = Mathf.Sqrt(VecA.x * VecA.x + VecA.y * VecA.y + VecA.z * VecA.z);
        LenB = VecB.magnitude;

        //Normalization
        NormalizedVecA = VecA / LenA;
        NormalizedVecB = VecB.normalized;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position + NormalizedVecA, NormalizedVectorTipSize);
        Gizmos.DrawWireSphere(transform.position + NormalizedVecB, NormalizedVectorTipSize);

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
        VecA = PointA.position;
        VecB = PointB.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + VecA);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + VecB);
    }
#endif
}