using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataProcessSolution.FileHandlingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class FileHandlingService : IFileHandlingService
    {
        public string ProcessFiles(params string[] value)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in value)
            {
                builder.AppendLine(str);
            }
            return $"You entered the following files: {builder}";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public CompositeType ProcessDataUsingDataContract(DataFileList composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.FileNames == null || composite.FileNames.TrueForAll(x=>x.Length > 0))
            {
                throw new ArgumentNullException("composite");
            }
            foreach (var entry in composite.FileNames)
            {
                PlaceRequestOnServiceBus(entry);
            }
            return new CompositeType();//???
        }

        private void PlaceRequestOnServiceBus(string entry)
        {
            throw new NotImplementedException();
        }
    }
}
