using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public static class ScenesHandler
{
    
    
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadMainMenu()
    {
        LoadScene(0);
    }

    public static void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
