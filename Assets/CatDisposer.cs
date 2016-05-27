using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class CatDisposer : NetworkBehaviour {

    public GameObject cat;
    public float DisposeInterval = 10;
    float counter;
	void Start () {
        counter = DisposeInterval;
	}
	
	void Update () {
        counter -= Time.deltaTime;

        if(counter <=0)
        {
            counter = DisposeInterval;
            CmdSpawnCat();
            
        }
	}
    
    [Command]
    void CmdSpawnCat()
    {
        GameObject newCat = (GameObject)Instantiate(cat);
        newCat.transform.position = transform.position;
        NetworkServer.Spawn(newCat);
    }
}
