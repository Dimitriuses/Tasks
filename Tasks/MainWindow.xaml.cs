using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Tasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int tiks { get; set; }
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        //Thread t;


        public MainWindow()
        {
            InitializeComponent();
            tiks = 0;

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(1);
            //DataContext = new MainWindowVM();
            //t = new Thread(dispatcherTimer.Start);
            string[] sysFiles = Directory.GetFiles(Environment.GetEnvironmentVariable("SystemRoot"), "*.exe");
            comboBox.Items.Add("<empty>");
            comboBox.SelectedIndex = 0;
            foreach (var item in sysFiles)
            {
                comboBox.Items.Add(item);
            }
            sysFiles = Directory.GetFiles(Environment.GetEnvironmentVariable("SystemRoot") + @"\system32", "*.exe");
            foreach (var item in sysFiles)
            {
                comboBox.Items.Add(item);
            }

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dataGrid.ItemsSource = Update();
            
            
            tiks++;
            label.Content = $"{tiks} ";
        }

        public List<Task> Update()
        {
            List<Task> result = new List<Task>();
            foreach (Process item in Process.GetProcesses())
            {
                try
                {
                    //Task task = new Task(item.Id, item.ProcessName, item.StartTime, item.TotalProcessorTime, item.Threads.Count, item.Responding);
                    //Tasks.Add(task);
                    Task task = new Task(item);
                    result.Add(task);
                }
                catch
                {

                }
            }
            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             dispatcherTimer.Start();
            //if (!t.IsAlive)
            //{
            //    t.Start();
            //}
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task task = new Task((Task)e.AddedItems[0]);
            Process p  = task.GetMy();
            show d1 = new show(p);
            d1.Show();
            
            
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string tmp = textBox.Text;
            if ((bool)radioButton.IsChecked)
            {
                int dtmp = Convert.ToInt32(tmp);
                foreach (var item in Process.GetProcesses())
                {
                   if(item.Id == dtmp)
                    {
                        //item.Kill();
                        if(MessageBox.Show(item.ToString()+item.Id.ToString(),"kill",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            item.Kill();
                        }
                    }
                }
            }
            else if ((bool)radioButton1.IsChecked)
            {
                foreach (var item in Process.GetProcesses().Where(p => p.ProcessName.Contains(tmp)))
                {
                    if(MessageBox.Show(item.ToString()+item.Id.ToString(),"kill",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        item.Kill();
                    }
                }
            }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            string patch ="";
            if(comboBox.SelectedIndex == 0)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = " exe file | *.exe";
                if (dlg.ShowDialog() == true)
                {
                    patch = dlg.FileName;
                    
                }
            }
            else
            {
                patch = comboBox.SelectedItem.ToString();
            }
            if( MessageBox.Show("Run ->" + patch +"?","Runing",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Process.Start(patch,textBox1.Text);
            }
        }
    }
}
