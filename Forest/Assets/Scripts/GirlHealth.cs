using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirlHealth : MonoBehaviour
{
    public int maxhp;
    public float hp;
    GameObject mchpbar;
    public float invinctimer;
    public float invtime;
    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        mchpbar = GameObject.Find("mchpbar");
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mchpbar.transform.localScale = new Vector2((hp / maxhp), 0.05f);
        invinctimer -= Time.deltaTime;
        if (invinctimer > 0 && invinctimer % 0.5 < 0.25) spr.color = new Color(1, 1, 1, 0.25f);
        else spr.color = new Color(1, 1, 1, 1);
        if (hp <= 0) Destroy(gameObject);
    }
    public void hit()
    {
        if (hp <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (invinctimer < 0)
        {
            invinctimer = invtime;
            hp -= 1;
        }
    }
}
