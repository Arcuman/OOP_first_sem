using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    public class Director
    {
        private event Salary ActionWithSalary;
        private event Working ActionWithWork;
        public void Fine (int x) =>  ActionWithSalary?.Invoke(x);
        public void Boost() => ActionWithWork?.Invoke();
        public Salary SalaryAction { get => ActionWithSalary; set => ActionWithSalary = value; }
        public Working WorkAction { get => ActionWithWork; set => ActionWithWork = value; }
    }
   
}
