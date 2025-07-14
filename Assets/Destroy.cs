using UnityEngine;
using UnityEngine.UI;
public class Destroy : MonoBehaviour
{
    [Header("Object Settings")]
    [Tooltip("Object yang akan diaktifkan ketika barang dihancurkan")]
    public GameObject objectToActivate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Image Settings")]
    [Tooltip("Image yang akan dihancurkan bersamaan dengan barang")]
    public Image imageToDestroy; // Reference to the image to destroy
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("QuestItem"))
        {
            Destroy(other.gameObject);
            // Destroy the selected image if it's assigned
            if (imageToDestroy != null)
            {
                Destroy(imageToDestroy.gameObject);
            }
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            // Beritahu manager bahwa object dikumpulkan
            FindObjectOfType<ObjectCollectorManager>().OnObjectCollected(objectToActivate);
        }
    }
}