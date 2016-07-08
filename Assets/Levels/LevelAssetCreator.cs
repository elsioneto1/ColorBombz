using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class YourClassAsset
{
#if UNITY_EDITOR
	[MenuItem("Assets/Create/LevelAsset")]
#endif
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<LevelAsset> ();
	}
}