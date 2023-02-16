using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionLayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int  startLayer;
    public int endLayer;
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

       // Physics.IgnoreLayerCollision(startLayer, endLayer);
    }

     void Update()
    {
        Physics.IgnoreLayerCollision(0, 8);

    }


}
