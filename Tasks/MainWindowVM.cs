using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
//using Microsoft.Practices.Prism.Mvvm;


namespace Tasks
{
    class MainWindowVM //: BindableBase
    {
        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks
        {
            get
            {
                return _tasks ?? (_tasks = new ObservableCollection<Task>());
            }
            set
            {
                if (value != _tasks)
                {
                    _tasks = value;
                    //OnPropertyChanged(() => Tasks);
                }
            }
        }
    }
}
