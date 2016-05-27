using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public int sceneId;
	public void loadScene()
    {
        Application.LoadLevel(sceneId);
    }
}
