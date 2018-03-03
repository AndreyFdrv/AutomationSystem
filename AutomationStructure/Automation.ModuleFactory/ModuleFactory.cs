using Automation.Infrastructure;
using Automation.Module.KitchenUp.OneFacade;

namespace Automation.ModuleFactory
{
    public static class ModuleFactory
    {
        public static IModule GetModule(string moduleSheme)
        {
            IModule module = null;
            switch (moduleSheme)
            {
                case "kitchen-up-one-fasade-left":
                    module = new KitchenUpModuleOneFacade();
                    break;
          
            }
            return module;
        }
    }
}