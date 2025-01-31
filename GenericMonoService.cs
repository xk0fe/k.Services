using k.Services.Bases;

namespace k.Services {
    public class GenericMonoService<T> : BaseMonoService where T : GenericMonoService<T> {
        public static T Instance { get; private set; }

        protected virtual void Awake() {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = (T)this;
        }
    }
}