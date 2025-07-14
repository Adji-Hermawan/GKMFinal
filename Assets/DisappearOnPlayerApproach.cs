using UnityEngine;

public class DisappearOnPlayerApproach : MonoBehaviour
{
    [Header("Settings")]
    public float detectionRadius = 3f; // Jarak deteksi
    public GameObject objectToDisappear; // Objek yang akan hilang
    public GameObject imageToDisappear; // Image UI yang akan hilang

    [Header("Debug")]
    public bool debugMode = true;
    public Color gizmoColor = Color.red;

    private GameObject player;
    private bool hasDisappeared = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Tidak ada GameObject dengan tag 'Player' di scene!");
        }
    }

    void Update()
    {
        if (player != null && !hasDisappeared)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= detectionRadius)
            {
                DisableObjects();
            }



        }
    }


    void DisableObjects()
    {
        if (objectToDisappear != null)
        {
            objectToDisappear.SetActive(false);
        }

        if (imageToDisappear != null)
        {
            imageToDisappear.SetActive(false);
        }

        hasDisappeared = true;

        Debug.Log("Player mendekat - objek dinonaktifkan");
    }

    // Untuk visualisasi radius di editor
    void OnDrawGizmosSelected()
    {
        if (debugMode)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
