using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.front;

namespace PMU.src.runner
{
    public static class RunApp
    {
        [STAThread]
        static void Main(){
            ApplicationConfiguration.Initialize();
            
            Application.Run(new CreateMatchs());
            // Application.Run(new CreateHorse());
            // Application.Run(new ShowHorse());
            // Application.Run(new ShowPeople());
            // Application.Run(new ShowRules());
            // Application.Run(new ShowMatchs());
            // Application.Run(new CreateRules());
        }    
        
    }
}