using UnityEngine;
using System.Collections;

public class FieldCounter : MonoBehaviour {

    public bool isTriggerAtFinish;
    public GameObject TargetGameObject;
    public string TriggerFunction;
    public int ThresholdToTrigger;

    public int counter = 0;

	void OnTriggerEnter2D(Collider2D col)
    {
        counter++;

        if(isTriggerAtFinish)
        {
            if(counter >=ThresholdToTrigger)
            {
                TargetGameObject.SendMessage(TriggerFunction, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
