using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForLoadToTargetScene : MonoBehaviour
{
    // Start is called before the first frame update
    public int SceneName;
    public SceneManager Sm;

    public void SceneLoader()
    {
        SceneManager.LoadScene(SceneName);
        ItemBase.UseButton.SetActive(true);
    }
}
