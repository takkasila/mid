﻿using UnityEngine;
using System.Collections;

public class FrictionParticle : MonoBehaviour {

    Rigidbody2D selfRb;
    public GameObject walkParticle;
    public float particleDistInterval = 0.5f;
    float pDistIntCounter;
    Vector3 oldPos;
    void Start()
    {
        selfRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
            if (col.gameObject.tag == "StaticMesh")
                Instantiate(walkParticle, contact.point, Quaternion.identity);
        }
        pDistIntCounter = 0;
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (selfRb.IsSleeping())
        {
            pDistIntCounter = 0;
            oldPos = transform.position;
        }
        else
        {
            pDistIntCounter += Mathf.Abs(Vector3.Distance(oldPos, transform.position));
            oldPos = transform.position;
            if (pDistIntCounter >= particleDistInterval)
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
