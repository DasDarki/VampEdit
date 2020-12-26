using System.Collections.Generic;
using CefSharp;
using VampEdit.API.UI;

namespace VampEdit.UI
{
    internal abstract class Element : IElement
    {
        internal bool DenyDestroy { get; set; } = false;

        public string ID { get; }

        public IElement Parent { get; }

        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                CefUI.SetElementDisplay(ID, _visible);
            }
        }

        public bool IsValid
        {
            get
            {
                JavascriptResponse response = MainForm.Instance.Browser.EvaluateScriptAsync($"!!document.getElementById(`{ID}`);")
                    .GetAwaiter().GetResult();
                bool b = response.Result as bool? ?? false;
                if (!b) CefUI.CreatedElements.Remove(this);
                return b;
            }
        }

        private bool _visible;

        internal List<string> Classes { get; }

        internal Element(IElement parent, string id, SetupSettings settings)
        {
            ID = id;
            Parent = parent;
            Classes = settings.Classes;
        }

        internal abstract string GetHTML(string classes);

        public virtual void Destroy()
        {
            if (DenyDestroy) return;
            CefUI.CreatedElements.Remove(this);
            CefUI.DestroyElement(ID);
        }

        public void RemoveClass(string clazz)
        {
            Classes.Remove(clazz);
            CefUI.RemoveElementClass(ID, clazz);
        }

        public void AddClass(string clazz)
        {
            Classes.Add(clazz);
            CefUI.AddElementClass(ID, clazz);
        }

        public bool HasClass(string clazz)
        {
            return Classes.Contains(clazz);
        }

        public void Style(string key, object value)
        {
            CefUI.SetElementStyle(ID, key, value);
        }
    }
}
