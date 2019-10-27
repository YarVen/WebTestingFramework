﻿using System;
using System.Linq;
using System.Reflection;
using AutomationFramework.WEB.Components;
using AutomationFramework.WEB.Search;

namespace AutomationFramework.WEB.Driver
{
    public abstract class AbstractBuilder
    {
        /// <summary>
        /// Return the member info of provided type
        /// </summary>
        protected MemberInfo[] GetElementsMemberInfo(Type type)
        {
            return type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(info => (info.MemberType == MemberTypes.Property || info.MemberType == MemberTypes.Field) 
                      && (info.GetCustomAttributes().Any(attribute => attribute is FindByAttribute))).ToArray();
        }

        /// <summary>
        /// Return the search configuration by provided member info
        /// </summary>
        protected SearchConfiguration BuildSearchConfig(MemberInfo memberInfo,HtmlElement container=null)
        {
            FindByAttribute[] atts = (FindByAttribute[]) memberInfo.
                GetCustomAttributes(typeof(FindByAttribute), false);
            SearchConfiguration searchConfiguration = new SearchConfiguration();
            searchConfiguration.FindBy = atts.FirstOrDefault();
            searchConfiguration.ParentContainer = container;
            return searchConfiguration;
        }

        protected virtual void SetMemberValue(MemberInfo memberInfo, object parent, object value)
        {
            ((FieldInfo) memberInfo).SetValue(parent, value);
        }

        /// <summary>
        /// Return the type by provided member info
        /// </summary>
        protected Type GetMemberType(MemberInfo memberInfo)
        {
            return ((FieldInfo) memberInfo).FieldType;
        }

        /// <summary>
        /// Create instance of type
        /// </summary>
        protected virtual object Initialize(Type type, SearchConfiguration searchConfig)
        {
            return Activator.CreateInstance(type, searchConfig);
        }
    }
}