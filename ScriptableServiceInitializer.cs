using System.Collections.Generic;
using k.Services.Bases;
using UnityEngine;

namespace k.Services
{
    [CreateAssetMenu(menuName = "Services/ServiceInitializer")]
    public class ScriptableServiceInitializer : GenericScriptableService<ScriptableServiceInitializer>
    {
        [SerializeField] private List<BaseScriptableService> _services;
        [SerializeField] private List<BaseMonoService> _monoServices;
        [SerializeField] private bool _dontDestroyMonoParentOnLoad = true;

        private readonly List<BaseMonoService> _monoInstances = new();
        
        public override void Initialize()
        {
            base.Initialize();
            foreach (var service in _services)
            {
                if (service == null) continue;
                service.Initialize();
            }
            
            if (_monoServices == null || _monoServices.Count == 0) return;
            var parent = new GameObject($"[{name}] MonoServices");
            if (_dontDestroyMonoParentOnLoad) DontDestroyOnLoad(parent);
            foreach (var monoService in _monoServices)
            {
                if (monoService == null) continue;
                var instance = Instantiate(monoService, parent.transform);
                instance.Initialize();
                _monoInstances.Add(instance);
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (var service in _services)
            {
                if (service == null) continue;
                service.OnUpdate();
            }
            
            foreach (var monoInstance in _monoInstances)
            {
                if (monoInstance == null) continue;
                monoInstance.OnUpdate();
            }
        }
    }
}