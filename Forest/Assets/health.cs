using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public float maxhp;
    public float hp;
    GameObject hpbr;
    public float invinctimer;
    public float invtime;
    SpriteRenderer spr;
    private bool isDead = false; // Чтобы не вызывать загрузку сцены несколько раз

    void Start()
    {
        hp = maxhp;
        hpbr = GameObject.FindGameObjectWithTag("hpbar");
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        hpbr.transform.localScale = new Vector2((hp / maxhp), 0.05f);
        invinctimer -= Time.deltaTime;

        if (invinctimer > 0 && invinctimer % 0.5 < 0.25f)
            spr.color = new Color(1, 1, 1, 0.25f);
        else
            spr.color = new Color(1, 1, 1, 1);

        if (hp <= 0 && !isDead)
        {
            isDead = true;
            StartCoroutine(LoadSceneAfterDelay(0.5f)); // Запускаем корутину с задержкой 3 секунды
        }
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

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("FinishScene1"); // Замените на нужное название сцены
    }
}