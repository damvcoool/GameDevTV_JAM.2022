using System;
using UnityEngine;

public class SceneLoader : MonoBehaviour 
{
    private void Start()
    {
        DontDestroyOnLoad(this);
        if(!FindObjectOfType<SceneLoader>())
        {
            Instantiate(gameObject);
        }
    }

    public void LoadSceneIndex(int index, bool async)
    {
        Debug.Log($"loading Scene at index {index}");
    }

    public void LoadSceneName(string name, bool async)
    {
        Debug.Log($"loading Scene at index {name}");
    }

}
