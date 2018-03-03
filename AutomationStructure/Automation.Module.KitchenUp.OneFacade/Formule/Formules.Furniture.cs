using Automation.Module.KitchenUp.OneFacade;

namespace KitchenUpModule.OneFacade.Formule
{
    internal partial class Formules
    {
        private readonly ModuleData _data;

        public Formules(ModuleData data)
        {
            _data = data;
        }


        public double CalculateMidleHeight()
        {
            return 0;
            //return _data.Height / 2;
        }

    }
}
