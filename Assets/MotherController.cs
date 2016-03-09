using UnityEngine;
using System.Collections;

public class MotherController : MonoBehaviour {

    public GameObject child;
    float offsetSpawn;
	void Start () {
        offsetSpawn = transform.lossyScale.y;
	}
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(child, transform.position + Vector3.up * offsetSpawn, Quaternion.identity);
        }
	
	}
}
