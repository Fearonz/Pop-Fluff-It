using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMove : MonoBehaviour
{ 

    void Update()
    {
        transform.position -= transform.right /20;

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
