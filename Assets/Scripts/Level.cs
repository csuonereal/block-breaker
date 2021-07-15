using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int BreakableBlock;

    //cached reference
    SceneLoader sceneloader;
    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void countBreakableBlock()
    {


        BreakableBlock++;


    }
    public void blockDestroyed()
    {
        BreakableBlock--;
        if (BreakableBlock <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
