using System;
using SingletonSystem.Runtime;
using UnityEngine;

namespace SingletonSystem
{
    public class TestSingleton : Singleton<TestSingleton>
    {
        public int value;

        public override void OnInitialize(){
            base.OnInitialize();
            value = 5;
        }

        private void Awake(){
            Debug.Log($"[SingletonSystem] TestSingleton Awake: {instance.value}");
            value = 10;
        }
    }
}