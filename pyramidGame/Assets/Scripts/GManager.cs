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

    public GameObject startingChargeBone;

    GameObject pauseMenu;
    GameObject creditsMenu;
    GameObject deathMenu;


    // Use this for initialization
    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<Text>();
        boneBar = GameObject.Find("BoneBar").GetComponent<Text>();

        deathMenu = GameObject.Find("DeathCanvas");
        deathMenu.SetActive(false);

        pauseMenu = GameObject.Find("PauseCanvas");
        pauseMenu.SetActive(false);
    
        creditsMenu = GameObject.Find("CreditsCanvas");
        creditsMenu.SetActive(false);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       if(numBones <= 0)
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
        if (numBones > 1 || true)
        {
            GameObject chargeBone = Instantiate(startingChargeBone, startingChargeBone.transform.position, startingChargeBone.transform.rotation, GameObject.Find("ThrowablePoint").GetComponent<Transform>());
            chargeBone.SetActive(true);
            numBones--;
        }
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