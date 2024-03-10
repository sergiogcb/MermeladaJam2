using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    private static List<DialogueItem> dialogueItems;

    public static List<DialogueItem> LoadDialogue(string jsonFilePath)
    {
        string jsonText = File.ReadAllText(jsonFilePath);

        //Debug.Log("JSON TEXT " + jsonText);

        dialogueItems = JsonConvert.DeserializeObject<List<DialogueItem>>(jsonText);

        //Debug.Log("TAMANIO LISTA DIALOGOS" + dialogueItems.Count);

        return dialogueItems;
    }
}
