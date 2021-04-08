using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public static class Extension
    {
        public static bool ContainsDataGroup(this List<DataGroup> list, string name)
        {
            foreach (var it in list)
            {
                if (it.Name == name)
                    return true;
            }
            return false;
        }

        public static DataGroup GetDataGroup(this List<DataGroup> list, string name)
        {
            foreach (var it in list)
            {
                if (it.Name == name)
                    return it;
            }
            return null;
        }

        public static bool RemoveDataGroup(this List<DataGroup> list, string name)
        {
            foreach (var g in list)
            {
                if (g.Name == name)
                    return list.Remove(g);
            }
            return false;
        }


        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }


        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);
                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0] .GetCustomAttributes(typeof(DescriptionAttribute), false) .FirstOrDefault() as DescriptionAttribute;
                        if (descriptionAttribute != null)
                            return descriptionAttribute.Description;
                    }
                }
            }
            return null;
        }

        public static List<string> Descriptions<T>() where T : struct
        {
            var out_ = new List<string>();
            var t = typeof(T);
            if (t.IsEnum)
            {
                Array values = System.Enum.GetValues(t);
                foreach (int val in values)
                {
                    var memInfo = t.GetMember(t.GetEnumName(val));
                    var descriptionAttribute = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                    if (descriptionAttribute != null)
                        out_.Add(descriptionAttribute.Description);
                }
                return out_;
            }
            return null;
        }

        public static void MoveUp(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);

                    // bw : add this line to restore the originally selected node as selected
                    node.TreeView.SelectedNode = node;
                }
            }
        }

        public static void MoveDown(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);

                    // bw : add this line to restore the originally selected node as selected
                    node.TreeView.SelectedNode = node;
                }
            }
        }

        public static TreeNode GetPreviusNode(this TreeNode node)
        {
            TreeNodeCollection nods = (node.Parent == null) ? node.TreeView.Nodes : node.Parent.Nodes;
            int index = nods.IndexOf(node) - 1;
            if (index < 0)
                return nods[0].Parent;
            else
                return nods[index];
        }

        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

    }
}
