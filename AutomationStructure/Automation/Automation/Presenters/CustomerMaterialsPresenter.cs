using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.Model;
using Automation.Services;
using Automation.View;
using Automation.View.Model;

namespace Automation.Presenters
{
    public class CustomerMaterialsPresenter
    {
        //презентер подготавливает данные из модели и передаёт их в UI.
        

        private readonly CustomerService _customerService;
        private readonly MainForm _view;

        public CustomerMaterialsPresenter(MainForm view)
        {
            _customerService = new CustomerService();
            _view = view;
        }

        public void SetCustomer(List<string[]> customerRecord)
        {
            _customerService.SetCustomer(customerRecord);
            string customerRecord1 = _customerService.GetTotalCustomerRecord();
            _view.UpdateCustomerString(customerRecord1);
        }

        public void InitCustomerTable(DataGridView customerDgv)
        {
            ModelThickness.InitCustomerTable(customerDgv);
        }
        
        public void SetModuleThickness(DataGridView customerDgv)
        {
            var thickness = customerDgv.Rows[1].Cells[2].Value;
            if (thickness != null && thickness.ToString() != "персонально")
            {
                ModuleThickness.SetAllSameValues(thickness.ToString());
            }

            var ldspThickness = customerDgv.Rows[0].Cells[2].Value;
            if (thickness != null)
            {
                ModuleThickness.LDSPThickness = ModuleThickness.GetLDSPThicknessValue(ldspThickness.ToString());
            }

            var backWallThickness = customerDgv.Rows[2].Cells[2].Value;
            if (backWallThickness != null)
            {
                ModuleThickness.BackWallThickness = ModuleThickness.GetBackWallThickness(backWallThickness.ToString());
            }

            var fasadeThickness = customerDgv.Rows[3].Cells[2].Value;
            if (fasadeThickness != null)
            {
                ModuleThickness.FasadeThickness = ModuleThickness.GetFasadeThickness(fasadeThickness.ToString());
            }
        }


    }
}
