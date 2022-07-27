using DG.Tweening;
using System.Collections;
using UnityEngine;

public class RotatingBody2 : MonoBehaviour
{
    private Vector3 m_EulerAngleVelocity;
    private bool isClosed;

    IEnumerator WaitAndRotate()
    {
        while (true)
        {
            Rotate();
            yield return new WaitForSeconds(5);
        }
    }

    void Start()
    {
        StartCoroutine(WaitAndRotate());
    }

    private void Rotate()
    {
        m_EulerAngleVelocity = isClosed ? new(360, 0, 0) : new(270, 0, 0);
        isClosed = !isClosed;
        transform.DORotate(m_EulerAngleVelocity, 3).SetEase(Ease.OutBack);
    }
}
