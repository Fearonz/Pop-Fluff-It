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
        DrawRayToRail();
    }

    // method for casting a ray downwards. draw only goes till it colides.
    void DrawRayToGround()
    {
        // this is called when the player is not grounded and draws a ray from the bottom of the player
        // down. this ray only travils as far as the direction variable. more needs to be added
        // 
        if (controller.mystate != Controller.states.Grounded)
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(0, .5f, 0), -transform.up, direction);
        }
        else
        {
            hit = default;
        }
    }
    void DrawRayToRail()
    {
        if (controller.mystate != Controller.states.Grinding)
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(0, .5f, 0), -transform.up, direction);
        }
        else
        {
            hit = default;
        }
    }
}
