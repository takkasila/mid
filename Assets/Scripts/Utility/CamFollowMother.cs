using UnityEngine;
using System.Collections;

public class CamFollowMother : MonoBehaviour {

    GameObject mother;
    public float lerpScale = 0.3f;
	void Start()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            mother = obj;
        }
    }
	void Update () {
        if (!mother)
            mother = GameObject.FindGameObjectWithTag("Player");
        Vector3 lerpPos = Vector3.Lerp(transform.position, mother.transform.position, lerpScale);
        transform.position = new Vector3(lerpPos.x, lerpPos.y, transform.position.z);
	}
}
