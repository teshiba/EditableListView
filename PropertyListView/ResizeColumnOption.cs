namespace CustomListView
{
    /// <summary>
    /// Resize column options.
    /// </summary>
    public enum ResizeColumnOption
    {
        /// <summary>
        /// Fit to the text width of each column header.
        /// </summary>
        HeaderSize,

        /// <summary>
        /// Fit to the text width of each column content.
        /// </summary>
        ColumnContent,

        /// <summary>
        /// Fit to maximum text size of either header or contents.
        /// </summary>
        HeaderOrContentsMax,
    }
}
