using System.Collections.Generic;
using UnityEngine;

namespace SingletonSystem.Runtime{
    public static class SingletonManager{
        private static SingletonsCollection singletonsCollection => SingletonsCollection.instance;

        private static readonly List<Singleton> _spawnedSingletons = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Initialize(){
            singletonsCollection.ValidateBeforeInitialize();
            
            foreach (var singletonPrefab in singletonsCollection.singletons){
                var prevEnabled = singletonPrefab.gameObject.activeSelf;

                singletonPrefab.gameObject.SetActive(false);

                var singletonClone = Object.Instantiate(singletonPrefab);

                singletonPrefab.gameObject.SetActive(prevEnabled);
                
                Register(singletonClone);

                Object.DontDestroyOnLoad(singletonClone.gameObject);
                
                singletonClone.OnInitializeBefore();
                singletonClone.OnInitialize();
                singletonClone.OnInitializeAfter();
                
                singletonClone.gameObject.SetActive(prevEnabled);
            }
        }

        public static T Get<T>(){
            if (Application.isPlaying){
                foreach (var singleton in _spawnedSingletons)
                    if (singleton is T prefab) return prefab;
            }
            else{
                foreach (var singleton in singletonsCollection.singletons)
                    if (singleton is T prefab) return prefab;
            }

            throw new KeyNotFoundException(
                $"[SingletonSystem] No prefab found for {typeof(T).Name} in BindingsCollection. Add it to the list.");
        }

        public static void Register(Singleton singleton) => _spawnedSingletons.Add(singleton);

        public static void UnRegister(Singleton singleton) => _spawnedSingletons.Remove(singleton);
    }
}