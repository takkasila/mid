using UnityEngine;
using System.Collections;

public class HingJointGrab : MonoBehaviour
{
    HingeJoint2D grabJoint;
    public KeyCode GrabKey;

    void Start()
    {
        grabJoint = gameObject.AddComponent<HingeJoint2D>();
        grabJoint.enabled = false;
    }
    void localUpdate()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (!Input.GetKey(GrabKey))
        {
            grabJoint.enabled = false;
        }
    }

    void Attach(Collision2D collidingObject) {
        if (collidingObject.gameObject.GetComponent<Rigidbody2D>() != null) {

            Vector3 collisionPoint = collidingObject.contacts[0].point;
            grabJoint.connectedBody = collidingObject.gameObject.GetComponent<Rigidbody2D>();

            Transform collidingObjectTransform = collidingObject.gameObject.transform;
            Vector3 collidingObjectLocalPosition = collidingObjectTransform.InverseTransformPoint(collisionPoint);
            Transform thisTransform = this.gameObject.transform;
            Vector3 thisLocalPosition = thisTransform.InverseTransformPoint(collisionPoint);
            grabJoint.anchor = thisLocalPosition;
            grabJoint.connectedAnchor = collidingObjectLocalPosition;            

            grabJoint.enabled = true;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (Input.GetKey(GrabKey) && !grabJoint.enabled)
        {
            Attach(col);
        }
    }
}
