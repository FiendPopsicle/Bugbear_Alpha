using Bugbear.AudioSystem;
using System;
using System.Collections;
using UnityEngine;

namespace Bugbear.Managers
{
    public class AudioManager : MonoBehaviour, IAudioManager, IGlobalRouter
    {
        private AudioSource _currentAudioSource;
        private LevelAlbum _currentAlbum;
        private bool _isPlaying;

        public void PlayTrack(int id)
        {

        }

        public void StopTrack()
        {

        }

        public void InitalizeAudioReceiver(AudioSource loadedSource, LevelAlbum loadedAlbum)
        {
            _currentAudioSource = loadedSource;
            _currentAlbum = loadedAlbum;
        }

        public IEnumerator InitializeComponent()
        {
            _isPlaying = false;

            Debug.Log("Audio Manager Listening...");

            return null;
        }
    }
}
