using System;
using System.Collections.Generic;
using VampEdit.API;
using VampEdit.API.UI;
using VampEdit.API.UI.Sidebar;
using VampEdit.UI.Layout;

namespace VampEdit.UI.Sidebar
{
    internal class SidebarGroup : Parent, ISidebarGroup
    {
        public string Label
        {
            get => _label;
            set
            {
                _label = value;
                CefUI.SetInnerHTML(ID + "_label", _label);
            }
        }

        private string _label;
        private readonly Dictionary<string, Action> _labelCallbacks;

        public SidebarGroup(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
            _label = settings.Label;
            _labelCallbacks = new Dictionary<string, Action>();
        }

        internal override string GetHTML(string classes)
        {
            return $"<p class=\"menu-label\" id=\"{ID}_label\">{Label}</p><ul id=\"{ID}\" class=\"menu-list\"></ul>";
        }

        internal void TriggerLabelCallback(string id)
        {
            if (_labelCallbacks.ContainsKey(id))
                _labelCallbacks[id]();
        }

        public void AppendLabelButton(string text, Color color, Action clickCallback)
        {
            string id = GenerateLabelId();
            _labelCallbacks.Add(id, clickCallback);
            CefUI.AddElementToParent(ID + "_label", $"<a class=\"tag is-{color.GetName().ToLower()}\" onclick=\"bridge.ui_TriggerLabelCallback('{ID}', '{id}')\">{text}</a>");
        }

        public override void Destroy()
        {
            base.Destroy();
            CefUI.DestroyElement(ID + "_label");
        }

        private string GenerateLabelId()
        {
            string id = Guid.NewGuid().ToString();
            while(_labelCallbacks.ContainsKey(id))
                id = Guid.NewGuid().ToString();
            return id;
        }
    }
}
