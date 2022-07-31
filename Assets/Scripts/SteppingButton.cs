using UnityEngine;

public class SteppingButton : MonoBehaviour
{
    [SerializeField] private RotatingBody2 rb2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            rb2.Rotate();
        }
    }
}
