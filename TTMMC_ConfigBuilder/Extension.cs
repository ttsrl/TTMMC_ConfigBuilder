using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

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

        public static DataItem GetReferenceKey(this List<DataGroup> list)
        {
            foreach (var g in list)
            {
                foreach (var it in g.Items)
                {
                    if (it.IsReferenceKey)
                        return it;
                }
            }
            return null;
        }

        public static DataItem GetFinishKey(this List<DataGroup> list)
        {
            foreach (var g in list)
            {
                foreach (var it in g.Items)
                {
                    if (it.IsFinishKey)
                        return it;
                }
            }
            return null;
        }

        public static void ClearReferenceKey(this List<DataGroup> list)
        {
            foreach (var g in list)
            {
                foreach (var it in g.Items)
                {
                    it.IsReferenceKey = false;
                }
            }
        }

        public static void ClearFinishKey(this List<DataGroup> list)
        {
            foreach (var g in list)
            {
                foreach (var it in g.Items)
                {
                    it.IsFinishKey = false;
                }
            }
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

    }
}
