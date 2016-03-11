using UnityEngine;
using System.Collections;

public class ChildControl : MonoBehaviour {

    SimpleMove smScript;

    void Start()
    {
        smScript = gameObject.GetComponent<SimpleMove>();
    }
    void Update()
    {
        if (!transform.parent)
            smScript.enabled = false;
        else
            smScript.enabled = true;
    }
}
