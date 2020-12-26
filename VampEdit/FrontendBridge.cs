using CefSharp.WinForms;
using VampEdit.API;
using VampEdit.API.UI;
using VampEdit.API.UI.Controls;
using VampEdit.API.UI.Sidebar;
using VampEdit.UI;
using VampEdit.UI.Controls;
using VampEdit.UI.Sidebar;
using Button = VampEdit.UI.Controls.Button;

// ReSharper disable InconsistentNaming
namespace VampEdit
{
    internal class FrontendBridge
    {
        private readonly ChromiumWebBrowser _browser;

        internal FrontendBridge(MainForm form)
        {
            _browser = form.Browser;
        }

        public void ui_TriggerSidebarSelect(string id)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null && element is ISidebarItem item)
            {
                ((SidebarItem) item).Select();
            }
        }

        public void ui_TriggerLabelCallback(string id, string labelId)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null && element is ISidebarGroup group)
            {
                ((SidebarGroup) group).TriggerLabelCallback(labelId);
            }
        }

        public void ui_OnCheckboxChange(string id, bool val)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null && element is ICheckbox checkbox)
            {
                ((Checkbox) checkbox).TriggerChange(val);
            }
        }

        public void ui_OnChange(string id, string val)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null)
            {
                switch (element)
                {
                    case ITextInput textInput:
                        ((TextInput) textInput).TriggerChange(val);
                        break;
                    case INumberInput numberInput:
                        ((NumberInput) numberInput).TriggerChange(val);
                        break;
                    case ISelect select:
                        ((Select) select).TriggerChange(val);
                        break;
                }
            }
        }

        public void ui_OnFocusOut(string id)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null)
            {
                switch (element)
                {
                    case ITextInput textInput:
                        ((TextInput) textInput).TriggerFocusOut();
                        break;
                    case INumberInput numberInput:
                        ((NumberInput) numberInput).TriggerFocusOut();
                        break;
                }
            }
        }

        public void ui_TriggerConfirm(string id, bool val)
        {
            CefUI.UI.TriggerConfirm(id, val);
        }

        public void ui_FooterClick(string id, string clickId)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null && element is ICard card)
            {
                ((Card) card).TriggerFooterClick(clickId);
            }
        }

        public void ui_OnClick(string id)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null)
            {
                if (element is IButton btn)
                {
                    ((Button) btn).TriggerClick();
                }
            }
        }

        public void ui_OnDoubleClick(string id)
        {
            IElement element = CefUI.CreatedElements.SelectFirst(o => o.ID == id);
            if (element != null)
            {
                if (element is IButton btn)
                {
                    ((Button)btn).TriggerDoubleClick();
                }
            }
        }
    }
}
