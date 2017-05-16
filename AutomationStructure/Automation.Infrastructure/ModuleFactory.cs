namespace Automation.Infrastructure
{
    public static class ModuleFactory
    {
        public static AbstractModule GetModule(ProductType type)
        {
            AbstractModule module = null;
            switch (type)
            {
                case ProductType.KitchenUp:
                    module = new KitchenUp();
                    break;
                case ProductType.KitchenDown:
                    module = new KitchenDown();
                    break;
            }
            return module;
        }
    }
}