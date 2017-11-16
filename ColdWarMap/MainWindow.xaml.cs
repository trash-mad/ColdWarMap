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

namespace ColdWarMap
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 



    public class WarItem
    {
        public WarItem(string name,string codename,string expansion)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/ColdWarMap;component/Images/"+codename+"."+expansion);
            logo.EndInit();

            Name = name;
            Image = logo;
            CodeName = codename;
        }

        public string Name { get; private set; }
        public ImageSource Image { get; private set; }
        public string CodeName { get; private set; }
    }

    public partial class MainWindow : UserControl
    {
        List<WarItem> warlist;

        public Action<string,string> ShowInfo { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            warlist = new List<WarItem>()
            {
                new WarItem("Берлинский кризис 1948 года", "berlinskiy_krizis_48", "png"),
                new WarItem("Корейская война 1950-53г", "koreyskaya_voyna", "jpg"),
                new WarItem("Берлинский кризис 1953 года", "berlinskiy_krizis_53", "jpg"),
                new WarItem("Революция в Венгрии 1956 года", "revolyutsia_v_vengrii", "jpg"),
                new WarItem("Арабо-израильская война 1956 года", "arabo_izrailskaya_voyna", "jpg"),
                new WarItem("Берлинский кризис 1961 года", "berlinskiy_krizis_61", "jpg"),
                new WarItem("Карибский кризис 1962 года", "karibsky_krisis", "jpg")
            };

            WarList.ItemsSource = warlist;
        }

        private void WarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem as WarItem;
            if (item == null) return;

            ShowInfo(item.Name,item.CodeName);
        }
    }
}
