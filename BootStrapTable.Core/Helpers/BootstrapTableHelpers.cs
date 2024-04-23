using BootStrapTable.Core.Controls;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BootStrapTable.Core.Helpers
{
    /// <summary>
    /// Represents a collection of extensions that can be applied to the table builder.
    /// </summary>
    public static class BootstrapTableHelpers
    {
        /// <summary>
        /// Returns a BootstrapTable control.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="url">The url that will be used to obtain the data.</param>
        /// <param name="pagination">Is pagination required.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>Html representation of the control.</returns>
        public static ITableBuilder BootstrapTable(this IHtmlHelper helper, string url = null, TablePaginationOption pagination = TablePaginationOption.none, object htmlAttributes = null)
        {
            return new TableBuilder(null, url, pagination, htmlAttributes);
        }

        /// <summary>
        /// Returns a BootstrapTable control.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="id">Identity of the control.</param>
        /// <param name="url">The url that will be used to obtain the data.</param>
        /// <param name="pagination">Is pagination required.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>Html representation of the control.</returns>
        public static ITableBuilder BootstrapTable(this IHtmlHelper helper, string id, string url, TablePaginationOption pagination = TablePaginationOption.none, object htmlAttributes = null)
        {
            return new TableBuilder(id, url, pagination, htmlAttributes);
        }

        /// <summary>
        /// Returns a BootstrapTable control.
        /// </summary>
        /// <typeparam name="TModel">Model</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="url">The url that will be used to obtain the data.</param>
        /// <param name="pagination">Is pagination required</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>Html representation of the control.</returns>
        public static ITableBuilderT<TModel> BootstrapTable<TModel>(this IHtmlHelper helper, string url = null, TablePaginationOption pagination = TablePaginationOption.none, object htmlAttributes = null)
        {
            return BootstrapTable<TModel>(helper, null, url, pagination, htmlAttributes);
        }

        /// <summary>
        /// Returns a BootstrapTable control.
        /// </summary>
        /// <typeparam name="TModel">Model</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="id">Identity of the control.</param>
        /// <param name="url">The url that will be used to obtain the data.</param>
        /// <param name="pagination">Is pagination required.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>Html representation of the control.</returns>
        public static ITableBuilderT<TModel> BootstrapTable<TModel>(this IHtmlHelper helper, string id, string url, TablePaginationOption pagination = TablePaginationOption.none, object htmlAttributes = null)
        {
            return new TableBuilderT<TModel>(id, url, pagination, htmlAttributes);
        }
    }
}
