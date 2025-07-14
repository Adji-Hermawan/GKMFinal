using UnityEngine;
using UnityEngine.Playables;
public class ActivateTimelineOnTrigger : MonoBehaviour
{
    public PlayableDirector timelineDirector; // Assign timeline PlayableDirector in Inspector
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (timelineDirector != null)
            {
                timelineDirector.Play();
            }
        }
    }
}
