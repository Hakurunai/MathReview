using UnityEngine;

[SelectionBase]
public class RadialTrigger : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1.0f)] float Radius = 0.5f;
    [SerializeField] Transform Player;
    [SerializeField] bool IsInside = false;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (Player != null)
        {
            Vector3 ToPlayer = Player.transform.position - transform.position;
            float distance = Vector3.SqrMagnitude(ToPlayer);
            //same as doing this to compute length
            //Vector3.Dot(ToPlayer, ToPlayer);

            IsInside = distance < (Radius * Radius);
        }

        Gizmos.color = IsInside ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
#endif
}