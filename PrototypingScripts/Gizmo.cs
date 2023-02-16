using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{

   public enum objectType
    {
        cube,
        sphere,
        wireCube,
        wireSphere

    }
    public objectType currentType= objectType.cube;

   public Color color;
    
   [HideInInspector]
   public float size = 3f;

    void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = color;

        switch (currentType) 
        {
            case objectType.cube:
                Gizmos.DrawCube(transform.position, new Vector3(size, size, size));
                break;
            case objectType.sphere:
                Gizmos.DrawSphere(transform.position, size);
                break;
            case objectType.wireCube:
                Gizmos.DrawWireCube(transform.position, new Vector3(size, size, size));
                break;
            case objectType.wireSphere:
                Gizmos.DrawWireSphere(transform.position, size);
                break;

        }
       // Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}