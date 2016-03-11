using UnityEngine;
using System.Collections;

public class CamFollowGroup : MonoBehaviour {

    public MotherController mother;
    public float lerpScale = 0.3f;
	
	void Update () {
        Vector3 lerpPos = Vector3.Lerp(transform.position, mother.getCenterPos(), lerpScale);
        transform.position = new Vector3(lerpPos.x, lerpPos.y, transform.position.z);
	}
}
