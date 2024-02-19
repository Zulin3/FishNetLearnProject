using FishNet.Managing;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private NetworkManager _networkManager;

    public void Start()
    {
        _networkManager = FindObjectOfType<NetworkManager>();
        if (_networkManager == null)
        {
            Debug.LogError("NetworkManager not found, HUD will not function.");
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided");
            _networkManager.ClientManager.StartConnection();
        }
    }
}
