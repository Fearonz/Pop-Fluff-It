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
    [SerializeField]
    int jumps;
    public states mystate = states.Grounded;
    float jumpStartedAt;
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
        jump = new Vector2(0, force);
        jumps = 1;
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
        // jumping from ground and rails.
        // add another check to makes sure the player has jumps?
        if (Input.GetKeyDown(KeyCode.Space) && mystate != states.Jumping)
        {
            Jump();
            mystate = states.Jumping;
            jumpStartedAt = Time.time * 1000;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && mystate == states.Grinding || Input.touchCount > 0 && mystate == states.Grinding)
        {
            Jump();
            mystate = states.Grinding;
        }
    }

    // method used for when a button is pressed.
    void Jump()
    {
        body.AddForce(jump);
        jumps--;
    }

    // test if the curcles overlap to set the state of the object to grounded
    public void OnGround()
    {
        Debug.Log("check on ground");
        if ((Time.time * 1000) - jumpStartedAt < 1000)
        {
            Debug.Log("I'm still jumping!!!");
            return;
        }

        if (Physics2D.OverlapCircle(checkOnGround.position, checkCollider, ground))
        {
             mystate = states.Grounded;
             jumps = 1;
            Debug.Log("grinding");
        }
    }
    //if body his rail you cant jump
    public void OnRail()
    {
        Debug.Log("check on rail");
        if ((Time.time * 1000) - jumpStartedAt < 1000)
        {
            Debug.Log("I'm still jumping!!!");
            return;
        }

        if (Physics2D.OverlapCircle(checkOnRail.position, checkCollider, rail))
        {
            mystate = states.Grinding;
            jumps = 1;
            Debug.Log("Grinding");
        }
    }
}
