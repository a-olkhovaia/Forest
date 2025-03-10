using System.Collections;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private string[] lines;
    [SerializeField] private float appearSpeed;
    [SerializeField] private TextMeshProUGUI[] text = new TextMeshProUGUI[2];
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject character;
    private int idx;
    private int CurrentText;
    private void Start()
    {
        idx = 0;
        CurrentText = 0;
        text[0].text = "";
        text[1].text = "";
        gameObject.SetActive(false);
        button.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopAllCoroutines();
            NextLine(lines, text[CurrentText]);
            CurrentText = CurrentText == 1 ? 0 : 1;
        }
    }

    private IEnumerator LineByChar(string[] lines, TextMeshProUGUI text)
    {
        foreach (char c in lines[idx].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(appearSpeed);
        }
    }

    private void NextLine(string[] lines, TextMeshProUGUI text)
    {
        if (idx < lines.Length)
        {
            text.text = "";
            StartCoroutine(LineByChar(lines, text));
            idx++;
        }
        else
        {
            Destroy(gameObject);
            Destroy(button);
            var pf = character.GetComponent<PF>();
            pf.istalking = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PF>().istalking = false;
        }
    }
}
