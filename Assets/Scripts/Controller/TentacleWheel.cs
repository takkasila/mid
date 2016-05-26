using UnityEngine;
using System.Collections;

public class TentacleWheel : MonoBehaviour {

    HingeJoint2D joint;
    public float rotateSpeed = 400;
    JointMotor2D moter;

	void Start () {
        // Ignore parent and parent's childrens collision
        Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>()
            , transform.GetComponent<Collider2D>());
        for(int i =0; i<transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i) == transform)
                continue;
            Physics2D.IgnoreCollision(transform.parent.GetChild(i).GetComponent<Collider2D>()
                , transform.GetComponent<Collider2D>());
        }

        joint = GetComponent<HingeJoint2D>();
        moter = joint.motor;
	}
	
	void Update () {
        MoveUpdate();
	}

    void MoveUpdate()
    {
        joint.useMotor = false;

        // Move Left
        if (Input.GetKey(KeyCode.W))
        {
            joint.useMotor = true;
            moter.motorSpeed = rotateSpeed;
            joint.motor = moter;
        }
        // Move right
        else if(Input.GetKey(KeyCode.P))
        {
            joint.useMotor = true;
            moter.motorSpeed = -rotateSpeed;
            joint.motor = moter;
        }
    }
}
