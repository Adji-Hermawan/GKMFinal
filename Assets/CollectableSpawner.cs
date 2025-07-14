using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private Collectable prefab;
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private LineRenderer LineRenderer;
    [SerializeField]
    private float PathHeightOffSet = 1.25f;
    [SerializeField]
    private float SpawnHeightOffSet = 1.5f;
    [SerializeField]
    private float PathUpdateSpeed = 0.25f;

    private Collectable ActiveInstance;
    private NavMeshTriangulation Triangulation;
    private Coroutine DrawPathCoroutine;

    private void Awake()
    {
        Triangulation = NavMesh.CalculateTriangulation();
    }

    private void Start()
    {
        SpawnNewObject();
    }

    private void SpawnNewObject()
    {
        ActiveInstance = Instantiate(prefab,
        Triangulation.vertices[Random.Range(0, Triangulation.vertices.Length)] + Vector3.up * SpawnHeightOffSet,
        Quaternion.Euler(90, 0, 0)
        );

        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathToCollectable());
        }
    }

    private IEnumerator DrawPathToCollectable()
    {
        WaitForSeconds wait = new WaitForSeconds(PathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

        while (ActiveInstance != null)
        {
            if (NavMesh.CalculatePath(Player.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
            {
                LineRenderer.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    LineRenderer.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffSet);
                }
            }
            else
            {
                Debug.LogError("Gabisa bang");
            }

            yield return wait;
        }
    }
}
