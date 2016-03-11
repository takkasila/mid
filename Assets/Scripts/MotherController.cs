using UnityEngine;
using System.Collections;

public class MotherController : MonoBehaviour {

    public GameObject child;
    float offsetSpawn;
    Vector3 groupCenter;
    public float searchRadius = 2;
	void Start () {
        offsetSpawn = transform.lossyScale.y;
	}
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ch = (GameObject) Instantiate(child, transform.position + Vector3.up * offsetSpawn, Quaternion.identity);
            ch.transform.parent = gameObject.transform;
        }
        groupCenter = Vector3.zero;
        for(int f1=0; f1< transform.childCount; f1++)
        {
            groupCenter += transform.GetChild(f1).transform.position;
        }
        groupCenter += 10 * transform.position;
        groupCenter /= (transform.childCount+10);

        SearchNearbyChild();
	}

    void SearchNearbyChild()
    {
        var gs = GameObject.FindGameObjectsWithTag("Movable");
        
        for(int f1=0;f1<gs.Length;f1++)
        {
            if(gs[f1].name == "Child(Clone)" && (!gs[f1].transform.parent || gs[f1].transform.parent != this.gameObject))
            {
                if(Mathf.Abs(Vector3.Distance(transform.position, gs[f1].transform.position))<=searchRadius)
                {
                    gs[f1].transform.parent = transform;
                }
            }
        }
    }

    public Vector3 getCenterPos()
    {
        return groupCenter;
    }
}


