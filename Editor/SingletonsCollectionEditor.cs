using SingletonSystem.Runtime;
using UnityEditor;

namespace SingletonSystem.Editor
{
    public static class SingletonsCollectionEditor
    {
#if UNITY_EDITOR

        /// <summary>
        /// Open the SingletonsCollection in the inspector
        /// </summary>
        [MenuItem("Tools/Singleton System/Open SingletonsCollection")]
        private static void OpenBindingsCollection() => EditorUtility.OpenPropertyEditor(SingletonsCollection.instance);
        
#endif
    }
}