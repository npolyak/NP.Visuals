// (c) Nick Polyak 2013 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the 
// products that use it.

using NP.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace NP.Paradigms.Windows
{

    public static class VisualTreeUtils
    {
        static Func<FrameworkElement, FrameworkElement> toParent =
                (obj) => VisualTreeHelper.GetParent(obj) as FrameworkElement;

        static Func<FrameworkElement, IEnumerable<FrameworkElement>> toChildren =
            (parentObj) =>
            {
                int childCount = VisualTreeHelper.GetChildrenCount(parentObj);

                List<FrameworkElement> result = new List<FrameworkElement>();
                for (int i = 0; i < childCount; i++)
                {
                    result.Add(VisualTreeHelper.GetChild(parentObj, i) as FrameworkElement);
                }

                return result;
            };

        public static IEnumerable<FrameworkElement> VisualAncestors<T>(this FrameworkElement element)
        {
            return element.Ancestors(toParent);
        }

        public static IEnumerable<FrameworkElement> VisualAncestorsAndSelf(this FrameworkElement element)
        {
            return element.SelfAndAncestors(toParent);
        }

        public static IEnumerable<TreeNodeInfo<FrameworkElement>> VisualSelfAndDescendantsWithLevelInfo
        (
            this FrameworkElement node
        )
        {
            return node.SelfAndDescendantsWithLevelInfo(toChildren);
        }

        public static IEnumerable<TreeNodeInfo<FrameworkElement>> VisualDescendantsWithLevelInfo
        (
            this FrameworkElement node
        )
        {
            return node.DescendantsWithLevelInfo(toChildren);
        }


        public static IEnumerable<FrameworkElement> VisualSelfAndDescendants
        (
            this FrameworkElement node
        )
        {
            return node.SelfAndDescendants(toChildren);
        }

        public static IEnumerable<ResultType> VisualSelfAndDescendants<ResultType>
        (
            this FrameworkElement node
        ) where ResultType : FrameworkElement
        {
            return node.SelfAndDescendants<FrameworkElement, ResultType>(toChildren);
        }

        public static IEnumerable<FrameworkElement> VisualDescendants
        (
            this FrameworkElement node
        )
        {
            return node.Descendants(toChildren);
        }

        public static IEnumerable<ResultType> VisualDescendants<ResultType>
        (
            this FrameworkElement node
        )
            where ResultType : FrameworkElement
        {
            return node.Descendants<FrameworkElement, ResultType>(toChildren);
        }
    }
}
