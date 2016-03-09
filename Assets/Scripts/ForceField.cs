using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour {

    public Vector2 ForceDir;
    public float ForceAmount;

    void Start()
    {
        ForceDir = ForceDir.normalized;
    }
	void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag=="Movable")
        {
            col.gameObject.GetComponent<ExternalForce>().AddForce(ForceDir, ForceAmount);
        }
    }

}
