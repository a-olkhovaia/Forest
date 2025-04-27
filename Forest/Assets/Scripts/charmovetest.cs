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
        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).z;

        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        float x_left = leftBot.x;
        float x_right = rightTop.x;
        float y_top = rightTop.y;
        float y_bot = leftBot.y;

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.y = Mathf.Clamp(clampedPos.y, y_bot, y_top);
        transform.position = clampedPos;
    }
}