using UnityEngine;

public class ImageDisabler : MonoBehaviour
{
    public GameObject imageObject; // Drag your Image GameObject here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && imageObject != null)
        {
            imageObject.SetActive(false);
        }
    }
}
