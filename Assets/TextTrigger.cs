using UnityEngine;
using TMPro; // Jangan lupa import namespace TMPro

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText; // Referensi ke TextMeshPro UI
    [SerializeField] private Collider triggerCollider; // Collider yang akan memicu

    private void OnTriggerEnter(Collider other)
    {
        // Cek jika object yang masuk memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(true);
            Debug.Log("Player entered - Text activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cek jika object yang keluar memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(false);
            Debug.Log("Player exited - Text deactivated");
        }
    }

    // Validasi referensi di Inspector
    private void OnValidate()
    {
        if (triggerCollider == null)
        {
            triggerCollider = GetComponent<Collider>();
            if (triggerCollider != null)
            {
                triggerCollider.isTrigger = true; // Pastikan collider adalah trigger
            }
        }
    }
}
