using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;


public class CatPosSync : NetworkBehaviour {

    List<GameObject> catList = new List<GameObject>();
    int count = 0;
    //void Update () {

    //    if (!isServer)
    //        return;

    //    catList.Clear();
    //    foreach (KeyValuePair<UnityEngine.Networking.NetworkInstanceId, UnityEngine.Networking.NetworkIdentity> entry in NetworkServer.objects)
    //    {
    //        if(entry.Value.gameObject.tag == "Cat")
    //            catList.Add(entry.Value.gameObject);
    //    }

    //    if(catList.Count>0)
    //    {
    //        Debug.Log("Times: " + count++);
    //        int i=0;
    //        foreach(GameObject cat in catList)
    //        {
    //            Debug.Log("Cat "+i++ +":" + cat.transform.position);
    //        }
    //    }
    //}
}
