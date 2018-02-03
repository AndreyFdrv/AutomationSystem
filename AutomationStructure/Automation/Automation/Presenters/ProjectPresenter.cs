using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Automation.Model.MainModels;
using Automation.Services;

namespace Automation.Presenters
{
    public class ProjectPresenter
    {
        private readonly ProjectService _projectService;

        public ProjectPresenter()
        {
            _projectService = ServiceFactory.ProjectServiceInstance;
        }

        public void NewProject()
        {
            _projectService.MakeNewProject();
        }

        internal void OpenProject(string pathToFile)
        {
            Project project;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                project = (Project)formatter.Deserialize(fs);
            }
            _projectService.SetCurrentOrder(project);
        }

        internal void SaveProject(string pathToFile)
        {
            var order = _projectService.GetCurrentOrder();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, order);
            }
        }

    }

}
