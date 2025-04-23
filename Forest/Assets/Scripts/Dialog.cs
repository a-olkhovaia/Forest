using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Line[] lines;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float appearSpeed;
    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject ButtonPanel;
    private int idx = 0;

    private void OnEnable()
    {
        ButtonPanel.SetActive(true);
    }

    private void Start()
    {
        gameObject.SetActive(false);
        ButtonPanel.SetActive(false);
        text.text = "";
        nameText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopAllCoroutines();
            text.text = "";
            NextLine();
        }
    }

    private IEnumerator LineByChar()
    {
        ButtonPanel.SetActive(false);
        foreach (char c in lines[idx].line)
        {
            text.text += c;
            yield return new WaitForSeconds(appearSpeed);
        }
        ButtonPanel.SetActive(true);
    }

    private void NextLine()
    {
        if (idx < lines.Length)
        {
            text.text = string.Empty;

            var speaker = lines[idx].speaker;

            portrait = speaker.portrait;
            nameText.text = speaker.name;

            StartCoroutine(LineByChar());
            idx++;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PF>().istalking = false;
            gameObject.SetActive(false);
        }
    }
}

[Serializable]
public class Line
{
    [SerializeField] public Speaker speaker;
    [SerializeField] public string line;
}

[Serializable]
public class Speaker
{
    [SerializeField] public string name;
    [SerializeField] public Image portrait;
}