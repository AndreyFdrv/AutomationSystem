using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Model;

namespace Automation
{
    class Presenter
    {
        BLService blService = new BLService();
        
        public void NewProject()
        {
            blService.MakeNewProject();
        }

        internal void OpenProject(string pathToFile)
        {
            throw new NotImplementedException();
        }
    }
}
