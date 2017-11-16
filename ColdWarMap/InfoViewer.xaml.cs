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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace ColdWarMap
{
    /// <summary>
    /// Логика взаимодействия для InfoViewer.xaml
    /// </summary>
    public partial class InfoViewer : UserControl
    {

        public Action Back { get; set; }

        public InfoViewer(string name, string codename)
        {
            InitializeComponent();

            TitleLabel.Content = name;

            StreamResourceInfo res = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/ColdWarMap;component/Pages/" + codename + ".rtf"));
            TextRange textRange = new TextRange(InfoTextBox.Document.ContentStart, InfoTextBox.Document.ContentEnd);
            textRange.Load(res.Stream, System.Windows.DataFormats.Rtf);

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/ColdWarMap;component/Map/" + codename + ".png");
            logo.EndInit();
            MapImage.Source = logo;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
