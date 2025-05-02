using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class health : MonoBehaviour
{
    public float maxhp;
    public float hp;
    GameObject hpbr;
    public float invinctimer;
    public float invtime;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        hpbr = GameObject.FindGameObjectWithTag("hpbar");
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hpbr.transform.localScale = new Vector2((hp / maxhp), 0.05f);
        invinctimer -= Time.deltaTime;
        if (invinctimer > 0 && invinctimer % 0.5 < 0.25) spr.color = new Color(1, 1, 1, 0.25f);
        else spr.color = new Color(1, 1, 1, 1);
        if (hp <= 0) Destroy(gameObject);
    }
    public void hit()
    {
        if (hp <= 0) hp = 0;
        else if (invinctimer < 0)
        {
            invinctimer = invtime;
            hp -= 1; 
        }
    }

    //public void TakeDamage(int damage)
    //{
    //    hp -= damage;
    //}
}
