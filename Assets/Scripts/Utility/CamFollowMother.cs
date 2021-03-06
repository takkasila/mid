﻿using UnityEngine;
using System.Collections;

public class CamFollowMother : MonoBehaviour {

    public GameObject mother;
    public float lerpScale = 0.3f;

	void Update () {
        if (!mother)
            return;
        Vector3 lerpPos = Vector3.Lerp(transform.position, mother.transform.position, lerpScale);
        transform.position = new Vector3(lerpPos.x, lerpPos.y, transform.position.z);
	}
}
