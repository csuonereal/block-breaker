using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    //configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int PointsPerDestroyedBlock = 42;
    [SerializeField] Text scoreText;
    

    //state parameters
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        //sayısı bulmak istediğimizden objects yazdık
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        
        //eğer bu script ilk defa çalışmıyorsa bunun yeni bir tanesinin çalışmasını engelle singleton design pattern diyoruz biz buna
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddPointToScore()
    {
       
        currentScore += PointsPerDestroyedBlock;
        scoreText.text = currentScore.ToString();

    }
    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
