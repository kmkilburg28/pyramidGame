using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour {

    public int numBones;
    public int numEnemies;
    public string textPrompt = "";

    Text prompt;
    Text boneBar;
    Text levelText;

    public GameObject startingChargeBone;

    GameObject pauseMenu;
    GameObject creditsMenu;
    GameObject deathMenu;
    GameObject map;

    private float level;

    private void Awake()
    {
        map = GameObject.Find("mapPyramid");
    }
    // Use this for initialization
    void Start()
    {

        level = SceneManager.GetActiveScene().buildIndex;

        prompt = GameObject.Find("Prompt").GetComponent<Text>();
        boneBar = GameObject.Find("BoneBar").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level: " + level;

        deathMenu = GameObject.Find("DeathCanvas");
        deathMenu.SetActive(false);

        pauseMenu = GameObject.Find("PauseCanvas");
        pauseMenu.SetActive(false);
    
        creditsMenu = GameObject.Find("CreditsCanvas");
        creditsMenu.SetActive(false);

        Time.timeScale = 1f;
        numBones = PlayerPrefs.GetInt("Player Score");
        map.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("hello");
            map.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("hello");
            map.SetActive(false);
        }

        if (numBones <= 0)
        {
            Time.timeScale = 0f;
            deathMenu.SetActive(true);
        }
        
        string boneString = "";
        for (int i = 1; i <= numBones; i++)
        {
            boneString += "|";
        }
        boneBar.text = "Number of Bones:  " + boneString;


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnChargeBone();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void AddText(string textToAdd)
    {
        prompt.text = textToAdd;
    }

    void SpawnChargeBone()
    {
        if (numBones > 1)
        {
            GameObject chargeBone = Instantiate(startingChargeBone, startingChargeBone.transform.position, startingChargeBone.transform.rotation, GameObject.Find("ThrowablePoint").GetComponent<Transform>());
            chargeBone.SetActive(true);
            numBones--;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeScene(string nextStage)
    {
        SceneManager.LoadScene(nextStage);
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void ResumeLevel()
    {
        Debug.Log(Time.timeScale);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}