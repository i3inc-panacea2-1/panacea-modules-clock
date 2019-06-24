using Panacea.Controls;
using Panacea.Multilinguality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Panacea.Modules.Clock
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ClockControl : UserControl
    {
        private DispatcherTimer t;


        public ClockControl()
        {
            InitializeComponent();
        }

        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            
            t.Tick -= t_Elapsed;
            LanguageContext.Instance.LanguageChanged -= Instance_LanguageChanged;
            t.Stop();
            t = null;
        }

        private void UpdateClock()
        {
            Text.Text = DateTime.Now.ToString("HH:mm");
            Text2.Text = DateTime.Now.ToString("ddd MMM d", LanguageContext.Instance.Culture);
        }

        private void Clock_OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateClock();
            t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            t.Tick += t_Elapsed;
            LanguageContext.Instance.LanguageChanged += Instance_LanguageChanged;
            t.Start();
        }

        void Instance_LanguageChanged(object sender, EventArgs e)
        {
            UpdateClock();
        }

        void t_Elapsed(object sender, EventArgs e)
        {
            UpdateClock();
        }
    }
}
