using DG.Tweening;
using UnityEngine;

public class SteppingButton : MonoBehaviour
{
    [SerializeField] private RotatingBody2 rb2;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            rb2.Rotate();
            transform.DOLocalMoveY(-0.14f, .5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            transform.DOLocalMoveY(0f, .5f);
        }
    }
}
