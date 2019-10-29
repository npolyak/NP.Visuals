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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NP.Paradigms.Windows
{

    public static class LogicalTreeUtils
    {
        static Func<object, object> toParent =
                (obj) =>
                {
                    if ( !(obj is DependencyObject) )
                    {
                        return null;
                    }

                    return LogicalTreeHelper.GetParent(obj as DependencyObject);
                };

        static Func<object, IEnumerable<object>> toChildren =
            (parentObj) =>
            {
                if (!(parentObj is DependencyObject))
                {
                    return null;
                }

                return LogicalTreeHelper.GetChildren(parentObj as DependencyObject).Cast<object>();
            };

        public static IEnumerable<object> LogicalAncestors(this object element)
        {
            return element.Ancestors(toParent);
        }

        public static IEnumerable<object> LogicalAncestorsAndSelf(this object element)
        {
            return element.SelfAndAncestors(toParent);
        }

        public static IEnumerable<TreeNodeInfo<object>> LogicalSelfAndDescendantsWithLevelInfo
        (
            this object node
        )
        {
            return node.SelfAndDescendantsWithLevelInfo(null, toChildren);
        }

        public static IEnumerable<TreeNodeInfo<object>> LogicalDescendantsWithLevelInfo
        (
            this object node
        )
        {
            return node.DescendantsWithLevelInfo(toChildren);
        }


        public static IEnumerable<object> LogicalSelfAndDescendants
        (
            this object node
        )
        {
            return node.SelfAndDescendants(toChildren);
        }

        public static IEnumerable<object> LogicalDescendants
        (
            this object node
        )
        {
            return node.Descendants(toChildren);
        }
    }
}
