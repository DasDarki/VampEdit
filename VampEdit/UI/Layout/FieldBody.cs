using VampEdit.API.UI;
using VampEdit.API.UI.Layout;

namespace VampEdit.UI.Layout
{
    internal class FieldBody : Parent, IFieldBody
    {
        internal FieldBody(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
        }

        internal override string GetHTML(string classes)
        {
            return $"<div id=\"{ID}\", class=\"field-body {classes}\"></div>";
        }
    }
}
