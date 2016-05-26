using UnityEngine;
using System.Collections;

public class ForceVortex : MonoBehaviour {

    public float PushForce = 1;
    public bool GravityLike = false;
    public bool isRadiusLimit = false;

    void Update()
    {
        if (isRadiusLimit)
            return;
        else
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Movable"))
                forceVortex(obj);
    }

	void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "Movable")
            return;

        forceVortex(col.gameObject);
    }

    void forceVortex(GameObject obj)
    {
        Vector3 forceDir = obj.transform.position - transform.position;
        float totalForce = PushForce;
        if (GravityLike)
        {
            if (forceDir.magnitude > 1)
                totalForce /= Mathf.Pow(forceDir.magnitude, 2);

        }
        obj.GetComponent<ReceiveExternalForce>().AddForce(forceDir, totalForce);
    }
}
