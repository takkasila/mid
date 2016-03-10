using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour {

    public float duration = 5;

    void Start()
    {
        Destroy(gameObject, duration);
    }
}
