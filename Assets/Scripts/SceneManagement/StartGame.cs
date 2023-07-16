using UnityEngine;

namespace Bugbear.Managers
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private bool _showLoadScreen = default;
        private bool _hasSaveData;
        private SaveSystem _tempSaveSystem;
        [SerializeField] private GameSceneSO _characterScreen;
        [SerializeField] private GameSceneSO _newGame;

        private void Start()
        {

        }
        private void OnEnable()
        {
            GlobalPointer._sceneManager.broadcastSceneLoaded += StartNewGameClient;
        }
        private void OnDisable()
        {
            GlobalPointer._sceneManager.broadcastSceneLoaded -= StartNewGameClient;
        }
        private void OnDestroy()
        {

        }

        public void StartNewGameClient()
        {
            GlobalPointer._sceneManager.SceneRequest(_newGame, false);
            Debug.Log("Started New Game");
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
