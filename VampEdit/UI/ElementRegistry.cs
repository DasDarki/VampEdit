using System;
using System.Collections.Generic;
using VampEdit.API.UI;
using VampEdit.API.UI.Controls;
using VampEdit.API.UI.Layout;
using VampEdit.UI.Controls;
using VampEdit.UI.Layout;

namespace VampEdit.UI
{
    internal static class ElementRegistry
    {
        internal static Element CreateElement<T>(IParent parent, string id, SetupSettings settings) where T : IElement
        {
            Type type = typeof(T);
            if (ElementTypes.ContainsKey(type))
            {
                return (Element) Activator.CreateInstance(ElementTypes[type], parent, id, settings);
            }

            return default;
        }

        private static readonly Dictionary<Type, Type> ElementTypes = new Dictionary<Type, Type>
        {
            {typeof(IRow), typeof(Row)}, {typeof(IColumn), typeof(Column)}, {typeof(IField), typeof(Field)},
            {typeof(IFieldBody), typeof(FieldBody)}, {typeof(IButton), typeof(Button)}, {typeof(ICard), typeof(Card)},
            {typeof(ITextInput), typeof(TextInput)}, {typeof(INumberInput), typeof(NumberInput)},
            {typeof(ICheckbox), typeof(Checkbox)}, {typeof(ISelect), typeof(Select)}
        };

    }
}
