using DG.Tweening;
using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class RotatingBody : MonoBehaviour
{
    private Vector3 eulerAngleVelocity;
    [SerializeField] private NavMeshSurface surface;

    private IEnumerator Start()
    {
        eulerAngleVelocity = new Vector3(0, 90, 0);
        //surface = GetComponent<NavMeshSurface>();

        while (true)
        {
            Rotate();
            //ClearNavmesh();
            yield return new WaitForSeconds(3);
            //RebakeNavMesh();
            yield return new WaitForSeconds(2);
        }
    }

    private void Rotate()
    {
        transform.DOBlendableRotateBy(eulerAngleVelocity, 3).SetEase(Ease.OutBack);
    }

    private void ClearNavmesh()
    {
        surface.RemoveData();
    }

    private void RebakeNavMesh()
    {
        surface.BuildNavMesh();
    }
}
