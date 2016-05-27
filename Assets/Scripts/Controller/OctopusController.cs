using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class OctopusController : NetworkBehaviour {

    public HingeJoint2D leftArm, rightArm;
    public float leftArmSpeed, rightArmSpeed;
    JointMotor2D leftMotor, rightMotor;

    [SyncVar]
    public string CustomName;
    [SyncVar]
    public Color BodyColor;
    public List<SpriteRenderer> bodyImages;
	void Start () {

        leftMotor = leftArm.motor;
        rightMotor = rightArm.motor;
        foreach(SpriteRenderer sprite in bodyImages)
            sprite.color = BodyColor;
        foreach(GameObject staticMesh in GameObject.FindGameObjectsWithTag("StaticMesh"))
        {
            Physics2D.IgnoreCollision(staticMesh.GetComponent<Collider2D>(), leftArm.gameObject.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(staticMesh.GetComponent<Collider2D>(), rightArm.gameObject.GetComponent<Collider2D>());
        }
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
            transform.GetChild(f1).SendMessage("localUpdate", SendMessageOptions.DontRequireReceiver);
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
