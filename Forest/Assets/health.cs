using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class health : MonoBehaviour
{
    public int hp;
    GameObject hpbr;
    // Start is called before the first frame update
    void Start()
    {
        hp = 5;
        hpbr = GameObject.FindGameObjectWithTag("hpbar");
    }

    // Update is called once per frame
    void Update()
    {
        hpbr.transform.localScale = new Vector2(hp * 2, 0.5f);
    }
}
