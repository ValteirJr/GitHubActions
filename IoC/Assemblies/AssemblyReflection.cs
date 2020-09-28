using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Cursos.IoC.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyReflection
    {
        public static IEnumerable<Type> GetApplicationInterfaces()
        {
            return Assembly.Load("Application").GetTypes().Where(
                type => type.IsInterface
                && type.Namespace != null
                && type.Namespace.StartsWith("Application.Interfaces"));
        }

        public static IEnumerable<Type> GetApplicationClasses()
        {
            return Assembly.Load("Application").GetTypes().Where(
                type => type.IsClass
                && !type.IsAbstract
                && type.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static IEnumerable<Type> GetRepositoryInterfaces()
        {
            return Assembly.Load("Domain").GetTypes().Where(
                type => type.IsInterface
                && type.Namespace != null
                && type.Namespace.StartsWith("Domain.IRepositories"));
        }

        public static IEnumerable<Type> GetRepositories()
        {
            return Assembly.Load("Infra").GetTypes().Where(
                type => type.IsClass
                && !type.IsAbstract
                && type.Namespace != null
                && type.Namespace.StartsWith("Infra.Repositories")
                && type.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("Cursos"),
                Assembly.Load("Application"),
                Assembly.Load("Domain"),
                Assembly.Load("Core"),
                Assembly.Load("Infra"),
                Assembly.Load("IoC")
            };
        }

        public static Type FindType(Type @interface, IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                if (type.GetInterfaces().Contains(@interface))
                {
                    return type;
                }
            }

            return null;
        }

        public static Type FindInterface(Type type, IEnumerable<Type> interfaces)
        {
            foreach (var @interface in interfaces)
            {
                if (type.GetInterfaces().Contains(@interface))
                {
                    return @interface;
                }
            }

            return null;
        }
    }
}
