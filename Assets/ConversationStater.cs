using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStater : MonoBehaviour
{
    [SerializeField] private NPCConversation myConvertation;
    public GameObject gameobj;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConvertation);
            }

            if (gameobj != null)
            {
                gameobj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No GameObject assigned to disappear");
            }
        }
    }
}
