using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SteamAPI.Extensions {
    public static class Xml {
        public static T ParseXML<T>(this string data) where T : class, new() {
            if (data == null) {
                return null;
            }

            if (data.Trim().Length == 0) {
                return null;
            }

            var ser = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(data)) {
                return (T)ser.Deserialize(sr);
            }
        }
        public static string GetStringAttribute(this XElement element, string attributeName, string defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null)
                return a.Value;
            else
                return defaultValue;
        }

        public static DateTime GetDateTimeAttribute(this XElement element, string attributeName, DateTime defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                DateTime result;

                if (DateTime.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static Int16 GetInt16Attribute(this XElement element, string attributeName, Int16 defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                Int16 result;

                if (Int16.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static Int32 GetInt32Attribute(this XElement element, string attributeName, Int32 defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                Int32 result;

                if (Int32.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static Int64 GetInt64Attribute(this XElement element, string attributeName, Int64 defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                Int64 result;

                if (Int64.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static bool GetBooleanAttribute(this XElement element, string attributeName, bool defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                bool result;

                if (bool.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static double GetDoubleAttribute(this XElement element, string attributeName, double defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                double result;

                if (double.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static float GetDoubleAttribute(this XElement element, string attributeName, float defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                float result;

                if (float.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static decimal GetDecimalAttribute(this XElement element, string attributeName, decimal defaultValue) {
            XAttribute a = element.Attributes().Where(i => i.Name == attributeName).SingleOrDefault();

            if (a != null) {
                decimal result;

                if (decimal.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static string GetStringValue(this XElement parentElement, string elementName) {
            return GetStringValue(parentElement, elementName, "");
        }
        public static string GetStringValue(this XElement parentElement, string elementName, string defaultValue) {
            if (parentElement != null) {
                XElement a = parentElement.Element(elementName);

                if (a != null)
                    return a.Value;
                else
                    return defaultValue;
            } else {
                return defaultValue;

            }
        }
        public static Int32 GetInt32Element(this XElement element, string elementName, Int32 defaultValue) {
            XElement a = element.Elements().Where(i => i.Name == elementName).SingleOrDefault();

            if (a != null) {
                Int32 result;

                if (Int32.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }
        public static uint GetuinElement(this XElement element, string elementName, uint defaultValue) {
            XElement a = element.Elements().Where(i => i.Name == elementName).SingleOrDefault();

            if (a != null) {
                uint result;

                if (uint.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }

        public static Int64 GetInt64Element(this XElement element, string elementName, Int64 defaultValue) {
            XElement a = element.Elements().Where(i => i.Name == elementName).SingleOrDefault();

            if (a != null) {
                Int64 result;

                if (Int64.TryParse(a.Value, out result))
                    return result;
                else
                    return defaultValue;
            } else
                return defaultValue;
        }
        public static List<string> GetListOfChildElementValues(this XElement element, string parentElementName, string childElementNames, List<string> defaultValue) {
            if (element != null) {
                XElement a = element.Elements(parentElementName).FirstOrDefault();

                if (a != null && a.HasElements && a.Elements(childElementNames) != null && a.Elements(childElementNames).Count() > 0) {

                    return (from x in a.Elements(childElementNames) select x.Value).ToList();

                } else {
                    return defaultValue;
                }
            } else {
                return defaultValue;

            }

        }
    }
}
