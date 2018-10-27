using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour {

	public int numBones;

    public string textPrompt = "";

    Text prompt;

    Text boneBar;


    // Use this for initialization
    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<Text>();
        boneBar = GameObject.Find("BoneBar").GetComponent<Text>();
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
    }

    public void AddText(string textToAdd)
    {
        prompt.text = textToAdd;
    }
}
