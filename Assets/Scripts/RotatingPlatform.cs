using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private NavMeshSurface surface;

    private void Start()
    {
        surface = GetComponentInParent<NavMeshSurface>();
    }

    //float onMeshThreshold = 3;

    //public bool IsAgentOnNavMesh(GameObject agentObject)
    //{
    //    Vector3 agentPosition = agentObject.transform.position;

    //    // Check for nearest point on navmesh to agent, within onMeshThreshold
    //    if (NavMesh.SamplePosition(agentPosition, out NavMeshHit hit, onMeshThreshold, NavMesh.AllAreas))
    //    {
    //        // Check if the positions are vertically aligned
    //        if (Mathf.Approximately(agentPosition.x, hit.position.x)
    //            && Mathf.Approximately(agentPosition.z, hit.position.z))
    //        {
    //            // Lastly, check if object is below navmesh
    //            return agentPosition.y >= hit.position.y;
    //        }
    //    }

    //    return false;
    //}

    //private void Update()
    //{
    //    if (!IsAgentOnNavMesh(agent.gameObject))
    //    {
    //        ClearNavmesh();
    //    }
    //}

    private void ClearNavmesh()
    {
        surface.RemoveData();
    }

    private void RebakeNavMesh()
    {
        surface.BuildNavMesh();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("triggered");
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("player");
            //RebakeNavMesh();
            //collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            //ClearNavmesh();
            //collision.gameObject.transform.parent = null;
        }
    }
}
