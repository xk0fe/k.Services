using k.Services.Bases;
using UnityEngine;

namespace k.Services
{
    public class GenericScriptableService<T> : BaseScriptableService where T : GenericScriptableService<T>
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var resources = Resources.LoadAll<T>("");
                    if (resources.Length == 0)
                    {
                        Debug.LogError($"No {typeof(T).Name} found in Resources folder.");
                        return null;
                    }
                    
                    if (resources.Length > 1)
                    {
                        Debug.LogWarning($"Multiple {typeof(T).Name} instances found in Resources folder. Using the first one.");
                    }
                    
                    _instance = resources[0];
                }

                return _instance;
            }
        }

        protected static T _instance;

        public override void Initialize()
        {
            _instance = (T)this;
        }
    }
}