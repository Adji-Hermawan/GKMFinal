using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectsOnTrigger : MonoBehaviour
{
    [Header("Objects to Activate")]
    public List<GameObject> targetObjects;

    [Header("Settings")]
    public float activationDelay = 0f;
    public bool requirePlayerTag = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!requirePlayerTag || other.CompareTag("Player"))
        {
            StartCoroutine(ActivateObjects());
        }
    }

    private IEnumerator ActivateObjects()
    {
        yield return new WaitForSeconds(activationDelay);

        foreach (var obj in targetObjects)
        {
            if (obj != null && !obj.activeSelf)
            {
                obj.SetActive(true);
            }
        }
    }
}
