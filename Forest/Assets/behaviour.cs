using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    GameObject player;
    public float speedchange;
    Rigidbody2D rb;
    float x;
    private Animator anim;
    public float timer;
    float dist;
    Vector3 leftBot;
    Vector3 rightTop;
    bool goright;
    float xleft;
    float xright;
    bool locked;
    public float stunned;
    public float stuntime;
    public float stunspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        rb.velocity = new Vector2(-25, rb.velocity.y);
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        dist = -Vector3.Project((transform.position - Camera.main.transform.position), Camera.main.transform.forward).z;
        leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
        rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist));
        xleft = leftBot.x + 0.5f;
        xright = rightTop.x - 0.5f;
        if (timer <= 0) timer = 30;
        Flip();
        if (x == transform.localPosition.x) transform.localPosition = new Vector2(x, transform.localPosition.y + 0.0001f);
        x = transform.localPosition.x;
        if (Mathf.Abs(timer - 30) < Time.fixedDeltaTime)
            if (rb.velocity.x < 0) goright = false;
            else goright = true;
        if (Mathf.Abs(xleft - transform.position.x) < 2) goright = true;
        else if (Mathf.Abs(xright - transform.position.x) < 2) goright = false;
        if (timer < 29) locked = true;
        stunned -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (stunned > 0) ;
        else if (timer < 13)
            if (goright) rb.velocity = new Vector2(rb.velocity.x + speedchange, rb.velocity.y);
            else rb.velocity = new Vector2(rb.velocity.x - speedchange, rb.velocity.y);
        else if (timer <= 26)
            if (player.transform.localPosition.x < transform.localPosition.x)
                rb.velocity = new Vector2(rb.velocity.x - speedchange, rb.velocity.y);
            else rb.velocity = new Vector2(rb.velocity.x + speedchange, rb.velocity.y);
        else stunned = 0.1f;
        if (stunned > 0 && locked) rb.velocity /= 2;
        if (Mathf.Abs(rb.velocity.x) > 1) anim.SetBool("isrunning", true);
        else anim.SetBool("isrunning", false);
        if (locked) bosscam();
        timer -= Time.fixedDeltaTime;
    }
    void Flip()
    {
        if (rb.velocity.x > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (rb.velocity.x < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void bosscam()
    {
        Vector3 clampedPos = transform.position;
        if (Mathf.Clamp(clampedPos.x, xleft, xright) != clampedPos.x)
        {
            if (Mathf.Abs(rb.velocity.x) > stunspeed) stunned = stuntime;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        clampedPos.x = Mathf.Clamp(clampedPos.x, xleft, xright);
        transform.position = clampedPos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.GetComponent<GirlHealth>().hit();
    }
}
