using System.Collections.Generic;
using UnityEngine;

namespace Packaged.k.Services
{
    public class ServiceInitializer : MonoBehaviour
    {
        [SerializeField] private List<ScriptableServiceInitializer> _initializers;
        
        private void Awake()
        {
            if (_initializers == null || _initializers.Count == 0)
            {
                Debug.LogWarning($"No initializers found in {name}");
                return;
            }
            
            foreach (var service in _initializers)
            {
                if (service == null)
                {
                    Debug.LogWarning($"Null initializer found in {name}");
                    continue;
                }
                service.Initialize();
            }
        }
    }
}