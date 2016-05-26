using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SimpleMove : MonoBehaviour
{
    Rigidbody2D selfRb;
    public Vector2 moveForce;
    bool onGround = false;
    float jumpVel;
    void Start()
    {
        selfRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        SimpleControl();
        UpdateJump();
    }

    void SimpleControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveForce.x * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveForce.x * Time.deltaTime, Space.World);
        }

        // Jump
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(onGround)
            {
                onGround = false;
                jumpVel = moveForce.y;
            }
        }
    }

    void UpdateJump()
    {
        if(jumpVel > 0)
        {
            transform.Translate(Vector3.up * jumpVel * Time.deltaTime, Space.World);
            jumpVel += Physics.gravity.y * Time.deltaTime;
            if (jumpVel < 0)
                jumpVel = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "StaticMesh")
            onGround = true;
    }

}