using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptCode : MonoBehaviour
{

    Text selfText;

    GManager GManager;


    // Use this for initialization
    void Start()
    {
        selfText = this.GetComponent<Text>();
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        selfText.text = GManager.textPrompt;
    }
}