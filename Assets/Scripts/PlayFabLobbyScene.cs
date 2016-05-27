using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabLobbyScene : MonoBehaviour {

    string PlayFabTitleId;
    string PlayFabId;
    public InputField LobbyName;

	void Start () {
        PlayFabTitleId = PlayerPrefs.GetString("PlayFabTitleId");
        PlayFabId = PlayerPrefs.GetString("PlayFabId");

        Debug.Log("Title ID: " + PlayFabTitleId);
        Debug.Log("Player ID: " + PlayFabId);

        GetAccountInfoRequest request = new GetAccountInfoRequest()
        {
            PlayFabId = PlayFabId,
        };

        PlayFabClientAPI.GetAccountInfo(request, (result) =>
        {

            Debug.Log("Username: " + result.AccountInfo.Username);
        },
        (error) =>
        {
            Debug.Log("Error getting account info:");
            Debug.Log(error.ErrorMessage);
        });
	}
}
