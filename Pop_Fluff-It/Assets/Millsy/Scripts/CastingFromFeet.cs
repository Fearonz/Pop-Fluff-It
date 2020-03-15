using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingFromFeet : MonoBehaviour
{
    [SerializeField]
    float direction = .1f;
    RaycastHit2D hit = new RaycastHit2D();
    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawRayToGround();

    }

    void CheckIfGrounded()
    {
        if (controller.mystate != Controller.states.Grounded)
        {

        }

    }

    // method for casting a ray downwards. draw only goes till it colides.
    void DrawRayToGround()
    {

        if (controller.mystate != Controller.states.Grounded)
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(0, .5f, 0), -transform.up, direction);
        }
        else
        {
            hit = default;
        }
        
        if (hit.collider.tag == "Ground")
        {
            controller.mystate = Controller.states.Grounded;
            Debug.Log("Coliding with ground");
        }

    }
}
