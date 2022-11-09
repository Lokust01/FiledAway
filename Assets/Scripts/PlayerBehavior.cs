using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    public float jumpHeight;
    public float playerSpeed;
    Rigidbody2D rb;
    
    private Animator movement;

    //this is for the end, when i need to scale the character down for animations
    public Vector2 scale;
    public float xScale;
    public float yScale;

    private BoxCollider2D coll;
    public float raycastHeight;

    public Vector3 playerResetCoords;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        movement = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

       
    }

    // Update is called once per frame
    void Update()
    {
       

        if (CameraPositioning.gameStarted == true)
        {
            DetectMovement();
            DetectJump();
        }
        
    }


    public void Restart()
    {
        GameObject drawer = GameObject.FindGameObjectWithTag("Drawer");
        LineDrawerBehavior dr = drawer.GetComponent<LineDrawerBehavior>();
        dr.Invoke("RestartLineDrawn", 0f);

        transform.position = playerResetCoords;
    //-45, -18, -5
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(new Vector2(coll.bounds.center.x, (coll.bounds.center.y - raycastHeight)), new Vector2(coll.bounds.size.x, 0.5f), 0, Vector2.down, .1f, jumpableGround);
        
    }

    void DetectJump()
    {
        
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

         
        }
    }


    public void DetectMovement()
    { 
        float xMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xMove * playerSpeed, rb.velocity.y);

        if (xMove < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (xMove > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (xMove != 0)
        {
            movement.SetBool("isRunning", true);
        }
        else
        {
            movement.SetBool("isRunning", false);
        }

    }
   
}
