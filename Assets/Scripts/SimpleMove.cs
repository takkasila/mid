using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

    Rigidbody2D selfRb;
    public Vector2 moveForce;
    public GameObject walkParticle;
    public float particleDistInterval = 0.5f;
    float pDistIntCounter;
    Vector3 oldPos;
	void Start () {
        selfRb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        SimpleControl();
	}

    void SimpleControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selfRb.AddForce(Vector3.left * moveForce.x, ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selfRb.AddForce(Vector3.right * moveForce.x, ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selfRb.AddForce(Vector3.up * moveForce.y, ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selfRb.AddForce(Vector3.down * moveForce.y, ForceMode2D.Force);
        }

        if(transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach(ContactPoint2D contact in col.contacts)
        {
            if(col.gameObject.tag == "StaticMesh")
                Instantiate(walkParticle, contact.point, Quaternion.identity);
        }
        pDistIntCounter = 0;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(selfRb.IsSleeping())
        {
            pDistIntCounter = 0;
            oldPos = transform.position;
        }
        else
        {
            pDistIntCounter += Mathf.Abs(Vector3.Distance(oldPos, transform.position));
            oldPos = transform.position;
            if(pDistIntCounter>=particleDistInterval)
            {
                foreach (ContactPoint2D contact in col.contacts)
                {
                    if (col.gameObject.tag == "StaticMesh")
                        Instantiate(walkParticle, contact.point, Quaternion.identity);
                }
                pDistIntCounter = 0;
            }
        }
    }
}
