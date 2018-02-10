using Automation.Infrastructure;
using Automation.Module.KitchenUp;

namespace Automation.ModuleFactory
{
    public static class ModuleFactory
    {
        public static BaseModule GetModule(ProductType type)
        {
            BaseModule module = null;
            switch (type)
            {
                case ProductType.KitchenUp:
                    module = new KitchenUp();
                    break;
          
            }
            return module;
        }
    }
}