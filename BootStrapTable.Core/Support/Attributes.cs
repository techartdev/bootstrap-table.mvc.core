﻿using System;
using System.Reflection;

namespace BootStrapTable.Core.Support
{
    /// <exclude/>
    [AttributeUsage(AttributeTargets.Field)]
    internal class NameFieldAttribute : Attribute
    {
        /// <exclude/>
        public string Name { get; set; }
    }

    /// <exclude/>
    [AttributeUsage(AttributeTargets.Field)]
    internal class ValueFieldAttribute : NameFieldAttribute
    {
        /// <exclude/>
        public string Value { get; set; }
    }

    /// <exclude/>
    internal static class FieldAttributeExtensions
    {
        /// <exclude/>
        public static string FieldName(this Enum value)
        {
            var attr = value.GetType().GetField(value.ToString()).GetCustomAttribute<NameFieldAttribute>();
            return attr?.Name;
        }

        /// <exclude/>
        public static string FieldValue(this Enum value)
        {
            var attr = value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueFieldAttribute>();
            return attr?.Value;
        }
    }
}

