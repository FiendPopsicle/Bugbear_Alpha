using Bugbear.Managers;
using UnityEngine;

namespace Bugbear.AudioSystem
{
    public class AudioReceiver : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private LevelAlbum _levelAlbum;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            GlobalPointer._sceneManager.onRequestLevelAlbum += ReceivedRequest;
        }
        private void OnDisable()
        {
            GlobalPointer._sceneManager.onRequestLevelAlbum -= ReceivedRequest;
        }
        private void ReceivedRequest()
        {
            GlobalPointer._audioManager.InitalizeAudioReceiver(_audioSource, _levelAlbum);
        }
    }
}
