using Sanscs.Homework.Common.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
namespace Sanscs.Common.Helpers
{
    public class XsltHelper
    {
        private static readonly XsltHelper xsltHelper = new XsltHelper();
        static XsltHelper()
        {

        }
        private XsltHelper()
        {

        }
        public static XsltHelper Instance
        {
            get
            {
                return xsltHelper;
            }
        }
        public static void TransFromXML(string xmlPath, string xsltPath, string outPath)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(xsltPath);
            trans.Transform(xmlPath, outPath);
        }
        public static string TransFromXML(string content, string xsltPath)
        {
            try
            {
   XslCompiledTransform trans = new XslCompiledTransform();  
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.OmitXmlDeclaration = true;
            trans.Load(xsltPath);
            XmlReader reader = XmlReader.Create(new StringReader(content));
            XmlWriter writer = XmlWriter.Create(sb,settings);
            trans.Transform(reader, writer);
            Logger.Instance.Info("TRTRTR:"+sb.ToString());
            return sb.ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance.Info(string.Format("content:{0},xsltPath:{1}",content,xsltPath));
                Logger.Instance.Info(ex.ToString());
                return null;
            }
         
        }
    }
}
