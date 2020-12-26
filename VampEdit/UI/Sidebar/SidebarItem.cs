using System;
using VampEdit.API.UI;
using VampEdit.API.UI.Sidebar;

namespace VampEdit.UI.Sidebar
{
    internal class SidebarItem : Element, ISidebarItem
    {
        private static SidebarItem _previousItem;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                CefUI.SetInnerHTML(ID, _text);
            }
        }

        private string _text;

        public SidebarItem(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
            _text = settings.Text;
        }

        public void Select()
        {
            if (_previousItem != null)
            {
                _previousItem.Unselected?.Invoke();
                _previousItem.RemoveClass("is-active");
                _previousItem = null;
            }

            Selected?.Invoke();
            AddClass("is-active");
            _previousItem = this;
        }

        internal override string GetHTML(string classes)
        {
            return $"<li id=\"{ID}_parent\"><a id=\"{ID}\" onclick=\"bridge.ui_TriggerSidebarSelect('{ID}')\">{_text}</a></li>";
        }

        public override void Destroy()
        {
            base.Destroy();
            CefUI.DestroyElement(ID + "_parent");
        }

        public event Action Selected;
        public event Action Unselected;
    }
}
