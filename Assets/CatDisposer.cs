using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CatDisposer : NetworkBehaviour {

    public GameObject cat;
    public float DisposeInterval;
    float counter;
	void Start () {
        counter = DisposeInterval;
	}
	
	void Update () {
        counter -= Time.deltaTime;

        if(counter <=0)
        {
            counter = DisposeInterval;
            GameObject newCat = (GameObject)Instantiate(cat);
            newCat.transform.position = transform.position;
            NetworkServer.Spawn(newCat);
        }
	
	}
}
