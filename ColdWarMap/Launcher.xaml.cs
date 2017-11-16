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
using System.Windows.Shapes;

namespace ColdWarMap
{
    /// <summary>
    /// Логика взаимодействия для Launcher.xaml
    /// </summary>
    public partial class Launcher : Window
    {

        MainWindow mp;

        public void ShowInfo(string name,string codename)
        {
            InfoViewer iv = new InfoViewer(name, codename);

            iv.Back=()=> PageControl.ShowPage(mp);

            PageControl.ShowPage(iv);
        }

        public Launcher()
        {
            InitializeComponent();

            mp = new MainWindow();
            mp.ShowInfo = ShowInfo;

            PageControl.ShowPage(mp);
        }
    }
}
