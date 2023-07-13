using System;

public interface ISceneManager
{
    public void SceneRequest(GameSceneSO gameScene, bool isMenu);
    public void ColdBootRequest();
    public void RequestMainMenu();
    public void RequestCurtain(string fade);

    public event Action<string> onRequestCurtain;

    public event Action<GameSceneSO, bool> onSceneRequest;
}
