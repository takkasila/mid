using UnityEngine;
using System.Collections;

public class SelfShadow : MonoBehaviour {

    public Vector2 offset = new Vector2(-.03f, 0.24f);
    GameObject shadowObj;
    public Material shadowMat;

    void Start()
    {
        if(!gameObject.transform.parent || gameObject.transform.parent.tag !="StaticMesh")
        { 
            shadowObj = (GameObject)Instantiate(gameObject, Vector3.zero, Quaternion.identity);
            shadowObj.transform.parent = gameObject.transform;
            shadowObj.transform.localPosition = new Vector3(offset.x, offset.y, 0.5f);

            Renderer rendr = shadowObj.GetComponent<Renderer>();
            rendr.material = shadowMat;

            PolygonCollider2D col = shadowObj.GetComponent<PolygonCollider2D>();
            col.enabled = false;
        }
    }
}
