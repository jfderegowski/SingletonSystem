using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SingletonSystem.Runtime{
    public class SingletonsCollection : ScriptableObject{
        public static SingletonsCollection instance{
            get{
                var bindingsCollection = Resources.Load<SingletonsCollection>("SingletonSystem/SingletonsCollection");

                if (bindingsCollection) return bindingsCollection;

#if UNITY_EDITOR
                bindingsCollection = Editor.SingletonsCollectionEditor.CreateBindingsCollection();
#endif

                return bindingsCollection;
            }
        }

        [field: SerializeField] public List<Singleton> singletons{ get; private set; } = new();

        private void OnValidate(){
            CheckForDuplicates();
        }

        internal void ValidateBeforeInitialize(){
            CheckForNulls();
            CheckForDuplicates();
        }
        
        private void CheckForNulls(){
            var nulls = (from singleton in singletons
                where !singleton
                select singleton).ToList();

            foreach (var nullSingleton in nulls){
                Debug.Log($"[SingletonSystem] Removing null singleton", this);
                singletons.Remove(nullSingleton);
            }
        }

        private void CheckForDuplicates(){
            var duplicates = (from singleton in singletons
                where singleton
                let count = singletons.Count(otherSingleton => singleton == otherSingleton)
                where count > 1
                select singleton).ToList();

            foreach (var duplicate in duplicates){
                Debug.Log($"[SingletonSystem] Removing duplicate singleton: {duplicate}", this);
                singletons.Remove(duplicate);
            }
        }
    }
}