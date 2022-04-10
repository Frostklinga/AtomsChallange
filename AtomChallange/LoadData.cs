using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;
using NJsonSchema;
using NJsonSchema.Validation;
using System.Collections.ObjectModel;

namespace AtomChallange
{
    public class DataStorageManager
    {
        string fileWithAtoms = LoadDataHelpers.GetProjectBaseFolder()+@"\Atoms.json";
        AtomValidator validator;
        public DataStorageManager()
        {
            validator = new AtomValidator();
        }
        public List<Atom> Load()
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            validator.ValidateData(fileWithAtoms);
            var fileContents = File.ReadAllText(fileWithAtoms);
            var results = JsonConvert.DeserializeObject<List<Atom>>(fileContents,settings);
            return results;
        }
        public static void OnJsonErrorNotifyUser(object target, ErrorEventArgs args)
        {
            Console.WriteLine("Member that caused the errror: "+args.ErrorContext.Member);
            Console.WriteLine("\nOriginal object: " + args.ErrorContext.OriginalObject);
            Console.WriteLine("\nJSON path to which the error occured: " + args.ErrorContext.Path);
            Console.WriteLine("\nThe JSON error:: " + args.ErrorContext.Error);
            
            args.ErrorContext.Handled = true;
        }
        public static JsonSerializerSettings JsonConvertOnErrorNotifyUser()
        {
            var settings = new JsonSerializerSettings();
            settings.Error = new EventHandler<ErrorEventArgs>(OnJsonErrorNotifyUser);
            settings.NullValueHandling = NullValueHandling.Include;
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            return settings;
        }
    
        internal class AtomValidator
        {
            JsonSchema atomJsonSchema;
            public AtomValidator()
            {
                atomJsonSchema = JsonSchema.FromType<AtomsModel>();
            }
            public void ValidateData(string filePathToJsonData)
            {
                try
                {
                    var jsonData = File.ReadAllText(filePathToJsonData);
                    List<ValidationError> listOfValidationErrors = atomJsonSchema.Validate(jsonData).ToList<ValidationError>();
                    foreach (ValidationError error in listOfValidationErrors)
                    {
                        Console.WriteLine($"The validator encountered an error. Message: {error}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Caught an exception. Message: " + e.Message);
                    throw;
                }
            }
        }
    }
}
