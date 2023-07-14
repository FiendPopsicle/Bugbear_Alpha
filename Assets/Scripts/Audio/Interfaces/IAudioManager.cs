using Bugbear.AudioSystem;
using System;
using UnityEngine;

namespace Bugbear.Managers
{
    public interface IAudioManager
    {
        public void PlayTrack(int id);
        public void StopTrack();
        public void InitalizeAudioReceiver(AudioSource loadedSource, LevelAlbum loadedAlbum);
    }
}