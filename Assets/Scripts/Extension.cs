using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension 
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if(rigidbody.isKinematic) // rb sẽ ko phản ứng với hệ thống vật lí 
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.375f;


       RaycastHit2D hit =  Physics2D.CircleCast(rigidbody.position,radius,direction.normalized,distance,layerMask);

       return hit.collider != null && hit.rigidbody != rigidbody;
    }

    // tich vo huowng xac dinh vi tri ( mario voi cac doi tuong khac ve vi tri (cac hop) )
    public static bool DotTest(this Transform transform, Transform other,Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position; // tim ra vecto hiua 2 vat
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f; // 0.25 || 0 || 0.5 goc giua 2 vecto

    }
}
