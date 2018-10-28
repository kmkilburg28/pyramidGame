using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour {

	public int numBones;
    public int numEnemies;
    public string textPrompt = "";

    private 

    Text prompt;

    Text boneBar;

    public GameObject startingChargeBone;

    GameObject pauseMenu;


    // Use this for initialization
    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<Text>();
        boneBar = GameObject.Find("BoneBar").GetComponent<Text>();
        pauseMenu = GameObject.Find("PauseCanvas");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
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
    }

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
    }

    public void ResumeLevel()
    {
        pauseMenu.SetActive(false);
    }
}