using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyBendera : MonoBehaviour
{
    [Header("Object Settings")]
    [Tooltip("Object yang akan diaktifkan ketika barang dihancurkan")]
    public GameObject objectToActivate;

    [Header("Image Settings")]
    [Tooltip("Image yang akan dinonaktifkan bersamaan dengan barang")]
    public Image imageToDestroy; // Reference to the image to deactivate

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("barang"))
        {
            Destroy(other.gameObject);

            // Nonaktifkan image jika sudah ditentukan
            if (imageToDestroy != null)
            {
                imageToDestroy.gameObject.SetActive(false);
            }

            // Aktifkan object yang ditentukan
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // Beritahu manager bahwa object dikumpulkan
            FindObjectOfType<ObjectCollectorManager>().OnObjectCollected(objectToActivate);
        }
    }
}
