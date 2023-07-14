using System.Collections;
using UnityEngine;

namespace Bugbear.Managers
{
    public class Router : MonoBehaviour
    {
        private IEnumerator InitializeManagers()
        {
            GlobalPointer._sceneManager = GetComponent<ISceneManager>();
            yield return ((IGlobalRouter)GlobalPointer._sceneManager).InitializeComponent();

            GlobalPointer._saveManager = GetComponent<ISaveManager>();
            yield return ((IGlobalRouter)GlobalPointer._saveManager).InitializeComponent();

            GlobalPointer._audioManager = GetComponent<AudioManager>();
            yield return ((IGlobalRouter)(GlobalPointer._audioManager)).InitializeComponent();
        }

        public void OnStartUp()
        {
            StartCoroutine(InitializeManagers());
        }
    }
}
