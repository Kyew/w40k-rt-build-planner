using System.Configuration;
using System.Data;
using System.Windows;
using W40KRogueTrader_BuildPlanner.View;

namespace W40KRogueTrader_BuildPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }

}
