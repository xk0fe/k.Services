using System.Collections.Generic;
using UnityEngine;

namespace k.Services
{
    [CreateAssetMenu(menuName = "Services/ServiceInitializer")]
    public class ScriptableServiceInitializer : GenericScriptableService<ScriptableServiceInitializer>
    {
        [SerializeField] private List<BaseScriptableService> _services;
        
        public override void Initialize()
        {
            base.Initialize();
            foreach (var service in _services)
            {
                if (service == null) continue;
                service.Initialize();
            }
        }

        public override void Update()
        {
            base.Update();
            foreach (var service in _services)
            {
                if (service == null) continue;
                service.Update();
            }
        }
    }
}