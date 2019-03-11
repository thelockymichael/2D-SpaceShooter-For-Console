using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;

    public GameObject boss;
    public GameObject redNebulaBackground;
    public Transform bossSpawn;
    
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text newHighScoreText;
    public Text highScoreText;
    public Text gameOverText;
    public Text waveCounter;
    public Text bossIncoming;
    public Text powerUpTimerText;

    // PowerUp timer variables
    private bool powerUpTimeOut;
    private float powerUpTimer = 5f;
    public float firstPowerUpTimer = 5f;

    private float powerUpTimerLimit = 5f;

    public bool startPowerUpTimer;

    private float innerTimer;

    // Rocket Launcher
    public GameObject rocketIcon;

    private GameObject bossEnemy;

    // Sounds
    public AudioClip bossInComing;
    public AudioClip musicClip;

    private bool gameOver;
    private bool restart;
    private int score;

    int WaveCounter = 1;
    public int HazardCountIncrease = 1;
    public float SpawnSpeedIncrease = 0.001f;

    public bool Boss = false;

    private PlayerController playerController;
    void Start()
    {
        powerUpTimeOut = false;
        //powerUpTimer = 0f;

        powerUpTimerText.text = "";
        rocketIcon.SetActive(false);
        AudioSource audio = GetComponent<AudioSource>();

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();

        gameOver = false;
        restart = false;
        restartText.text = "";
        newHighScoreText.text = "";
        gameOverText.text = "";
        waveCounter.text = "";

        bossIncoming.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        highScoreText.text = "Hiscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void ShowRocketIcon()
    {
        playerController.rocketShot = true;
        rocketIcon.SetActive(true);

    }
    public void DisableRocketIcon()
    {
        rocketIcon.SetActive(false);

    }

    private void Update()
    {
        if (powerUpTimeOut)
        {
            Debug.Log("TIME OUT");
            startPowerUpTimer = false;
            powerUpTimeOut = false;

            powerUpTimerText.text = "";
            firstPowerUpTimer = powerUpTimer;
            playerController.FlameThrowerIsActive = false;
            playerController.FirePowerIsActive = false;

        }
        // return lat > 0 ? 'summer' : 'winter';

        if (startPowerUpTimer)
        {
            
         //   Mathf.RoundToInt(powerUpTimer);

            powerUpTimerText.text = Mathf.RoundToInt(firstPowerUpTimer).ToString();
            // powerUpTimer = 5f;
            firstPowerUpTimer -= Time.deltaTime;

            if (firstPowerUpTimer < 0)
            {
                powerUpTimeOut = true;
            }

        }


        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

            }
        }
    }

   public IEnumerator SpawnWaves()
    {
        waveCounter.text = "Wave: " + WaveCounter.ToString();
        AudioSource audio = GetComponent<AudioSource>();

        Boss = false;
        yield return new WaitForSeconds(startWait);
        while (true && !Boss)
        {

           

            // bossEnemy = GameObject.FindWithTag("EnemyBoss");
            // Debug.Log("Trying to find enemy boss.");

            // gameController = gameControllerObject.GetComponent<GameController>();
            hazardCount += (WaveCounter * HazardCountIncrease);
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;

                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait - (WaveCounter * SpawnSpeedIncrease));
                }
                yield return new WaitForSeconds(waveWait);
                WaveCounter++;
                waveCounter.text = "Wave: " + WaveCounter.ToString();
                Debug.Log("Wave " + WaveCounter);
                if (gameOver)
                {
                    restartText.text = "try again";
                    restart = true;
                    break;
                }

                if (WaveCounter % 3 == 0)
                {
                    Instantiate(redNebulaBackground, transform.position, transform.rotation);
                }

                if (WaveCounter % 4 == 0 && !Boss)
                {
                    bossIncoming.text = "boss\nahead";
                    audio.clip = bossInComing;
                    audio.Play();
                    yield return new WaitForSeconds(2.5f);
                    audio.Stop();
                    audio.clip = musicClip;
                    audio.Play();
                    bossIncoming.text = "";
                    Boss = true;
                    Instantiate(boss, bossSpawn, bossSpawn);
                    Debug.Log("Wave counter is dividable by 4");
                    break;
                }
            }
        }
  

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOverText.text = "game over";
        gameOver = true;
        scoreText.text = "Score: " + score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Hiscore : " + score.ToString();
            newHighScoreText.text = "New High \nScore!";
        }
    }
}