using DG.Tweening;
using UnityEngine;

public class RotatingBody2 : MonoBehaviour
{
    private Vector3 m_EulerAngleVelocity;

    public void Rotate()
    {
        m_EulerAngleVelocity = new(270, 0, 0);
        transform.DORotate(m_EulerAngleVelocity, 3).SetEase(Ease.OutBack);
    }
}
