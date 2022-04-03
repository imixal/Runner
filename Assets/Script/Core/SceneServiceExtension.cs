using UnityEngine;

namespace Script.Core
{
	public static class SceneServiceExtension
	{
		public static AsyncOperation LoadLevelScene(this ISceneService self, int levelNumber)
		{
			return self.LoadScene($"Level_{levelNumber}");
		}
   
		public static void UnLoadLevelScene(this ISceneService self, int levelNumber)
		{
			self.UnLoadScene($"Level_{levelNumber}");
		}
	}
}