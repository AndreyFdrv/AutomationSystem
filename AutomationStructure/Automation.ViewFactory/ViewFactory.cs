using Automation.Infrastructure;

namespace Automation.ViewFactory
{
    public static class ViewFactory
    {
        public static IViewGenerator GetModule(ProductType type)
        {
            IViewGenerator view = null;
            switch (type)
            {
                case ProductType.KitchenUp:
                    view = new KitchenUpView.KitchenUpView();
                    break;
            }
            return view;
        }
    }
}
