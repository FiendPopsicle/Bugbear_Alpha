using UnityEngine;

namespace Bugbear.Managers
{
    public class GlobalPointer : MonoBehaviour
    {
        public static ISceneManager _sceneManager;
        public static ISaveManager _saveManager;
        public static IAudioManager _audioManager;
    }
}
