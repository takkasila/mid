using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLoginScene : MonoBehaviour {

    public string PlayFabTitleId = string.Empty;
    public string PlayFabId;
    public InputField User, Password;
	void Start () {
        if (!string.IsNullOrEmpty(this.PlayFabTitleId))
        {
            PlayFab.PlayFabSettings.TitleId = this.PlayFabTitleId;
            PlayerPrefs.SetString("PlayFabTitleId", PlayFabTitleId);
        }
        else if (string.IsNullOrEmpty(PlayFab.PlayFabSettings.TitleId))
        {
            Debug.Log("PlayFab Title Id Required. Please enter your Id on the Authentication Controller");
        }
	}

    public void Login()
    {
        
        if (User.text.Contains("@"))
            LoginWithEmail();
        else
            LoginWithUsername();
        
    }

    void LoginWithEmail()
    {
        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest()
        {
            TitleId = PlayFabTitleId,
            Email = User.text,
            Password = Password.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, (result) =>
        {
            PlayFabId = result.PlayFabId;
            PlayerPrefs.SetString("PlayFabId", PlayFabId);
            Debug.Log("Got PlayFabID: " + PlayFabId);

            if (result.NewlyCreated)
            {
                Debug.Log("(new account)");
            }
            else
            {
                Debug.Log("(existing account)");
            }

            Application.LoadLevel(2);
        },
        (error) =>
        {
            Debug.Log("Error logging in with Email:");
            Debug.Log(error.ErrorMessage);
        });
    }

    void LoginWithUsername()
    {
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest()
        {
            TitleId = PlayFabTitleId,
            Username = User.text,
            Password = Password.text,
        };


        PlayFabClientAPI.LoginWithPlayFab(request, (result) =>
        {
            PlayFabId = result.PlayFabId;
            Debug.Log("Got PlayFabID: " + PlayFabId);
            PlayerPrefs.SetString("PlayFabId", PlayFabId);

            if (result.NewlyCreated)
            {
                Debug.Log("(new account)");
            }
            else
            {
                Debug.Log("(existing account)");
            }
            Application.LoadLevel(2);
        },
        (error) =>
        {
            Debug.Log("Error logging in with Username:");
            Debug.Log(error.ErrorMessage);
        });
    }
}
