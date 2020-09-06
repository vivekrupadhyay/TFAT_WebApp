using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using TFATERPWebApplication.Core.Repositary;

namespace TFATERPWebApplication.Core
{
    public class DynamicModel : IDynamicModel
    {
        public TypeBuilder CreateTypeBuilder(string assemblyName, string moduleName, string typeName)
        {
            TypeBuilder typeBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Run).DefineDynamicModule(moduleName).DefineType(typeName, TypeAttributes.Public);
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            return typeBuilder;
        }

        public void CreateAutoImplementedProperty(TypeBuilder builder, string propertyName, Type propertyType)
        {
            const string PrivateFieldPrefix = "m_";
            const string GetterPrefix = "get_";
            const string SetterPrefix = "set_";

            // Generate the field.
            FieldBuilder fieldBuilder = builder.DefineField(string.Concat(PrivateFieldPrefix, propertyName), propertyType, FieldAttributes.Private);
            // Generate the property
            PropertyBuilder propertyBuilder = builder.DefineProperty(propertyName, System.Reflection.PropertyAttributes.HasDefault, propertyType, null);

            // Property getter and setter attributes.
            MethodAttributes propertyMethodAttributes = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            // Define the getter method.
            MethodBuilder getterMethod = builder.DefineMethod(string.Concat(GetterPrefix, propertyName), propertyMethodAttributes, propertyType, Type.EmptyTypes);

            // Emit the IL code.
            // ldarg.0
            // ldfld,_field
            // ret
            ILGenerator getterILCode = getterMethod.GetILGenerator();
            getterILCode.Emit(OpCodes.Ldarg_0);
            getterILCode.Emit(OpCodes.Ldfld, fieldBuilder);
            getterILCode.Emit(OpCodes.Ret);

            // Define the setter method.
            MethodBuilder setterMethod = builder.DefineMethod(string.Concat(SetterPrefix, propertyName), propertyMethodAttributes, null, new Type[] { propertyType });

            // Emit the IL code.
            // ldarg.0
            // ldarg.1
            // stfld,_field
            // ret
            ILGenerator setterILCode = setterMethod.GetILGenerator();
            setterILCode.Emit(OpCodes.Ldarg_0);
            setterILCode.Emit(OpCodes.Ldarg_1);
            setterILCode.Emit(OpCodes.Stfld, fieldBuilder);
            setterILCode.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getterMethod);
            propertyBuilder.SetSetMethod(setterMethod);
        }

        public TypeCode TypeConvert(string value)
        {
            SqlParameter param = new SqlParameter();
            TypeConverter tc = TypeDescriptor.GetConverter(new SqlDbType());
            try
            {
                param.SqlDbType = (SqlDbType)tc.ConvertFromString(value);
                return System.Web.UI.WebControls.Parameter.ConvertDbTypeToTypeCode(param.DbType);
            }
            catch
            {
                throw new Exception("Parameter SqlDbType could not convert from '" + value + "'.");
            }

        }
    }
}