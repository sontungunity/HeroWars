using UnityEngine;

namespace Gafu.InGame.Singleton
{

    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        Debug.LogErrorFormat("[SINGLETON] The class {0} could not be found in the scene!", typeof(T));
                    }
                }
                return instance;
            }
        }

        public static bool HasInstance => instance != null;

        public void Preload() { }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                OnAwake();
            }
            else if (instance != this)
            {
                Debug.LogWarningFormat("[SINGLETON] There is more than one instance of class {0} in the scene!", typeof(T));
                Destroy(this.gameObject);
            }
        }

        protected virtual void OnAwake()
        {
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }
}