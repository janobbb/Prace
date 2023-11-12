using TODO.ViewModel;
using TODO.View;

namespace TODO
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TODOTask), typeof(TODOTask));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

        }
    }
}