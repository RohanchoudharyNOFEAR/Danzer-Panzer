using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay_Controller : MonoBehaviour
{
    public static GamePlay_Controller Instance;
    public GameObject[] Obstacle_Prefabs;
    public GameObject[] Zombie_Prefabs;
    public Transform[] Lanes;
    public float Min_ObstacleDelay=10f, Max_ObstacleDelay=40f;
    private float HalfGroundSize;
    private BaseController playerController;

    private Text _Score_Text;
    private int _Zombie_Kill_Count;

    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private Text Final_game_score;



    private void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        HalfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<Infinite_Ground>()._halfLength;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();

        StartCoroutine(GenerateObstacles());

        _Score_Text = GameObject.Find("ScoreText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeInstance()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance!=null)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator GenerateObstacles()
    {
        float Timer = Random.Range(Max_ObstacleDelay, Min_ObstacleDelay) / playerController._speed.z;
        yield return new WaitForSeconds(Timer);
        //here createobstacle taking z position of player and adding some distance to it where obstacle will be spawned because we will be able to see them from distance
        CreateObstacles(playerController.gameObject.transform.position.z + HalfGroundSize);
        StartCoroutine(GenerateObstacles());
    }

    void CreateObstacles(float zpos)
    {
        // here, we are making obstacle to not to spawn every time so, we use if(0<=r && r<7) because if this condition is true then only we spawn them here obstacle will not spawn if r =7,8,9,10.
        int r = Random.Range(0, 10);
        if(0<= r && r < 7)
        {
            int ObstacleLane = Random.Range(0, Lanes.Length);
            //
            AddObstacle(new Vector3(Lanes[ObstacleLane].transform.position.x, 0f, zpos), Random.Range(0, Obstacle_Prefabs.Length));
            // here, we are assigning zombies a diffrent lane from obstacle to avoid spawning at same position
            int zombieLane = 0;
            if(ObstacleLane == 0)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 1 : 2;
            } else if(ObstacleLane == 1)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (ObstacleLane == 2)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 1 : 0;
            }
            //we are giving add zombies its position argument
            AddZombies(new Vector3(Lanes[zombieLane].transform.position.x, 0.15f, zpos));

        }



    }


    void AddObstacle(Vector3 position ,int type)
    {
        GameObject Obstacle = Instantiate(Obstacle_Prefabs[type], position, Quaternion.identity);
        // here we are giving obstacle a rotation
       bool mirror = Random.Range(0, 2) == 1;

        switch (type)
        {
            case 0 : Obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;

            case 1:
                Obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 2:
                Obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -1 : 1, 0f);
                break;
            case 3:
                Obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f);
                break;

        } 

        Obstacle.transform.position = position;

    }

    // here, we are shifting the zombies position so that they do not spawn at same place and we use 0.5 because its is half the size of zombie
    void AddZombies(Vector3 pos)
    {
        int count = Random.Range(0, 3) + 1;
        for (int i = 0; i<count; i++)
        {
            Vector3 Shift = new Vector3(Random.Range(-0.5f,0.5f), 0f, Random.Range(1, 10) * i);
            Instantiate(Zombie_Prefabs[Random.Range(0, Zombie_Prefabs.Length)],
            pos + Shift * i ,Quaternion.identity);
        }


    }


    public void IncreaseScore()
    {
        _Zombie_Kill_Count++;
        _Score_Text.text = "" + _Zombie_Kill_Count;

    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;

    }
    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;

    }
    public void GameExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
        Final_game_score.text = "Killed: "+ _Zombie_Kill_Count;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene ("GamePlay");

    }
}
