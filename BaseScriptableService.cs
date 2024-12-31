using System;
using UnityEngine;

namespace k.Services
{
    public class BaseScriptableService : ScriptableObject, IDisposable
    {
        public virtual void Initialize()
        {
        }
        
        public virtual void Update()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}