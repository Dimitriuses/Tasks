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

namespace Tasks
{
    /// <summary>
    /// Interaction logic for show.xaml
    /// </summary>
    public partial class show : Window
    {
        public show(object a)
        {
            InitializeComponent();
            List<object> fr = new List<object>();
            fr.Add(a);
            dataGrid.ItemsSource = fr;
        }
    }
}
