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
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        hpbr = GameObject.FindGameObjectWithTag("hpbar");
    }

    // Update is called once per frame
    void Update()
    {
        hpbr.transform.localScale = new Vector2((hp / maxhp), 0.05f);
    }
    public void hit()
    {
          if (hp <= 0) hp = 0;
          else hp -= 1;
    }
}
