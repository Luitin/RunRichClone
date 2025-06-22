using System;
using Cysharp.Threading.Tasks;
using UnityEngine;using Zenject;

public class Launcher : MonoBehaviour, IInitializable
{
    [Inject] private PopupManager _popupManager;
    [Inject] private GameSceneManager _gameSceneManager;
    
    public async void Initialize()
    {
        _popupManager.ShowLoader();
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        await _gameSceneManager.LoadScene(SceneNames.MainScene);
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        _popupManager.HideLoader();
        await _gameSceneManager.UnloadScene(SceneNames.Launcher);
    }
}
