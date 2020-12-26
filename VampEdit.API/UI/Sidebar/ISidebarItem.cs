using System;

namespace VampEdit.API.UI.Sidebar
{
    /// <summary>
    /// The sidebar item is the clickable part of the sidebar.
    /// </summary>
    public interface ISidebarItem : IElement
    {
        /// <summary>
        /// The text of the sidebar item.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Selects this item.
        /// </summary>
        void Select();

        /// <summary>
        /// The event gets called when the item is being selected. A click or select triggers this event.
        /// </summary>
        event Action Selected;
        /// <summary>
        /// The event gets called when the item is being unselected. Mostly when another item is selected, the previous item
        /// gets deselected.
        /// </summary>
        event Action Unselected;
    }
}
