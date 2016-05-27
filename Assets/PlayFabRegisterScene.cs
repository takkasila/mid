using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabRegisterScene : MonoBehaviour {

    public InputField User, Email, Pass, ConfirmPass;
    void Start()
    {
        PlayFab.PlayFabSettings.TitleId = PlayerPrefs.GetString("PlayFabTitleId");
    }
	public void Register()
    {
        if(string.Compare(Pass.text, ConfirmPass.text) != 0)
        {
            Debug.Log("Password is not the same");
            return;
        }

        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest()
        {
            TitleId = PlayerPrefs.GetString("PlayFabTitleId"),
            Username = User.text,
            Email = Email.text,
            Password = Pass.text,
            RequireBothUsernameAndEmail = true,
            DisplayName = User.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, (result) =>
        {
            Debug.Log("Success create user: "+result.Username);
        }, (error) =>
        {
            Debug.Log("Got error creating playfab user:");
            Debug.Log(error.ErrorMessage);
        });


    }
}
