using UnityEngine;
using UnityEngine.UI;

public class SimpleImageDestroyer : MonoBehaviour
{
    public Image imageToDestroy;  // Drag your Image here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && imageToDestroy != null)
        {
            Destroy(imageToDestroy.gameObject);
        }
    }
}
