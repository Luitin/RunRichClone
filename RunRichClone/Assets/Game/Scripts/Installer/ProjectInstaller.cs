using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private PopupManager _popupManagerPrefab;
    [SerializeField] private Launcher _launcherPrefab;
    
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.BindInterfacesAndSelfTo<PopupManager>().FromComponentInNewPrefab(_popupManagerPrefab).AsSingle();
        Container.BindInterfacesAndSelfTo<GameSceneManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<Launcher>().FromComponentInNewPrefab(_launcherPrefab).AsSingle();
        
        Container.Resolve<PopupManager>();
    }
}