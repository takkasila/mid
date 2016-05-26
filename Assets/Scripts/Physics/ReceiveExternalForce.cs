using UnityEngine;
using System.Collections;

public class ReceiveExternalForce : MonoBehaviour {

    Rigidbody2D selfRb;
    void Start()
    {
        selfRb = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector2 dir, float amount)
    {
        selfRb.AddForce(dir.normalized * amount, ForceMode2D.Force);
    }
}
