using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{

    int startingSceneBuildIndex;

    private void Awake()
    {
        int numberScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if (numberScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startingSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentBuildIndex != startingSceneBuildIndex)
        {
            Destroy(gameObject);
        }
    }
}
