using DG.Tweening;
using System.Collections;
using UnityEngine;

public class RotatingBody : MonoBehaviour
{
    private Vector3 eulerAngleVelocity;

    private IEnumerator Start()
    {
        eulerAngleVelocity = new Vector3(0, 90, 0);

        while (true)
        {
            Rotate();
            yield return new WaitForSeconds(3);
            yield return new WaitForSeconds(2);
        }
    }

    private void Rotate()
    {
        transform.DOBlendableRotateBy(eulerAngleVelocity, 3).SetEase(Ease.OutBack);
    }
}
