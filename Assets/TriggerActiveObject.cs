using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerActivateObject : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The GameObject to activate when triggered")]
    [SerializeField] private GameObject objectToActivate;
    
    [Tooltip("Set to true if you want to deactivate the object after leaving the trigger")]
    [SerializeField] private bool deactivateOnExit = false;
    
    [Tooltip("Set to true if you only want to trigger once")]
    [SerializeField] private bool triggerOnce = false;
    
    [Tooltip("Layer mask to filter what can trigger this")]
    [SerializeField] private LayerMask triggerLayerMask = ~0; // Default to all layers
    
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if trigger is enabled and matches layer mask
        if ((triggerLayerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            // Check if we should trigger only once
            if (!triggerOnce || (triggerOnce && !hasTriggered))
            {
                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true);
                    hasTriggered = true;
                }
                else
                {
                    Debug.LogWarning("No GameObject assigned to activate in " + gameObject.name);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If deactivate on exit is enabled and layer matches
        if (deactivateOnExit && (triggerLayerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false);
            }
        }
    }

    // Quick validation in editor
    private void OnValidate()
    {
        // Make sure the collider is set as trigger
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }
}