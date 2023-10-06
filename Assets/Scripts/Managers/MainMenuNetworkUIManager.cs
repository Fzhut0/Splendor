using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuNetworkUIManager : MonoBehaviour
{
    [SerializeField] private Button ClientButton;
    [SerializeField] private Button HostButton;

    private void Awake()
    {
        HostButton.onClick.AddListener((() =>
        {
            NetworkManager.Singleton.StartHost();
        }));
        ClientButton.onClick.AddListener((() =>
        {
            NetworkManager.Singleton.StartClient();
        }));

}
}
