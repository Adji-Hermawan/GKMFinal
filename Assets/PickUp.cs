using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Header("Settings")]
    public float pickupDistance = 2f; // Jarak pickup
    public KeyCode dropKey = KeyCode.E; // Tombol untuk melepas
    public Transform itemAnchor; // Referensi ke GameObject anchor

    private bool isPickedUp = false;
    private Transform playerTransform;
    private Rigidbody rb;
    private Collider itemCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        itemCollider = GetComponent<Collider>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Jika itemAnchor tidak diatur, cari GameObject anchor di dalam pemain
        if (itemAnchor == null)
        {
            itemAnchor = playerTransform.Find("ItemAnchor");
        }
    }

    void Update()
    {
        // Cek jika item diambil atau dilepas
        if (Input.GetKeyDown(dropKey))
        {
            if (isPickedUp)
            {
                DetachFromPlayer();
            }
            else
            {
                // Cek jarak antara item dan player
                float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
                if (distanceToPlayer <= pickupDistance)
                {
                    AttachToPlayer();
                }
            }
        }
    }

    void AttachToPlayer()
    {
        isPickedUp = true;

        // Matikan physics sementara
        if (rb != null) rb.isKinematic = true;
        if (itemCollider != null) itemCollider.enabled = false;

        // Set sebagai child dari player
        transform.SetParent(itemAnchor); // Menggunakan itemAnchor sebagai parent
        transform.localPosition = Vector3.zero; // Posisi tengah anchor
        transform.localRotation = Quaternion.identity; // Reset rotasi
    }

    void DetachFromPlayer()
    {
        isPickedUp = false;

        // Lepaskan dari parent
        transform.SetParent(null);

        // Hidupkan kembali physics
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(playerTransform.forward * 2f, ForceMode.Impulse); // Lempar sedikit ke depan
        }

        if (itemCollider != null) itemCollider.enabled = true;
    }

    // Visualisasi jarak pickup di editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupDistance);
    }
}
