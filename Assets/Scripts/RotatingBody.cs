using DG.Tweening;
using System.Collections;
using UnityEngine;

public class RotatingBody : MonoBehaviour
{
    Vector3 m_EulerAngleVelocity;

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
        m_EulerAngleVelocity = new Vector3(0, 90, 0);
        StartCoroutine(WaitAndRotate());
    }

    private void Rotate()
    {
        transform.DOBlendableRotateBy(m_EulerAngleVelocity, 3).SetEase(Ease.OutBack);
    }
}
