using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomChallange
{
    public static class LoadDataHelpers
    {
        
        public static string GetProjectBaseFolder()
        {
            string workingDir = Directory.GetCurrentDirectory();
            string projectDir = Directory.GetParent(workingDir).Parent.Parent.FullName;
            return projectDir;
        }
        public static string GetAtomJsonSchema()
        {
            string jsonSchemaPath = GetProjectBaseFolder() + @"\Schemas";
            return jsonSchemaPath + @"\Atom-json-schema.json";
        }
    }
}
