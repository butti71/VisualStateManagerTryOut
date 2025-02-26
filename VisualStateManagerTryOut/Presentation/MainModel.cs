namespace VisualStateManagerTryOut.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
    }

    // Code From: 
    // https://platform.uno/docs/articles/external/uno.toolkit.ui/doc/helpers/VisualStateManager-extensions.html
    // 
    // In the example: 
    // 
    // public string PageState { get => GetProperty<string>(); set => SetProperty(value); }
    // 
    // replaced it with this:
    public IState<string> PageState => State<string>.Value(this, () => string.Empty);
    public async Task ChangePageStateCommand(object parameter)
    {
        if (parameter is string state)
        {
            await PageState.UpdateAsync(_ => state);
            
        }
    }

}
