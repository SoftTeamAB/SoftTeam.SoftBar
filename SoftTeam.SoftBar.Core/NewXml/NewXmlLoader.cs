using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace SoftTeam.SoftBar.Core.NewXml
{
    /// <summary>
    /// This class loads an Xml file containing the entire user area of the SoftBar
    /// </summary>
    public class NewXmlLoader
    {
        private string _path = string.Empty;
        private NewXmlArea _area = null;
        private List<string> _validationErrors = null;

        public List<string> ValidationErrors { get => _validationErrors; set => _validationErrors = value; }

        public NewXmlLoader(string path)
        {
            _path = path;
            _area = new NewXmlArea();
        }

        public NewXmlArea Load()
        {
            // Clear the validation errors
            _validationErrors = new List<string>();

            // Open the file and return a FileStream
            var file = CreateFileStream();
            // Create the settings
            var settings = CreateXmlReaderSettings();
            // Create the Xml reader
            var xmlReader = CreateXmlReader(file, settings);
            // Create the Xml document
            var document = new XmlDocument();
            // Create the Xml schema set
            var schemas = CreateSchemaSet();
            // Attach the schema
            document.Schemas = schemas;

            // Now we can load the XML document
            document.Load(xmlReader);
            // Validate it against the schema
            ValidateXml(document);

            // Check if we have validation errors
            if (_validationErrors.Count() > 0)
            {
                // Errors
                throw new XmlSchemaException("Xml did not validate!");
            }

            // Parse the xml
            var area = ParseXml(document);

            // Return the XmlArea
            return area;
        }

        // Create a FileStream for the Xml path
        private FileStream CreateFileStream()
        {
            return File.OpenRead(_path);
        }

        // Create Cml reader settings that ignores comments and white spaces
        private XmlReaderSettings CreateXmlReaderSettings()
        {
            return new XmlReaderSettings() { IgnoreComments = true, IgnoreWhitespace = true };
        }

        // Creates an XmlReader
        private XmlReader CreateXmlReader(FileStream file, XmlReaderSettings settings)
        {
            return XmlReader.Create(file, settings);
        }

        // Creates a schemaset
        private XmlSchemaSet CreateSchemaSet()
        {
            var schemas = new XmlSchemaSet();
            schemas.Add("",HelperFunctions.GetXmlSchemaPath());
            return schemas;
        }

        // Validates that the Xml is following SoftBar.xsd
        private void ValidateXml(XmlDocument document)
        {
            // Validate the document against the schema
            document.Validate((o, e) =>
            {
                _validationErrors.Add(e.Message);
            });
        }

        // Parse xml
        private NewXmlArea ParseXml(XmlDocument document)
        {
            var area = new NewXmlArea();

            try
            {
                // Select all top level menus in the document
                XmlNode areaNode = document.SelectSingleNode("//softbar");
                // Parse the SoftBar node
                area.ParseXml(areaNode);
            }
            catch (Exception e)
            {
                _validationErrors.Add(e.Message);
            }

            return area;
        }
    }
}
