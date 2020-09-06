using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TFATERPWebApplication.Core.Repositary
{
    interface IDynamicModel
    {
        TypeBuilder CreateTypeBuilder(string assemblyName, string moduleName, string typeName);
        void CreateAutoImplementedProperty(TypeBuilder builder, string propertyName, Type propertyType);
        TypeCode TypeConvert(string value);
    }
}
