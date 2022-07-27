using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    //[SerializeField] private Rigidbody rotatingBody;

    //Rigidbody m_Rigidbody;
    //Vector3 m_EulerAngleVelocity;

    //void Start()
    //{
    //    //Fetch the Rigidbody from the GameObject with this script attached
    //    m_Rigidbody = GetComponent<Rigidbody>();

    //    //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
    //    m_EulerAngleVelocity = new Vector3(0, 100, 0);
    //}

    //void FixedUpdate()
    //{
    //    Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
    //    rotatingBody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("triggered");
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("player");
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
