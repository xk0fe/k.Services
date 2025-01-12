using System;
using k.Services.Interfaces;
using UnityEngine;

namespace k.Services.Bases
{
    public class BaseScriptableService : ScriptableObject, IService, IDisposable
    {
        public virtual void Initialize()
        {
        }
        
        public virtual void OnUpdate()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}