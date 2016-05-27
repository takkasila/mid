using UnityEngine;
using System.Collections;

public class SelfShadow : MonoBehaviour {

    public Vector2 offset = new Vector2(-.03f, 0.24f);
    GameObject shadowObj;
    public Material shadowMat;

    void Start()
    {
        shadowObj = (GameObject)Instantiate(gameObject, Vector3.zero, Quaternion.identity);
        shadowObj.transform.parent = gameObject.transform;
        shadowObj.transform.localPosition = new Vector3(offset.x, offset.y, 0.5f);
        shadowObj.transform.localScale = new Vector3(1, 1, 1);

        Renderer rendr = shadowObj.GetComponent<Renderer>();
        rendr.material = shadowMat;

        PolygonCollider2D col = shadowObj.GetComponent<PolygonCollider2D>();
        col.enabled = false;
        shadowObj.GetComponent<SelfShadow>().enabled = false;
    }
}
