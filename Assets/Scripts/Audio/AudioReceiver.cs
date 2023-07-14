using Bugbear.Managers;
using System;
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

        void ReceivedRequest()
        {
            GlobalPointer._audioManager.InitalizeAudioReceiver(_audioSource, _levelAlbum);
        }
    }
}
