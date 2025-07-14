using UnityEngine;

public class DestroyAndActivateOnEPress : MonoBehaviour
{
    [Header("Object Settings")]
    public GameObject objectToDestroy;  // Object yang akan dihancurkan
    public GameObject objectToActivate; // Object yang akan diaktifkan

    [Header("Trigger Settings")]
    public float destroyDelay = 0f;     // Jeda sebelum menghancurkan (detik)
    public bool requireKeyPress = true; // Harus tekan E atau otomatis?
    public bool showDebugMessages = true;

    private bool isPlayerInTrigger = false;

    void Update()
    {
        // Jika perlu penekanan tombol E dan player di dalam trigger
        if (isPlayerInTrigger && (!requireKeyPress || Input.GetKeyDown(KeyCode.E)))
        {
            ExecuteInteraction();
        }
    }

    private void ExecuteInteraction()
    {
        // Aktifkan object tujuan
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            if (showDebugMessages)
                Debug.Log($"Mengaktifkan {objectToActivate.name}");
        }

        // Hancurkan object
        if (objectToDestroy != null)
        {
            if (destroyDelay <= 0)
            {
                Destroy(objectToDestroy);
                if (showDebugMessages)
                    Debug.Log($"Menghancurkan {objectToDestroy.name}");
            }
            else
            {
                Destroy(objectToDestroy, destroyDelay);
                if (showDebugMessages)
                    Debug.Log($"Akan menghancurkan {objectToDestroy.name} dalam {destroyDelay} detik");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;

            if (!requireKeyPress)
            {
                ExecuteInteraction();
            }
            else if (showDebugMessages)
            {
                Debug.Log("Player masuk area - Tekan E untuk interaksi");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (showDebugMessages)
                Debug.Log("Player keluar area");
        }
    }
}
