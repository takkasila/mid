using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

    Rigidbody2D selfRb;
    public float moveForce = 10;
    public GameObject walkParticle;
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
            selfRb.AddForce(Vector3.left * moveForce, ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selfRb.AddForce(Vector3.right * moveForce, ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selfRb.AddForce(Vector3.up * moveForce, ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selfRb.AddForce(Vector3.down * moveForce, ForceMode2D.Force);
        }

        if(transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "StaticMesh")
            Instantiate(walkParticle, transform.position + Vector3.down*.2f, Quaternion.identity);
    }
}
