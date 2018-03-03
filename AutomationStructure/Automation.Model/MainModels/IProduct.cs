using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Infrastructure;

namespace Automation.Model.MainModels
{
    public interface IProduct
    {
        void AddModule(NewModuleData data);

        List<string> GetModulesNames();

        int GetModulesCount();

        void DeleteModule(string moduleName);

        void UpdateModule(DataTable data, string moduleNumber);

        ProductType GetType(string nameProduct);
        
        DataTable GetTotalDetailInfo();

        DataTable GetModuleDetailInfoByNumber(string moduleNumber);

        IModule GetCloneLastModule();

        void AddSimilarModule(IModule module);

        List<string> GetModulesNumbers();

        bool IsModuleExist(string number);

        List<IModule> GetAllModules();

    }
}
