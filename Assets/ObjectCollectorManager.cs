using UnityEngine;
using UnityEngine.Playables; // Untuk timeline

public class ObjectCollectorManager : MonoBehaviour
{
    [Header("Collection Settings")]
    [Tooltip("Tag untuk object yang perlu dikumpulkan")]
    public string collectibleTag = "QuestItem";

    [Header("Timeline Settings")]
    [Tooltip("Timeline yang akan diputar ketika semua object terkumpul")]
    public PlayableDirector timelineToPlay;

    [Header("UI Settings")]
    [Tooltip("Text UI untuk menampilkan progress (optional)")]
    public UnityEngine.UI.Text progressText;

    private int totalCollectibles;
    private int collectedCount = 0;

    private void Start()
    {
        // Hitung total object dengan tag yang ditentukan
        totalCollectibles = GameObject.FindGameObjectsWithTag(collectibleTag).Length;
        UpdateProgressUI();
    }

    // Dipanggil ketika object di-destroy (attach ke script DestroyBendera)
    public void OnObjectCollected(GameObject activatedObject)
    {
        collectedCount++;
        UpdateProgressUI();

        // Cek jika semua object terkumpul
        if (collectedCount >= totalCollectibles)
        {
            PlayTimeline();
        }
    }

    private void UpdateProgressUI()
    {
        if (progressText != null)
        {
            progressText.text = $"{collectedCount}/{totalCollectibles}";
        }
    }

    private void PlayTimeline()
    {
        if (timelineToPlay != null)
        {
            timelineToPlay.Play();
        }
        else
        {
            Debug.LogWarning("Timeline reference belum di-set!");
        }
    }
}
