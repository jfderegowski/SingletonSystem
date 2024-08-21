using SingletonSystem.Runtime;
using UnityEngine;

namespace SingletonSystem{
    public class GetTestSingleton : MonoBehaviour
    {
        private void Awake(){
            Debug.Log($"Awake");
            Debug.Log(TestSingleton.instance.value);
        }

        private void Start(){
            Debug.Log($"Start");
            Debug.Log(TestSingleton.instance.value);
        }
    }
}