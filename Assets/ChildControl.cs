using UnityEngine;
using System.Collections;

public class ChildControl : MonoBehaviour {

    SimpleMove smScript;
    GameObject mother;
    public float detatchDist = 6f;
    void Start()
    {
        smScript = gameObject.GetComponent<SimpleMove>();
        mother = GameObject.Find("Mother");
    }
    void Update()
    {
        if (!transform.parent || transform.parent.gameObject.name != "Mother")
        {
            smScript.enabled = false;
        }
        else
        {
            smScript.enabled = true;
            if(Mathf.Abs(Vector3.Distance(transform.position, mother.transform.position)) > detatchDist)
            {
                transform.parent = null;
            }
        }

    }
}
