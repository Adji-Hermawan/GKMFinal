using UnityEngine;
using UnityEngine.Playables; // Required for timeline control

public class TimelineTrigger : MonoBehaviour
{
    [Header("Timeline Control")]
    [Tooltip("The timeline to activate")]
    public PlayableDirector timelineToActivate;

    [Header("Objects to Disable")]
    [Tooltip("List of objects to deactivate")]
    public GameObject[] objectsToDisable;

    [Header("Settings")]
    [Tooltip("Should this trigger only work once?")]
    public bool triggerOnce = true;

    private bool alreadyTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (!triggerOnce || !alreadyTriggered))
        {
            // Activate the timeline if assigned
            if (timelineToActivate != null)
            {
                timelineToActivate.gameObject.SetActive(true);
                timelineToActivate.Play();
            }
            else
            {
                Debug.LogWarning("No timeline assigned!", this);
            }

            // Deactivate all specified objects
            foreach (GameObject obj in objectsToDisable)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }

            alreadyTriggered = true;

            Debug.Log("Trigger activated - Timeline started");
        }
    }

    // Optional: Draw gizmo in editor for visualization
    private void OnDrawGizmos()
    {
        if (GetComponent<Collider>() != null)
        {
            Gizmos.color = new Color(0.2f, 0.8f, 0.2f, 0.3f);
            Gizmos.DrawCube(transform.position + GetComponent<Collider>().bounds.center,
                          GetComponent<Collider>().bounds.size);
        }
    }
}
