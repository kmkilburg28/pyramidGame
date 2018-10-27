using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour {

	public int numBones;

    public string textPrompt = "";

    Text prompt;


    // Use this for initialization
    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddText(string textToAdd)
    {
        prompt.text = textToAdd;
    }
}
