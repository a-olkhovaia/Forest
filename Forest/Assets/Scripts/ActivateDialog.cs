using UnityEngine;

public class ActivateDialog : MonoBehaviour
{
    [SerializeField] private GameObject DialogCanvas;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (DialogCanvas != null)
        {
            if (other.tag == "Player")
            {
                DialogCanvas.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PF>().istalking = true;
            }
            var pf = other.GetComponent<PF>();
            pf.istalking = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
