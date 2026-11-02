using Zenject;

public class Shop : MonoInstaller
{
    public ShopPanel _panel;
    public ShopShower _shower;
    public ButtonInformer _buttonInformer;

    public override void InstallBindings()
    {
        Container.Bind<ShopShower>().FromInstance(_shower).AsSingle();
        Container.Bind<ShopPanel>().FromInstance(_panel).AsSingle();
        Container.Bind<ButtonInformer>().FromInstance(_buttonInformer).AsSingle();
    }
}