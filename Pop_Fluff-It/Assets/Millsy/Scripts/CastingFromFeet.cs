using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingFromFeet : MonoBehaviour
{
    [SerializeField]
    float duration;
    RaycastHit2D hit = new RaycastHit2D();
    Controller controller;
    public Transform castFrom;
    Transform temp;

    void Start()
    {
        controller = GetComponent<Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawRayToGround();
        if (hit != default)
        {
            RotatePlayerToGround();
        }
    }

    void DrawRayToGround()
    {
        hit = Physics2D.Raycast(castFrom.position, -transform.up, duration);
        if (hit != default)
        {
            Debug.DrawLine(castFrom.position, hit.point,Color.green);
        }
    }

    void RotatePlayerToGround()
    {
        temp.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-hit.normal), 1f);
        transform.rotation = new Quaternion(temp.rotation.x, temp.rotation.y, 0, temp.rotation.w);
    }
}
