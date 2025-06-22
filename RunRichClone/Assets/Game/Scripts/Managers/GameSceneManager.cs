using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameSceneManager : IInitializable
{
    public event Action<SceneNames> LoadSceneEvent = delegate {  };
    public event Action<SceneNames> SceneLoadedEvent = delegate {  };
    
    private bool _taskInProgress = false;
    
    public void Initialize()
    {
        
    }
    
    private async UniTask LoadSceneAdditive(SceneNames scene)
    {
        if (_taskInProgress)
            return;
        _taskInProgress = true;
        LoadSceneEvent.Invoke(scene);
        await SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Additive);
        SceneLoadedEvent.Invoke(scene);
        _taskInProgress = false;
    }
    
    public async UniTask LoadScene(SceneNames gameScene)
    {
        await LoadSceneAdditive(gameScene);
    }
    
    public async UniTask UnloadScene(SceneNames gameScene)
    {
        if (_taskInProgress)
            return;
        
        _taskInProgress = true;
        await SceneManager.UnloadSceneAsync(gameScene.ToString());
        _taskInProgress = false;
    }
}
