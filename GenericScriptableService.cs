using k.Services.Bases;
using UnityEngine;

namespace k.Services {
    public class GenericScriptableService<T> : BaseScriptableService where T : GenericScriptableService<T> {
        public static T Instance => _instance;

        protected static T _instance;

        public override void Initialize() {
            _instance = (T)this;
        }
    }
}