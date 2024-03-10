using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public string jsonFilePath;// Ruta del archivo JSON en el proyecto
    public bool spaceToAdvance;
    public TextMeshProUGUI text;
    public string nextScene;

    private List<DialogueItem> items;
    private int currentId = 0;
    private float timerChange;

    public static DialogueManager Instance { get; private set; }

    private bool isFinished = false;

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

        jsonFilePath = Application.dataPath + "/Dialogues/" + jsonFilePath;
        items = new List<DialogueItem>();
        timerChange = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        items = DialogueLoader.LoadDialogue(jsonFilePath);

        text.text = items[currentId].message;
    }

    // Update is called once per frame
    void Update()
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
                        text.text = items[currentId].message;
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
