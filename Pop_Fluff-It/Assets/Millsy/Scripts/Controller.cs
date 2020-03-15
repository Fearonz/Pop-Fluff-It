using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;
    [SerializeField]
    float force;
    Vector2 jump;

    public enum states
    {
        Grounded,
        Jumping,
        Falling,
        Grinding,
        Landing
    }
    public states mystate = states.Grounded;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // dummy test jump
        if (Input.GetKeyDown(KeyCode.W) && mystate == states.Grounded)
        {
            //Debug.Log("Pressing W");
            jump = new Vector2(0, force);
            body.AddForce(jump);
            mystate = states.Jumping;
        }
    }

    // method used for when a button is pressed.
    void Jump()
    {
        jump = new Vector2(0, force);
        body.AddForce(jump);
    }
}
