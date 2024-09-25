using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class VectorCoordinateSystem : MonoBehaviour
{
    [Header("Update World coord")]
    [SerializeField] Vector3 worldCoord;
    [SerializeField] Vector3 localCoord;

    Vector3 LocalToWorld(Vector3 localPos)
    {
        //transform.position = our local coordinate system
        Vector3 worldPosition = transform.position;
        worldPosition += localPos.x * transform.right; //x axis
        worldPosition += localPos.y * transform.up; //y axis
        worldPosition += localPos.z * transform.forward; //z axis
        return worldPosition;
    }

    Vector3 WorldToLocal(Vector3 worldPos)
    {
        //transform.position = our local coordinate system
        Vector3 relativeVector = worldPos - transform.position; //result is in world space

        //this work cause .right/up/forward are normalized
        float localX = Vector3.Dot(relativeVector, transform.right);//x axis local
        float localY = Vector3.Dot(relativeVector, transform.up);//y axis local
        float localZ = Vector3.Dot(relativeVector, transform.forward);//z axis local

        return new Vector3(localX, localY, localZ);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        localCoord = WorldToLocal(worldCoord);
        Gizmos.DrawWireSphere(worldCoord, 0.1f);
    }
#endif
}
