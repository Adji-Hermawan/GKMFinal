using UnityEngine;
using UnityEngine.UI;

public class QuestItemCollector : MonoBehaviour
{
    [Header("Collection Settings")]
    [Tooltip("GameObjects dengan tag ini akan dikumpulkan")]
    public string collectableTag = "QuestItem";

    [Header("Objects to Activate")]
    [Tooltip("GameObjects yang akan diaktifkan satu per satu")]
    public GameObject[] objectsToActivate;

    [Header("Images to Deactivate")]
    [Tooltip("Images yang akan dinonaktifkan satu per satu")]
    public Image[] imagesToDeactivate;

    [Header("Effects")]
    public ParticleSystem collectEffect;

    private int currentIndex = 0;
    private GameObject[] collectedItems; // Untuk menyimpan item yang sudah dikumpulkan

    private void Start()
    {
        // Inisialisasi array untuk menyimpan item yang dikumpulkan
        collectedItems = new GameObject[objectsToActivate.Length];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(collectableTag) && currentIndex < objectsToActivate.Length)
        {
            // Simpan reference ke item yang dikumpulkan
            collectedItems[currentIndex] = other.gameObject;

            // Nonaktifkan item yang dikumpulkan (bukan destroy)
            other.gameObject.SetActive(false);

            // Efek koleksi
            if (collectEffect != null)
            {
                Instantiate(collectEffect, other.transform.position, Quaternion.identity);
            }

            // Aktifkan GameObject terkait
            if (objectsToActivate[currentIndex] != null)
            {
                objectsToActivate[currentIndex].SetActive(true);
            }

            // Nonaktifkan Image terkait
            if (currentIndex < imagesToDeactivate.Length &&
                imagesToDeactivate[currentIndex] != null)
            {
                imagesToDeactivate[currentIndex].gameObject.SetActive(false);
            }

            currentIndex++;
        }
    }

    public void ResetCollection()
    {
        currentIndex = 0;

        // Nonaktifkan semua objects yang diaktifkan
        foreach (var obj in objectsToActivate)
        {
            if (obj != null) obj.SetActive(false);
        }

        // Aktifkan semua images
        foreach (var img in imagesToDeactivate)
        {
            if (img != null) img.gameObject.SetActive(true);
        }

        // Aktifkan kembali semua item yang dikumpulkan
        foreach (var item in collectedItems)
        {
            if (item != null) item.SetActive(true);
        }

        // Reset array collectedItems
        collectedItems = new GameObject[objectsToActivate.Length];
    }
}
