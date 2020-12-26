using System;
using VampEdit.API.UI.Layout;

namespace VampEdit.API.UI.Sidebar
{
    /// <summary>
    /// The sidebar group groups up items which than can be clicked to toggle specific
    /// parts of the UI. A group consists of a label and optionally a button.
    /// </summary>
    public interface ISidebarGroup : IParent
    {
        /// <summary>
        /// The label of the sidebar group.
        /// Setting this label after adding buttons, will remove these buttons!
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Adds a button the the label of this group.
        /// </summary>
        /// <param name="text">The text of the button</param>
        /// <param name="color">The color of the button</param>
        /// <param name="clickCallback">The callback which gets called when clicking this button</param>
        void AppendLabelButton(string text, Color color, Action clickCallback);
    }
}
