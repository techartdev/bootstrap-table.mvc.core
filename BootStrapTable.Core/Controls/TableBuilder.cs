using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using BootStrapTable.Core.Helpers;
using BootStrapTable.Core.Support;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BootStrapTable.Core.Controls
{
    /// <summary>
    /// Build a BootstrapTable control.
    /// </summary>
    internal partial class TableBuilder : IColumnBuilder
    {
        ///<exclude/>
        private readonly TagBuilder _builder;
        ///<exclude/>
        private readonly List<TagBuilder> _columns = new List<TagBuilder>();

        public readonly List<string> _columnNames = new List<string>();
        ///<exclude/>
        private TagBuilder _currentColumn = null;

        #region IHtmlString
        /// <inheritDoc/>
        public HtmlString ToHtmlString()
        {
            var thead = new TagBuilder("thead");
            _columns.ForEach(column => thead.InnerHtml.Append(column.ToString()));
            _builder.InnerHtml.Append(thead.ToString());
            return new HtmlString(_builder.InnerHtml.ToString());
        }
        #endregion

        /// <inheritDoc/>
        public TableBuilder(string id = null, string url = null, TablePaginationOption? sidePagination = TablePaginationOption.none, object htmlAttributes = null)
        {
            _builder = new TagBuilder("table");
            if (!string.IsNullOrEmpty(id))
                _builder.Attributes.Add("id", id);

            if (sidePagination != TablePaginationOption.none)
            {
                Apply(TableOption.pagination);
                ApplyToTable(sidePagination.FieldName(), sidePagination.FieldValue());
            }

            if (!string.IsNullOrEmpty(url))
                Apply(TableOption.url, url);

            _builder.MergeAttributes(Extensions.HtmlAttributesToDictionary(htmlAttributes));

            Apply(TableOption.toggle);
        }

        /// <inheritDoc/>
        public ITableBuilder ApplyToColumns(ColumnOption option)
        {
            _columns.ForEach(s => ApplyToColumn(s.InnerHtml.ToString(), option.FieldName(), option.FieldValue() ?? Extensions.ToStringLower(true)));
            return this;
        }

        /// <inheritDoc/>
        public ITableBuilder Columns(params string[] columns)
        {
            Extensions.ForEach(columns, s => Column(Extensions.SplitCamelCase(s), s));
            return this;
        }

        /// <inheritDoc/>
        public IColumnBuilder Column(string title = "", bool sortable = false, string sorter = null)
        {
            return Column(title, title, sortable, sorter);
        }

        /// <inheritDoc/>
        public IColumnBuilder Column(string title, string field, bool sortable = false, string sorter = null)
        {
            var findColumn = _columnNames.IndexOf(title);
            if (findColumn >= 0)
            {
                _currentColumn = _columns[findColumn];
                return this;
            }

            var column = new TagBuilder("th");
            column.Attributes.Add(ColumnOption.field.FieldName(), field);
            if (sortable)
            {
                column.Attributes.Add(ColumnOption.sortable.FieldName(), Extensions.ToStringLower(sortable));
                column.Attributes.Add(ColumnOption.sorter.FieldName(), sorter);
            }
            column.InnerHtml.SetContent(title);
            _columns.Add(column);
            _columnNames.Add(title);
            _currentColumn = column;

            return this;
        }

        /// <exclude/>
        protected TagBuilder GetColumnByTitle(string column)
        {
            var findColumn = _columnNames.IndexOf(column);
            if (findColumn == -1)
                throw new ArgumentException("Column not found with that title.");
            return _columns[findColumn];
        }

        /// <exclude/>
        protected bool SetColumnByTitle(string column)
        {
            return (_currentColumn = GetColumnByTitle(column)) != null;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            writer.Write(_builder.InnerHtml.ToString());
        }
    }
}
