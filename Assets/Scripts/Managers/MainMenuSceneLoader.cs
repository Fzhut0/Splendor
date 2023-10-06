using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour
{
   [SerializeField] private NetworkManager NetworkManager;
   
   private const string OnlineSceneName = "OnlineGameScene";
   private const string OfflineSceneName = "OfflineGameScene";

   private void Start()
   {
      NetworkManager.Singleton.OnServerStarted += LoadOnlineSceneAfterHosting;
   }

   public void LoadOfflineGameScene()
   {
      if (!NetworkManager)
      {
         return;
      }
      NetworkManager.SceneManager.LoadScene(OfflineSceneName, LoadSceneMode.Single);
   }

   public void LoadOnlineSceneAfterHosting()
   {
      if (!NetworkManager)
      {
         return;
      }
      NetworkManager.SceneManager.LoadScene(OnlineSceneName, LoadSceneMode.Single);
   }

   private void OnDestroy()
   {
      NetworkManager.Singleton.OnServerStarted -= LoadOnlineSceneAfterHosting;
   }
}
