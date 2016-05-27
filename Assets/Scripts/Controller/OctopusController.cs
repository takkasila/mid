using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class OctopusController : NetworkBehaviour {

    public HingeJoint2D leftArm, rightArm;
    public float leftArmSpeed, rightArmSpeed;
    JointMotor2D leftMotor, rightMotor;
	void Start () {

        leftMotor = leftArm.motor;
        rightMotor = rightArm.motor;
	}

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CamFollowMother>().mother = gameObject;
    }

	void Update () {
        if (!isLocalPlayer)
            return;

        ArmMotor();
        for(int f1=0; f1<transform.childCount; f1++)
        {
            transform.GetChild(f1).SendMessage("localUpdate");
        }
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
