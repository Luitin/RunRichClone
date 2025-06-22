using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PopupManager : MonoBehaviour, IInitializable, ILateDisposable
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject _loader;

    private void Awake()
    {
        _loader.SetActive(false);
    }

    public void Initialize()
    {
        
    }

    public void LateDispose()
    {
        
    }

    public void ShowLoader()
    {
        _loader.SetActive(true);
    }

    public void HideLoader()
    {
        _loader.SetActive(false);
    }
    
    public void LockEventSystem(bool state)
    {
        _eventSystem.enabled = !state;
    }
}
