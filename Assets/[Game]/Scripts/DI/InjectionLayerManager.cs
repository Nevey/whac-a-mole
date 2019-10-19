using System;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace DI
{
    public static class InjectionLayerManager
    {
        private static readonly Dictionary<Type, InjectionLayer> injectionLayers = new Dictionary<Type, InjectionLayer>();

        private static bool IsInjectionLayer(Type type)
        {
            if (type.BaseType != typeof(InjectionLayer))
            {
                return false;
            }

            return type.BaseType == null || IsInjectionLayer(type.BaseType);
        }
        
        public static void CreateLayer(Type type)
        {
            if (IsInjectionLayer(type))
            {
                throw Log.Exception(
                    $"Trying to create InjectionLayer of type <b>{type.Name}</b>, but it's no InjectionLayer!");
            }
            
            if (!injectionLayers.ContainsKey(type))
            {
                InjectionLayer injectionLayer = (InjectionLayer) Activator.CreateInstance(type);
                injectionLayers[type] = injectionLayer;
                
                Log.Write($"Instantiated new <b>{type.Name}</b>");
            }
            else
            {
                Log.Write($"Using cached <b>{type.Name}</b>");
            }
        }
        
        public static (InjectionLayer, InjectableAttribute) GetInjectionLayer(FieldInfo fieldInfo)
        {
            InjectableAttribute injectableAttribute = fieldInfo.FieldType.GetCustomAttribute<InjectableAttribute>();
            if (injectableAttribute == null)
            {
                throw Log.Exception($"Class <b>{fieldInfo.FieldType.Name}</b> is missing <b>Injectable</b> attribute");
            }
            
            Type type = injectableAttribute.Layer;
            if (injectionLayers.ContainsKey(type))
            {
                return (injectionLayers[type], injectableAttribute);
            }

            throw Log.Exception($"InjectionLayer of type {type.Name} is not available! Please check your ApplicationStates");
        }
    }
}