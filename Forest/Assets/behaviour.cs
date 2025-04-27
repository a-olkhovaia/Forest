using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    GameObject player;
    public float speedchange;
    Rigidbody2D rb;
    float x;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        if (x == transform.localPosition.x) transform.localPosition = new Vector2(x, transform.localPosition.y + 0.0001f);
        x = transform.localPosition.x;
    }
    private void FixedUpdate()
    {
        if (player.transform.localPosition.x < transform.localPosition.x)
            rb.velocity = new Vector2(rb.velocity.x - speedchange, rb.velocity.y);
        else rb.velocity = new Vector2(rb.velocity.x + speedchange, rb.velocity.y);
        if (Mathf.Abs(rb.velocity.x) > 1) anim.SetBool("isrunning", true);
        else anim.SetBool("isrunning", false);
        bosscam();
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
        float dist = -Vector3.Project((transform.position - Camera.main.transform.position), Camera.main.transform.forward).z;

        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist));

        float x_left = leftBot.x + 0.5f;
        float x_right = rightTop.x - 0.5f;

        Vector3 clampedPos = transform.position;
        if (Mathf.Clamp(clampedPos.x, x_left, x_right) != clampedPos.x) rb.velocity = new Vector2(0, rb.velocity.y); ;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        transform.position = clampedPos;
    }
}
