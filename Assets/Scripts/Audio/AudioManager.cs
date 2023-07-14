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
            if(_currentAudioSource == null)
            {
                Debug.LogError("Audio Source has not been laoded"); return;
            }

            if(_currentAlbum == null) { Debug.LogError("Album has not been selected"); return; }

            _currentAudioSource.clip = GetTrack(id);
            _currentAudioSource.Play();
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

        private AudioClip GetTrack(int id)
        {
            foreach (var track in _currentAlbum.tracks)
            {
                if(id == track.id) return track.audioReference;
            }

            Debug.Log("Track not found");
            return null;
        }
    }
}
