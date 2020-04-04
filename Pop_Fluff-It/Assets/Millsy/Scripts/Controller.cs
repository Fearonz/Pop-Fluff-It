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
    public states mystate = states.Grounded;
    public enum states
    {
        Grounded,
        Jumping,
        Falling,
        Grinding,
        Landing
    }
    
    public Transform checkOnGround;
    public Transform checkOnRail;
    public float checkCollider;
    public LayerMask ground;
    public LayerMask rail;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // small issue with the jump. if held the jum state can stick when the player is grounded preventing further jumps
    // comebac to this at a later date.
    void Update()
    {
        OnGround();
        OnRail();
        Movement();
    }

    public void Movement()
    {
        // dummy test jump with real jump
        if (Input.GetKeyDown(KeyCode.W) && mystate == states.Grounded || Input.touchCount > 0 && mystate == states.Grounded)
        {
            Jump();
            mystate = states.Jumping;
        }
        else if (Input.GetKeyDown(KeyCode.W) && mystate == states.Grinding || Input.touchCount > 0 && mystate == states.Grinding)
        {
            Jump();
            mystate = states.Jumping;
        }
    }

    // method used for when a button is pressed.
    void Jump()
    {
        //onGround = Physics2D.OverlapCircle(checkOnGround.position, checkCollider, thisIsGround);
        
        jump = new Vector2(0, force);
        body.AddForce(jump);
    }

    // test if the curcles overlap to set the state of the object to grounded
    public void OnGround()
    {
        if (Physics2D.OverlapCircle(checkOnGround.position, checkCollider, ground))
        {
          mystate = states.Grounded;
        }
    }
    //if body his rail you cant jump
    public void OnRail()
    {
        if (Physics2D.OverlapCircle(checkOnRail.position, checkCollider, rail))
        {
            mystate = states.Grinding;
        }
    }
}
