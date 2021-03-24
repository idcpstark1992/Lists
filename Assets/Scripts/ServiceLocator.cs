using System.Collections.Generic;
using UnityEngine.Assertions;
using System;

public class ServiceLocator
{
    public static ServiceLocator Instance => _Instance ?? (_Instance = new ServiceLocator());
    private static ServiceLocator _Instance;

    private readonly Dictionary<Type, object> Services;

    public ServiceLocator()
    {
        Services = new Dictionary<Type, object>();
    }
    public void AddService<T>(T _service)
    {
        var type = typeof(T);
        Assert.IsFalse(Services.ContainsKey(type), $" {type} ya se encuentra registrado");
        Services.Add(type, _service);
    }
    public  T GetService<T>()
    {
        var type = typeof(T);
        if (!Services.TryGetValue(type, out var ReturnValue))
            throw new Exception($"service {type} no encontrado");

        return (T)ReturnValue;
    }
}