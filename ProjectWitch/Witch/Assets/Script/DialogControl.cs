using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    public Button next;
    public Button skip;
    public string LeftCharName;
    public string RightCharName;

    public GameObject DialogBox;
    public GameObject LeftCharacter;
    public GameObject RightCharacter;

    public Text MainDialog;
    public Text LeftCharDialog;
    public Text RightCharDialog;

    public bool DialogBoxActive = true; // initialises dialog box

    public TextAsset TextFile;
    public string[] DialogLines;

    private int CourrentLine; // keeps track of courent line
    private int EndLine; // stops script at the end of the text

    private string EndString = "END";
    private string BothString = "BOTH";
    private string NoneString = "NONE";


    public GameObject redImage;
    public GameObject witchImage;
    // Use this for initialization
    void Start()
    {
        witchImage.gameObject.SetActive(false);
        redImage.gameObject.SetActive(false);
        skip.gameObject.SetActive(false);
        skip.onClick.AddListener(Change);
        RightCharDialog.text = RightCharName;
        LeftCharDialog.text = LeftCharName;
        if (TextFile != null)
        {
            DialogLines = (TextFile.text.Split('\n'));
        }

        if (EndLine == 0)
        {
            EndLine = DialogLines.Length - 1;
        }
        DisableEnemyNameBox();
        next.onClick.AddListener(TaskOnClick);

        Debug.Log("Total Line: " + EndLine);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogLines[CourrentLine].Contains(LeftCharName))
        {
            redImage.gameObject.SetActive(true);
            witchImage.gameObject.SetActive(false);
            DisableEnemyNameBox();
            EnableCharacterNameBox();
            CourrentLine++;
        }
        else if (DialogLines[CourrentLine].Contains(RightCharName))
        {
            redImage.gameObject.SetActive(false);
            witchImage.gameObject.SetActive(true);
            DisableCharacterNameBox();
            EnableEnemyNameBox();
            CourrentLine++;
        }
        else if (DialogLines[CourrentLine].Contains(BothString))
        {
            Debug.Log("BOTH");
            DialogBox.SetActive(true);
            LeftCharacter.SetActive(true);
            RightCharacter.SetActive(true);
            CourrentLine++;
        }
        else if (DialogLines[CourrentLine].Contains(NoneString))
        {
            redImage.SetActive(false);
            witchImage.SetActive(false);
            Debug.Log("NONE");
            DialogBox.SetActive(true);
            LeftCharacter.SetActive(false);
            RightCharacter.SetActive(false);
            CourrentLine++;
        }
        else if (DialogLines[CourrentLine].Contains(EndString))
        {
            DialogBox.SetActive(false);
            LeftCharacter.SetActive(false);
            RightCharacter.SetActive(false);
            DialogBoxActive = false;
            next.GetComponent<ChangeScene>().loadScene();
        }

        
        
        MainDialog.text = DialogLines[CourrentLine];
        if (DialogBoxActive == false)
        {
            DisableCharacterNameBox();
            DisableEnemyNameBox();
        }
        if (CourrentLine == 5)
        {
            Debug.Log("HELLLO!");
            skip.gameObject.SetActive(true);
        }
    }

    void Change()
    {
        skip.GetComponent<ChangeScene>().loadScene();
    }
    void TaskOnClick()
    {
        if(CourrentLine < EndLine)
        {
            CourrentLine++;
        }
        Debug.Log("Just Changed Line: " + CourrentLine);
    }

    // turns on dialog, character and enemy name boxes
    public void EnableDialogBox()
    {
        DialogBox.SetActive(true); // turns on dialog box
    }
    public void EnableCharacterNameBox()
    {
        LeftCharacter.SetActive(true); // turns on character name box
    }
    public void EnableEnemyNameBox()
    {
        RightCharacter.SetActive(true); // turns on enemy name box
    }
    //turns off dialog, character and enemy name boxes
    public void DisableDialogBox()
    {
        DialogBox.SetActive(false); // turns off dialog box
    }
    public void DisableCharacterNameBox()
    {
        LeftCharacter.SetActive(false); // turns off character name box
    }
    public void DisableEnemyNameBox()
    {
        RightCharacter.SetActive(false); // Turns off enemy name box
    }

    //Reload the script with diffrent textfile for diffrent scenes????
    public void ReloadScript(TextAsset NewTextFile)
    {
        if (TextFile != null)
        {
            DialogLines = new string[1];
            DialogLines = (NewTextFile.text.Split('\n'));
        }
    }
}
