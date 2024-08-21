using UnityEngine;

namespace SingletonSystem.Runtime
{
    [DefaultExecutionOrder(-9990)]
    public abstract class Singleton : MonoBehaviour{
        public virtual void OnInitializeBefore(){ }
        public virtual void OnInitialize(){ }
        public virtual void OnInitializeAfter(){ }
    }
    
    public class Singleton<T> : Singleton where T : Component{
        public static T instance{
            get{
                if (_instance) return _instance;

                _instance = SingletonManager.Get<T>();

                return _instance;
            }
        }

        private static T _instance;
    }
}