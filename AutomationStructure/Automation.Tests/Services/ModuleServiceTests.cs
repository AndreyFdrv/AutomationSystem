using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation.Tests
{
    [TestClass]
    public class AutomationTests
    {
        [TestMethod]
        public void Can_GetProduct()
        {
            var projectService = Services.ServiceFactory.ProjectServiceInstance;
            projectService.MakeNewProject();

            var productService = Services.ServiceFactory.ProductServiceInstance;
            productService.AddProduct("Кухня верхние модули");
            var product = productService.GetProduct(Infrastructure.ProductType.KitchenUp);
            
            var moduleService = Services.ServiceFactory.ModuleServiceInstance;
            
            moduleService.AddNewModule(new Model.NewModuleData
            {
                Name = "test",
              
                Scheme = "12",
        
                Type = Infrastructure.ProductType.KitchenUp
            });

            var modulesCount = moduleService.GetModulesCount(Infrastructure.ProductType.KitchenUp);
            var createdModule = moduleService.GetModuleDetails("0", Infrastructure.ProductType.KitchenUp);
        }
    }
}
