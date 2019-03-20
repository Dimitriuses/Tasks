﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

            MessageBox.Show(e.AddedItems[0].ToString());
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string tmp = textBox.Text;
            if ((bool)radioButton.IsChecked)
            {
                foreach (var item in Process.GetProcesses(tmp))
                {

                }
            }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
