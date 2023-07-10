using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSchematic.Componente
{
    internal class SchemaicErros
    {

    }

    public class AutoSchematicNotLoadedException : Exception
    {
        public AutoSchematicNotLoadedException(string message) : base(message)
        {

        }

        public AutoSchematicNotLoadedException()
        {
            //empty
        }
    }

    public class AutoSchematicArgumentException : ArgumentException
    {
        public AutoSchematicArgumentException(string message, string paramName) : base(message, paramName)
        {

        }

        public AutoSchematicArgumentException()
        {
            //empty
        }
    }

    public class AutoSchematicArgumentNullException : ArgumentNullException
    {
        public AutoSchematicArgumentNullException(string paramName, string message) : base(paramName, message)
        {

        }

        public AutoSchematicArgumentNullException(string paramName) : base(paramName)
        {
            
        }

        public AutoSchematicArgumentNullException()
        {
            //empty
        }
    }
}
