using UnityEngine;

[CreateAssetMenu(fileName = "newTrack", menuName = "Audio Track")]
public class TrackSO : ScriptableObject
{
    [Header("Track Data")]
    public int id;
    public AudioClip audioReference;
    public TrackType trackType;

    public enum TrackType
    {
        Music,
        SFX,
        Dialogue
    }
}