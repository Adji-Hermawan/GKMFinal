using UnityEngine;
using UnityEngine.AI;

public class pemudafollow : MonoBehaviour
{
    public NavMeshAgent pemuda;
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pemuda.SetDestination(player.position);
    }
}
