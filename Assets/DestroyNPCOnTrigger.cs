using UnityEngine;

[RequireComponent(typeof(Collider))] // Memastikan ada Collider
public class DestroyNPCOnTrigger : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Tag NPC yang akan dihancurkan")]
    public string npcTag = "NPC";

    [Tooltip("Hanya bekerja sekali")]
    public bool triggerOnce = true;

    [Tooltip("Delay penghancuran (detik)")]
    public float destroyDelay = 0f;

    [Tooltip("Tampilkan debug log")]
    public bool debugMode = true;

    private bool hasTriggered = false;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cek tag dan kondisi trigger
        if (other.CompareTag(npcTag) && (!triggerOnce || !hasTriggered))
        {
            // Hancurkan NPC dengan delay
            Destroy(other.gameObject, destroyDelay);
            hasTriggered = true;

            if (debugMode)
            {
                Debug.Log($"NPC {other.name} memasuki collider - Akan dihancurkan dalam {destroyDelay} detik", other);
            }
        }
    }

    // Visualisasi area trigger di editor (opsional)
    private void OnDrawGizmosSelected()
    {
        if (!debugMode) return;

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.25f); // Warna merah transparan
            if (collider is BoxCollider)
            {
                Gizmos.DrawCube(transform.position + collider.bounds.center, collider.bounds.size);
            }
            else if (collider is SphereCollider sphereCollider)
            {
                Gizmos.DrawSphere(transform.position + sphereCollider.center, sphereCollider.radius);
            }
        }
    }
}
