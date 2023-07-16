using System.Collections;
using UnityEngine;

namespace Bugbear.Managers
{
    public class GameStateManager : MonoBehaviour, IGameStateManager, IGlobalRouter
    {
        public IEnumerator InitializeComponent()
        {
            Debug.Log("Game State Manager Initialized...");

            yield return null;
        }
    }
}
