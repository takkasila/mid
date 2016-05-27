using UnityEngine;
using System.Collections;

public class CatFieldCounter : MonoBehaviour {

    public ScoreManager score;
    public int side;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Cat")
        {
            Debug.Log("Hit cat!");
            score.IncreaseScore(side);
        }
    }
}
