using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using BootStrapTable.Core.Controls;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BootStrapTable.Core.Support
{
    /// <exclude/>
    internal static class Extensions
    {
        /// <exclude/>
        public static string ToStringLower(this object value)
        {
            return value?.ToString().ToLower();
        }

        /// <exclude/>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var t in enumerable)
            {
                action(t);
            }
        }

        /// <exclude/>
        public static string SplitCamelCase(this string str)
        {
            return Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

        public static IDictionary<string, object> HtmlAttributesToDictionary(this object htmlAttributes)
        {
            return htmlAttributes as IDictionary<string, object> ?? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        }


        /// <exclude/>
        public static bool IsAnonymousType(this Type type)
        {
            bool hasCompilerGeneratedAttribute = type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Any();
            bool nameContainsAnonymousType = type.FullName != null && type.FullName.Contains("AnonymousType");
            return hasCompilerGeneratedAttribute && nameContainsAnonymousType;
        }

        /// <exclude/>
        public static HtmlString ToSerializedString(this object data)
        {
            return new HtmlString(JsonSerializer.Serialize(data));
        }

        /// <exclude/>
        public static string GetName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> field)
        {
            var member = field.Body as MemberExpression;
            return member.Member.Name;
        }

        /// <exclude/>
        public static string GetDisplayName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> field)
        {
            var member = field.Body as MemberExpression;
            if (member != null && member.Member.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute display && !string.IsNullOrEmpty(display.GetName()))
                return display.GetName();
            else if (member != null) 
                return member.Member.Name.SplitCamelCase();

            return string.Empty;
        }

        /// <exclude/>
        public static IEnumerable<PropertyInfo> GetSortedProperties(this Type type)
        {
            int order = int.MaxValue - type.GetProperties().Count();
            return type.GetProperties()
                .Select(p => new
                {
                    property = p,
                    order = p.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() != null ?
                        (((DisplayAttribute)p.GetCustomAttributes(typeof(DisplayAttribute), true).First()).GetOrder() ?? ++order) : ++order
                })
                .OrderBy(o => o.order)
                .Select(o => o.property);
        }
    }
}
