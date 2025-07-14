using UnityEngine;

[RequireComponent(typeof(Collider))] // Memastikan ada Collider
public class ActivateOnPlayerTrigger : MonoBehaviour
{
    [Header("Target Objects")]
    [Tooltip("GameObjects yang akan diaktifkan saat trigger")]
    [SerializeField] private GameObject[] objectsToActivate; // Menggunakan array untuk beberapa objek

    [Header("Trigger Settings")]
    [Tooltip("Tag yang memicu (default 'Player')")]
    [SerializeField] private string triggerTag = "Player";

    [Tooltip("Hanya bekerja sekali")]
    [SerializeField] private bool triggerOnce = true;

    [Tooltip("Delay sebelum aktivasi (detik)")]
    [SerializeField] private float activationDelay = 0f;

    [Tooltip("Tampilkan debug info")]
    [SerializeField] private bool debugMode = true;

    private bool hasTriggered = false;

    private void Awake()
    {
        // Pastikan collider adalah trigger
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered || !triggerOnce) // Cek kondisi trigger
        {
            if (other.CompareTag(triggerTag)) // Cek tag
            {
                if (activationDelay > 0)
                {
                    Invoke(nameof(ActivateObjects), activationDelay);
                }
                else
                {
                    ActivateObjects();
                }

                hasTriggered = true;

                if (debugMode)
                    Debug.Log($"Player triggered at {Time.time}");
            }
        }
    }

    private void ActivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
                if (debugMode)
                    Debug.Log($"Activated object: {obj.name}");
            }
            else if (debugMode)
            {
                Debug.LogWarning("No object assigned to activate!", this);
            }
        }
    }

    // Visualisasi trigger area di editor
    private void OnDrawGizmos()
    {
        if (debugMode)
        {
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                Gizmos.color = Color.green;
                Matrix4x4 oldMatrix = Gizmos.matrix;
                Gizmos.matrix = transform.localToWorldMatrix;

                if (collider is BoxCollider box)
                {
                    Gizmos.DrawWireCube(box.center, box.size);
                }
                else if (collider is SphereCollider sphere)
                {
                    Gizmos.DrawWireSphere(sphere.center, sphere.radius);
                }

                Gizmos.matrix = oldMatrix;
            }
        }
    }
}
