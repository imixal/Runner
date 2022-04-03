using System.Collections.Generic;
using UnityEngine;

    public interface ISceneService
    {
        AsyncOperation LoadScene(string name);
        AsyncOperation UnLoadScene(string name);
        bool IsLoading { get; }
        IEnumerable<GameObject> GetActiveRoots();
    }
