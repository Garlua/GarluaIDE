using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garlua.IDE.Service.Template
{
    /// <summary>
    /// Exports LUA script using a template, it converts a given model
    /// to a dictionary and outputs the resulting LUA file
    /// </summary>
    public class WeaponTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swepModel"></param>
        /// <param name="outputFilename"></param>
        public void GenerateTemplate(ViewModel.SwepWizardModel swepModel, String outputFilename)
        {
            Dictionary<string, string> props = ReadProperties(swepModel);

            string text = System.IO.File.ReadAllText(@"templates\swep\weapon.lua");

            foreach (Match tokenMatch in Regex.Matches(text, @"\{\{(.+?)\}\}"))
            {
                string token = tokenMatch.Groups[1].Value;
                string replace = tokenMatch.Groups[0].Value;

                if (props.ContainsKey(token))
                {
                    text = text.Replace(replace, props[token]);
                }
            }


            System.IO.File.WriteAllText(outputFilename, text);
        }

        /// <summary>
        /// Converts a Model to a dictionary where the value of every property is being read,
        /// when the property is an object then it will recursively read the properties of that object
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected Dictionary<string, string> ReadProperties(object model)
        {
            var parameters = new Dictionary<string, string>();

            foreach (var property in model.GetType().GetProperties())
            {
                var value = property.GetValue(model, null);

                if (value is Boolean)
                {
                    parameters.Add(property.Name, (Boolean)value ? "true" : "false");
                }
                else if (value is String || (value is int || value is decimal))
                {
                    parameters.Add(property.Name, value.ToString());
                }
                else if (value != null)
                {
                    foreach (KeyValuePair<string, string> pair in ReadProperties(value))
                    {
                        parameters.Add(property.Name + "." + pair.Key, pair.Value);
                    }
                } 
            }

            return parameters;
        }
    }
}
