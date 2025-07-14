using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SimpleButtonSpaceTrigger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Button>().interactable)
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
