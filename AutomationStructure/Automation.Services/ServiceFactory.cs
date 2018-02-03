using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Services
{
    public static class ServiceFactory
    {
        public static ModuleService ModuleServiceInstance => new ModuleService();
        public static ProjectService ProjectServiceInstance => new ProjectService();
        public static ProductService ProductServiceInstance => new ProductService();
    }


}
