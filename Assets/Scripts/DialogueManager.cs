using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    //Path to the json project
    public string jsonFilePath;
    public bool spaceToAdvance;
    public TextMeshProUGUI textTattooGuy;
    public TextMeshProUGUI textCustomer;

    public string nextScene;

    private List<DialogueItem> items;
    private int currentId = 0;
    private float timerChange;

    private GameManager gameManager;


    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        jsonFilePath = LoadJson(jsonFilePath);
        items = new List<DialogueItem>();
        timerChange = 0;
    }

    private string LoadJson(string jsonName)
    {
        return Application.dataPath + "/Dialogues/" + jsonFilePath;
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        items = DialogueLoader.LoadDialogue(jsonFilePath);

        if (items[currentId].author.Equals("Cliente")){
            textCustomer.text = items[currentId].message;
        } else
        {
            textTattooGuy.text = items[currentId].message;
        }
        
    }

    private void Update()
    {

        if (gameManager.state.Equals(GameState.INTRO))
        {
            StartIntroDialogue();
        }

    }

    // Update is called once per frame
    private void StartIntroDialogue()
    {
        if (items != null && items.Count > 0)
        {

            if (spaceToAdvance)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (currentId < items.Count - 1)
                    {
                        currentId++;


                        if (items[currentId].author.Equals("Cliente"))
                        {
                            textTattooGuy.gameObject.SetActive(false);
                            textTattooGuy.text = "";
                            textCustomer.gameObject.SetActive(true);
                            textCustomer.text = items[currentId].message;
                        }
                        else
                        {
                            textCustomer.gameObject.SetActive(false);
                            textCustomer.text = "";
                            textTattooGuy.gameObject.SetActive(true);
                            textTattooGuy.text = items[currentId].message;
                        }

                    }
                    else
                    {
                        currentId++;
                    }



                }
            }
        }
    }



}
