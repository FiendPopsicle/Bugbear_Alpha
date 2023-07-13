using UnityEngine;

[CreateAssetMenu(fileName = "NewSceneSO", menuName = "Scene Data")]
public class GameSceneSO : SerializableScriptableObject
{
    [Header("SceneData")]
    [SerializeField] public SceneReference sceneReference;
    [SerializeField] public string shortDescription;
    [SerializeField] public GameSceneType type;

    public string GetScenePath()
    {
        return sceneReference.ScenePath;
    }

    public enum GameSceneType
    {
        Location,
        Menu,
        Boot,
        PersistentManagers,
        Gameplay,
        UI
    }
}
