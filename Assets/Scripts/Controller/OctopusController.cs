using UnityEngine;
using System.Collections;

public class OctopusController : MonoBehaviour {

    public HingeJoint2D leftArm, rightArm;
    public float leftArmSpeed, rightArmSpeed;
    JointMotor2D leftMotor, rightMotor;
	// Use this for initialization
	void Start () {
        leftMotor = leftArm.motor;
        rightMotor = rightArm.motor;
	}
	
	// Update is called once per frame
	void Update () {
        ArmMotor();
	
	}

    void ArmMotor()
    {
        leftArm.useMotor = false;
        rightArm.useMotor = false;

        if(Input.GetKey(KeyCode.R))
        {
            leftArm.useMotor = true;
            leftMotor.motorSpeed = leftArmSpeed;
            leftArm.motor = leftMotor;
        }
        else if(Input.GetKey(KeyCode.F))
        {
            leftArm.useMotor = true;
            leftMotor.motorSpeed = -leftArmSpeed;
            leftArm.motor = leftMotor;
        }

        if(Input.GetKey(KeyCode.I))
        {
            rightArm.useMotor = true;
            rightMotor.motorSpeed = -rightArmSpeed;
            rightArm.motor = rightMotor;
        }
        else if(Input.GetKey(KeyCode.J))
        {
            rightArm.useMotor = true;
            rightMotor.motorSpeed = rightArmSpeed;
            rightArm.motor = rightMotor;
        }
    }
}
