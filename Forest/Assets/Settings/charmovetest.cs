using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//временное решение
public class PF : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpheight;
    public Transform groundCheck;
    bool isGrounded;
    public bool moving;
    private Animator anim;
    public bool istalking;
    private float movspeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (istalking) movspeed = 0; else movspeed = Input.GetAxis("Horizontal");
        Flip();
        rb.velocity = new Vector2(movspeed * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && !istalking)
            rb.AddForce(transform.up * jumpheight, ForceMode2D.Impulse);
        moving = rb.velocity.x != 0 ? true : false;
        anim.SetBool("ismoving", moving);
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