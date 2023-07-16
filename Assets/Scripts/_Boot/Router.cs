using System.Collections;
using UnityEngine;

namespace Bugbear.Managers
{
    public class Router : MonoBehaviour, IRouter, IGlobalRouter
    {
        private IEnumerator InitializeManagers()
        {
            GlobalPointer._router = GetComponent<IRouter>();
            yield return ((IGlobalRouter)GlobalPointer._router).InitializeComponent();

            GlobalPointer._sceneManager = GetComponent<ISceneManager>();
            yield return ((IGlobalRouter)GlobalPointer._sceneManager).InitializeComponent();

            GlobalPointer._saveManager = GetComponent<ISaveManager>();
            yield return ((IGlobalRouter)GlobalPointer._saveManager).InitializeComponent();

            GlobalPointer._audioManager = GetComponent<IAudioManager>();
            yield return ((IGlobalRouter)GlobalPointer._audioManager).InitializeComponent();

            GlobalPointer._gameStateManager = GetComponent<IGameStateManager>();
            yield return ((IGlobalRouter)GlobalPointer._gameStateManager).InitializeComponent();

            GlobalPointer._combatManager = GetComponent<ICombatManger>();
            yield return ((IGlobalRouter)GlobalPointer._combatManager).InitializeComponent();
        }

        public void OnStartUp()
        {
            StartCoroutine(InitializeManagers());
        }

        public IEnumerator InitializeComponent()
        {
            Debug.Log("Router Initialized...");

            return null;
        }
    }
}
