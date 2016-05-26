using UnityEngine;
using System.Collections;

public class StableRotating : MonoBehaviour {

    public float amount = -1000;
	void Update () {
        transform.Rotate(new Vector3(0, 0, 1) * amount * Time.deltaTime);
	}
}
