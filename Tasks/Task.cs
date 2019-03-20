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
        public Task(int id, string name, DateTime time, TimeSpan tiks, int threads, bool responding)
        {
            Id = id;
            Name = name;
            Time = time;
            Tiks = tiks;
            Threads = threads;
            Responding = responding;
        }
        
    }
}
