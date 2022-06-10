namespace Azox.Core.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 
    /// </summary>
    public class TypeFinder
    {
        public static void AddDirectory(string path) =>
            TypeFinderSingleton.Instance.AddDirectory(path);

        public static void ClearDirectories() =>
            TypeFinderSingleton.Instance.ClearDirectories();

        public static IEnumerable<Type> FindClassesOf<T>() =>
            TypeFinderSingleton.Instance.FindClassesOf<T>();

        public static IEnumerable<Type> FindClassesOf(Type type) =>
            TypeFinderSingleton.Instance.FindClassesOf(type);

        public static IEnumerable<T> FindInstancesOf<T>() =>
            TypeFinderSingleton.Instance.FindInstancesOf<T>();

        public static IEnumerable<Type> FindInterfacesOf<T>() =>
            TypeFinderSingleton.Instance.FindInterfacesOf<T>();
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class TypeFinderSingleton
    {
        #region Fields

        private readonly object _lock = new();

        private readonly List<Assembly> _assemblies;
        private readonly List<string> _assemblyDirectoryPaths;
        private readonly List<string> _assemblySkipLoadingPatterns;

        #endregion Fields

        #region Ctor

        static TypeFinderSingleton() { }

        private TypeFinderSingleton()
        {
            _assemblies = new();

            _assemblyDirectoryPaths = new()
            {
                AppDomain.CurrentDomain.BaseDirectory
            };

            _assemblySkipLoadingPatterns = new()
            {
                "^Autofac",
                "^Castle",
                "^dotnet",
                "^Humanizer",
                "^Microsoft",
                "^mscorlib",
                "^netstandard",
                "^Newtonsoft",
                "^NuGet",
                "^RestSharp",
                "^System",
            };
        }

        #endregion Ctor

        #region Utilities

        private void ClearAssemblies()
        {
            lock (_lock)
            {
                _assemblies.Clear();
            }
        }



        private IEnumerable<Assembly> GetAssemblies()
        {
            if (_assemblies.Count > 0)
            {
                return _assemblies;
            }

            lock (_lock)
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (!Matches(assembly.FullName))
                    {
                        continue;
                    }

                    if (_assemblies.Any(x => x.FullName == assembly.FullName))
                    {
                        continue;
                    }

                    _assemblies.Add(assembly);
                }

                foreach (string directory in _assemblyDirectoryPaths)
                {
                    foreach (string assemblyFilePath in Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories))
                    {
                        try
                        {
                            AssemblyName assemblyName = AssemblyName.GetAssemblyName(assemblyFilePath);
                            if (assemblyName != null
                                && Matches(assemblyName.FullName)
                                && !_assemblies.Any(x => x.FullName == assemblyName.FullName))
                            {
                                Assembly assembly = null;
                                try
                                {
                                    assembly = AppDomain.CurrentDomain.Load(assemblyName);
                                }
                                catch (FileNotFoundException)
                                {
                                    assembly = Assembly.LoadFrom(assemblyFilePath);
                                }
                                finally
                                {
                                    if (assembly != null)
                                    {
                                        _assemblies.Add(assembly);
                                        AppDomain.CurrentDomain.Load(assembly.GetName());
                                    }
                                }
                            }
                        }
                        catch (BadImageFormatException)
                        {
                            continue;
                        }
                    }
                }
            }

            return _assemblies;
        }

        private bool Matches(string assemblyFullName)
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;
            string pattern = string.Join("|", _assemblySkipLoadingPatterns);

            return !Regex.IsMatch(assemblyFullName, pattern, options)
                && Regex.IsMatch(assemblyFullName, ".*", options);
        }

        #endregion Utilities

        #region Methods

        public void AddDirectory(string path)
        {
            if (_assemblyDirectoryPaths.Contains(path))
            {
                return;
            }

            _assemblyDirectoryPaths.Add(path);
            ClearAssemblies();
        }

        public void ClearDirectories()
        {
            lock (_lock)
            {
                _assemblyDirectoryPaths.Clear();
                _assemblies.Clear();
            }
        }

        public IEnumerable<Type> FindClassesOf<T>()
        {
            return FindClassesOf(typeof(T));
        }

        public IEnumerable<Type> FindClassesOf(Type type)
        {
            List<Type> types = new List<Type>();

            foreach (Assembly asm in GetAssemblies())
            {
                foreach (Type _type in asm.GetTypes())
                {
                    if (type.IsAssignableFrom(_type) && !_type.IsAbstract && _type.IsClass)
                    {
                        types.Add(_type);
                    }
                }
            }

            return types;
        }

        public IEnumerable<T> FindInstancesOf<T>()
        {
            IEnumerable<Type> findedClasses = FindClassesOf<T>();

            foreach (Type t in findedClasses)
            {
                yield return (T)Activator.CreateInstance(t);
            }
        }

        public IEnumerable<Type> FindInterfacesOf<T>()
        {
            return GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(t => typeof(T).IsAssignableFrom(t) && t.IsInterface && typeof(T) != t);
        }

        #endregion Methods

        #region Properties

        public static readonly TypeFinderSingleton Instance = new();

        #endregion Properties
    }
}
