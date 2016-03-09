using UnityEngine;
using System.Collections;

public class ForceVortex : MonoBehaviour {

    public bool GravityLike = false;
    public float ForceAtCenter;
    float outterRadius;

	void Start () {
        outterRadius = GetComponent<CircleCollider2D>().radius;
	}

	void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "Movable")
            return;

        Vector3 forceDir = col.gameObject.transform.position - transform.position;
        float totalForce = ForceAtCenter;
        if (GravityLike)
            totalForce /= Mathf.Pow(forceDir.magnitude, 2);
        col.gameObject.GetComponent<ExternalForce>().AddForce(forceDir, totalForce);
    }
}
