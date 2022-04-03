using Script.interfece;
using Script.Service;

namespace Script.Core
{
    public interface IGameContext
    {
        IAudioService AudioService { get;}
        ISaveService SaveService { get; }
        SceneService SceneService { get; }
        ICameraService CameraService { get; }

        void ShowView(string viewName);
        void HideView();
    }
}