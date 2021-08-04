using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;

public static class ObjectConverter
{
    public static object Convert(string json)
    {
        var schema = JSchema.Parse(json);
        var type = CreateType(schema);
        var destObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
        return destObject;
    }

    private static Type CreateType(JSchema schema)
    {
        Type result = null;
        var typeBuilder = GetTypeBuilder(Guid.NewGuid().ToString());
        foreach (var item in schema.ExtensionData)
        {
            var jType = item.Value.Type;
            if (item.Value.Type == (JTokenType.Object | JTokenType.Null))
            {
                JSchema nschema = JSchema.Parse(item.Value.ToString());
                Type type = CreateType(nschema);
                //if (item.Value.Type != null)
                //{
                    CreateProperty(typeBuilder, item.Key, type);
                //}
            }
            else if (item.Value.Type == JTokenType.Array)
            {
                if (item.Value.Count() > 0)
                {
                    JSchema nschema = JSchema.Parse(item.Value[0].ToString());
                    Type type = CreateType(nschema);
                    CreateProperty(typeBuilder, item.Key, typeof(List<Type>));
                }
                else
                    CreateProperty(typeBuilder, item.Key, ConvertType(item.Value.Type));
            }
            else
            {
                //if (item.Value.Type != null)
                //{
                    CreateProperty(typeBuilder, item.Key, ConvertType(item.Value.Type));
                //}
            }
        }

        result = typeBuilder.CreateType();
        return result;
    }

    public static Type ConvertType(JTokenType source)
    {
        Type result = null;
        switch (source)
        {
            case JTokenType.None:

                break;
            case JTokenType.String:
                result = typeof(string);
                break;
            case JTokenType.Float:
                result = typeof(float);
                break;
            case JTokenType.Integer:
                result = typeof(int);
                break;
            case JTokenType.Boolean:
                result = typeof(bool);
                break;
            case JTokenType.Object:
                result = typeof(object);
                break;
            case JTokenType.Array:
                result = typeof(Array);
                break;
            case JTokenType.Null:
                result = typeof(Nullable);
                break;
            //case JTokenType.String | JTokenType.Null:
            //    result = typeof(string);
            //    break;
            default:
                break;
        }
        return result;
    }

    private static TypeBuilder GetTypeBuilder(string typeSignature)
    {
        var an = new AssemblyName(typeSignature);
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
        TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
                TypeAttributes.Public |
                TypeAttributes.Class |
                TypeAttributes.AutoClass |
                TypeAttributes.AnsiClass |
                TypeAttributes.BeforeFieldInit |
                TypeAttributes.AutoLayout,
                null);
        return tb;
    }

    private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
    {
        FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

        PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
        MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
        ILGenerator getIl = getPropMthdBldr.GetILGenerator();

        getIl.Emit(OpCodes.Ldarg_0);
        getIl.Emit(OpCodes.Ldfld, fieldBuilder);
        getIl.Emit(OpCodes.Ret);

        MethodBuilder setPropMthdBldr =
            tb.DefineMethod("set_" + propertyName,
              MethodAttributes.Public |
              MethodAttributes.SpecialName |
              MethodAttributes.HideBySig,
              null, new[] { propertyType });

        ILGenerator setIl = setPropMthdBldr.GetILGenerator();
        Label modifyProperty = setIl.DefineLabel();
        Label exitSet = setIl.DefineLabel();

        setIl.MarkLabel(modifyProperty);
        setIl.Emit(OpCodes.Ldarg_0);
        setIl.Emit(OpCodes.Ldarg_1);
        setIl.Emit(OpCodes.Stfld, fieldBuilder);

        setIl.Emit(OpCodes.Nop);
        setIl.MarkLabel(exitSet);
        setIl.Emit(OpCodes.Ret);

        propertyBuilder.SetGetMethod(getPropMthdBldr);
        propertyBuilder.SetSetMethod(setPropMthdBldr);
    }
}