﻿using System;
using System.Reflection;
using AutomationFramework.WEB.Components;
using AutomationFramework.WEB.Search;

namespace AutomationFramework.WEB.Driver
{
    internal class PageBuilder : AbstractBuilder
    {
        /// <summary>
        /// Build the page 
        /// </summary>
        /// <param name="pageInstance"></param>
        public void Build(object pageInstance)
        {
            MemberInfo[] membersToBuild = GetElementsMemberInfo(pageInstance.GetType());
            
            foreach (MemberInfo memberInfo in membersToBuild)
            {
                SearchConfiguration searchConfiguration = BuildSearchConfig(memberInfo);
                Type type = GetMemberType(memberInfo);

                if (type.IsSubclassOf(typeof(Container)))
                {
                    object instance = new ContainerBuilder().Build(memberInfo, searchConfiguration);
                    SetMemberValue(memberInfo, pageInstance, instance);
                    continue;
                }
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (HtmlElementsCollection<>))
                {
                    object instance = new HtmlElementsCollectionBuilder().Build(memberInfo, searchConfiguration);
                    SetMemberValue(memberInfo, pageInstance, instance);
                    continue;
                }
                if (type.IsSubclassOf(typeof(HtmlElement))|| type == typeof(HtmlElement))
                {
                    object instance = Initialize(type, searchConfiguration);
                    SetMemberValue(memberInfo, pageInstance, instance);
                }
            }
        }
    }
}