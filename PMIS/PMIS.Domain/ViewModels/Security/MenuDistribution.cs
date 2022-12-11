namespace PMIS.Domain.ViewModels.Security
{
    public class MenuDistribution
    {
        public List<PermittedModule> PermittedModules { get; set; }
        public List<PermittedMenu> PermittedMenus { get; set; }
    }
}