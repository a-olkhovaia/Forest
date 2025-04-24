using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class PF : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isGrounded;
    public float CheckRadius;
    public LayerMask whatIsGround;
    public Transform feetPos;

    public float speed;
    public float jumpHeight;

    public bool moving;
    private Animator anim;
    public bool istalking;
    private float movspeed;

    private int jumpCount;         
    public int maxJumps = 2;       

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);

        
        if (isGrounded)
        {
            jumpCount = 0;
        }

        
        if (istalking)
        {
            movspeed = 0;
        }
        else
        {
            movspeed = Input.GetAxis("Horizontal");
        }

        Flip();

        rb.velocity = new Vector2(movspeed * speed, rb.velocity.y);

        
        if (Input.GetKeyDown(KeyCode.Space) && !istalking && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight); 
            jumpCount++; 
        }

        
        moving = rb.velocity.x != 0 ? true : false;
        anim.SetBool("ismoving", moving);
        anim.SetBool("IsJumping", !isGrounded);
    }

    void Flip()
    {
        if (movspeed > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (movspeed < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent = null;
    }
}