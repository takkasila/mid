using UnityEngine;
using UnityStandardAssets.Network;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        Debug.Log(lobbyPlayer);
        Debug.Log(gamePlayer);

        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
    }
}
