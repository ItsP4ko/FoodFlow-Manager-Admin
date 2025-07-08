// Modelo/IPermissionComponent.cs
using System;
using System.Collections.Generic;

namespace Modelo.Interfacez
{
    public interface IPermissionComponent
    {

        string Nombre { get; }

        void Add(IPermissionComponent component);
        void Remove(IPermissionComponent component);
        bool HasPermission(string permission);
    }
}