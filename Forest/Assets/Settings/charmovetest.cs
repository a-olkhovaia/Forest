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
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Flip();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(transform.up * jumpheight, ForceMode2D.Impulse);
        moving = rb.velocity.x != 0 ?true:false;
        anim.SetBool("ismoving", moving);
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}