using SingletonSystem.Runtime;
using UnityEditor;
using UnityEngine;

namespace SingletonSystem.Editor{
    public static class SingletonsCollectionEditor{
#if UNITY_EDITOR

        [MenuItem("Tools/Singleton System/Open SingletonsCollection")]
        private static void OpenBindingsCollection() => EditorUtility.OpenPropertyEditor(SingletonsCollection.instance);

        internal static SingletonsCollection CreateBindingsCollection(){
            var singletonsCollection = ScriptableObject.CreateInstance<SingletonsCollection>();
            singletonsCollection.name = "SingletonsCollection";

            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                AssetDatabase.CreateFolder("Assets", "Resources");

            if (!AssetDatabase.IsValidFolder("Assets/Resources/SingletonSystem"))
                AssetDatabase.CreateFolder("Assets/Resources", "SingletonSystem");

            AssetDatabase.CreateAsset(singletonsCollection, "Assets/Resources/SingletonSystem/SingletonsCollection.asset");
            AssetDatabase.SaveAssets();

            return singletonsCollection;
        }

#endif
    }
}