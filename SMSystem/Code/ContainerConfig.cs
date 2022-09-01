using System.Collections.Generic;

namespace SMSystem.Code
{
    public static class ContainerConfig
    {
        // Fileds
        private static Dictionary<string, object> configuration = new Dictionary<string, object>();

        // Methods
        public static void Register(string Name, object Object)
        {
            configuration.Add(Name, Object);
        }
        public static object ObjectType(string Name)
        {
            return configuration[Name];
        }
    }
}
