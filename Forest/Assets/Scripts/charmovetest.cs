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
    public bool bossfight;

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
        if (bossfight) bosscam();
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
    void bosscam()
    {
        float dist = -Vector3.Project((transform.position - Camera.main.transform.position), Camera.main.transform.forward).z;

        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist));

        float x_left = leftBot.x + 0.5f;
        float x_right = rightTop.x - 0.5f;

        Vector3 clampedPos = transform.position;
        if (Mathf.Clamp(clampedPos.x, x_left, x_right) != clampedPos.x) rb.velocity = new Vector2(0,rb.velocity.y); ;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        transform.position = clampedPos;
    }
}