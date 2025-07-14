using UnityEngine;

public class CollectableItemBendera : MonoBehaviour
{
    [Header("Settings")]
    public string itemType = "Bendera";
    public int quantity = 1;
    public ParticleSystem collectEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("QuestItem"))
        {
            // Cari QuestSystem dan panggil CollectItem
            QuestSystem questSystem = FindObjectOfType<QuestSystem>();
            if (questSystem != null)
            {
                questSystem.CollectItem(quantity);
            }

            // Efek visual
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}