using System;
using System.Collections.Generic;
using VampEdit.API.UI;
using VampEdit.API.UI.Controls;
using VampEdit.API.UI.Layout;
using VampEdit.API.UI.Sidebar;
using VampEdit.UI.Controls;
using VampEdit.UI.Layout;
using VampEdit.UI.Sidebar;

namespace VampEdit.UI
{
    internal static class ElementRegistry
    {
        internal static Element CreateElement<T>(IParent parent, string id, SetupSettings settings) where T : IElement
        {
            Type type = typeof(T);
            if (type == typeof(IParent))
            {
                return new Parent(parent, id, settings);
            }

            if (type == typeof(IColumn))
            {
                return new Column(parent, id, settings);
            }

            if (type == typeof(IRow))
            {
                return new Row(parent, id, settings);
            }

            if (type == typeof(IField))
            {
                return new Field(parent, id, settings);
            }

            if (type == typeof(IFieldBody))
            {
                return new FieldBody(parent, id, settings);
            }

            if (type == typeof(IButton))
            {
                return new Button(parent, id, settings);
            }

            if (type == typeof(ICard))
            {
                return new Card(parent, id, settings);
            }

            if (type == typeof(ITextInput))
            {
                return new TextInput(parent, id, settings);
            }

            if (type == typeof(INumberInput))
            {
                return new NumberInput(parent, id, settings);
            }

            if (type == typeof(ICheckbox))
            {
                return new Checkbox(parent, id, settings);
            }

            if (type == typeof(ISelect))
            {
                return new Select(parent, id, settings);
            }

            if (type == typeof(ISidebarGroup))
            {
                return new SidebarGroup(parent, id, settings);
            }

            if (type == typeof(ISidebarItem))
            {
                return new SidebarItem(parent, id, settings);
            }

            return default;
        }
    }
}
