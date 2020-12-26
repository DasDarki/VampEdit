using VampEdit.API.UI;
using VampEdit.API.UI.Sidebar;
using VampEdit.UI.Layout;
using VampEdit.UI.Pages;

namespace VampEdit.UI
{
    internal class Window
    {
        internal Parent Sidebar { get; }

        internal Parent Pages { get; }

        internal DashboardPage Dashboard { get; private set; }

        internal Window()
        {
            Sidebar = new Parent(null, "sidebar", SetupSettings.Default());
            Pages = new Parent(null, "pages", SetupSettings.Default());
        }

        internal void Initialize()
        {
            InitializePages();
            InitializeSidebar();
        }

        private void InitializePages()
        {
            Dashboard = new DashboardPage();
        }

        private void InitializeSidebar()
        {
            ISidebarGroup mainGroup = Sidebar.Create<ISidebarGroup>(null, SetupSettings.Default().SetLabel("VampEdit"));
            AddPageToggle(mainGroup, Dashboard, true);
        }

        private void AddPageToggle(ISidebarGroup group, Page page, bool isDefault = false)
        {
            ISidebarItem item = group.Create<ISidebarItem>(null, SetupSettings.Default().SetText(page.Text));
            item.Selected += () => { page.ToggleVisiblity(true); };
            item.Unselected += () => { page.ToggleVisiblity(false); };
            if (isDefault) item.Select();
        }
    }
}
