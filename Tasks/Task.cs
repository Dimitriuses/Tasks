using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Tiks { get; set; }
        public int Threads { get; set; }
        public DateTime Time { get; set; }
        public bool Responding { get; set; }
        private Process MyProperty;
        public Task(int id, string name, DateTime time, TimeSpan tiks, int threads, bool responding)
        {
            Id = id;
            Name = name;
            Time = time;
            Tiks = tiks;
            Threads = threads;
            Responding = responding;
            MyProperty = null;
        }

        public Task(Process process)
        {
            Id = process.Id;
            Name = process.ProcessName;
            Time = process.StartTime;
            Tiks = process.TotalProcessorTime;
            Threads = process.Threads.Count;
            Responding = process.Responding;
            MyProperty = process;
        }
        public Task(Task task)
        {
            Id = task.Id;
            Name = task.Name;
            Time = task.Time;
            Tiks = task.Tiks;
            Threads = task.Threads;
            Responding = task.Responding;
            MyProperty = task.MyProperty;
        }
        public Process GetMy()
        {
            return MyProperty;
        }
    }
}
