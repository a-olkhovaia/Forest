using UnityEngine;

public class ActivateDialog : MonoBehaviour
{
    [SerializeField] private GameObject DialogCanvas;
    [SerializeField] private GameObject Button;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (DialogCanvas != null && Button != null)
        {
            if (other.tag == "Player")
            {
                DialogCanvas.SetActive(true);
                Button.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PF>().istalking = true;
            }
            var rb = other.GetComponent<Rigidbody2D>();
            var pf = other.GetComponent<PF>();
            pf.istalking = true;
        }
    }
}
