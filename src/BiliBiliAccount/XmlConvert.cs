using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace BiliBiliAPI
{
    public static class XmlConvert
    {
        /// <summary>
        /// 静态，向Xml文件中写入xml
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string SetXml<T>(T args)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(args.GetType());
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.Indent = true;
                xws.OmitXmlDeclaration = true;
                xws.Encoding = Encoding.UTF8;
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                serializer.Serialize(sw, args, namespaces);
                sw.Close();
                return sw.ToString();
            }
        }


        /// <summary>
        /// 静态，从xml获得参数类
        /// </summary>
        /// <param name="xmlstr"></param>
        /// <returns></returns>
        public static T GetXml<T>(string xmlstr)
        {
            using (StringReader sr = new StringReader(xmlstr))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T result = (T)serializer.Deserialize(sr);
                return result;
            }
        }
    }
}
