using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace InfiniteRecipeBook.Common
{
    public static class JsonSchemaState
    {
        private static readonly Dictionary<string, JSchema> _schemaTypeMap = new();

        public static void StoreTypeSchema<T>()
        {
            var schema = new JSchemaGenerator().Generate(typeof(T));
            _schemaTypeMap.Add(typeof(T).FullName!, schema);
        }

        public static JSchema GetTypeSchema<T>()
        {
            var typeName = typeof(T).FullName!;
            if(!_schemaTypeMap.ContainsKey(typeName))
                StoreTypeSchema<T>();

            return _schemaTypeMap[typeName];
        }
    }
}