using VampEdit.API.UI;
using VampEdit.API.UI.Layout;

namespace VampEdit.UI.Layout
{
    internal class Column : Parent, IColumn
    {
        internal Column(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
        }

        internal override string GetHTML(string classes)
        {
            return $"<div id=\"{ID}\", class=\"column {classes}\"></div>";
        }
    }
}
