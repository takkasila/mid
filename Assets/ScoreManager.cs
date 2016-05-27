using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text LeftField, RightField;

    public void IncreaseScore(int side)
    {
        switch(side)
        {
            case 0:
                LeftField.text = (int.Parse(LeftField.text) + 1).ToString();
                break;
            case 1:
                RightField.text = (int.Parse(LeftField.text) + 1).ToString();
                break;
        }
    }
}
