using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RedTutorial : MonoBehaviour {

    public Button next;

    //for tutorial dialog
    public TextAsset TextFile;
    public string[] DialogLines;

    public GameObject DialogBox;
    public GameObject LeftCharacter;
    public GameObject RightCharacter;

    public Text MainDialog;
    public Text LeftCharDialog;
    public Text RightCharDialog;

    private int CourrentLine = 0; // keeps track of courent line
    private int EndLine; // stops script at the end of the text

    public bool DialogBoxActive = true;

    //for game set-up
    public GameObject PopUp;
    public GameObject EndTurnButton;
    public GameObject ComboButton;
    public GameObject Hand;
    public GameObject Board;
    public GameObject MonsterArea;
    public enum State
    {
        START_DIALOG,
        EXPLAIN_HAND,
        EXPLAIN_BOARD,
        DRAG_CARD,
        EXPLAIN_END_TURN_BUTTON,
        EXPLAIN_MONSTER_HEALTH,
        EXPLAIN_MONSTER_COUNTER, //MONSTER ATTACK
        DRAW_2_CARD,
        EXPLAIN_COMBO,
        DRAG_2_CARDS,
        MONSTER_DEATH,
        END_DIALOG
    }

    private State currentState;
    private int isMove = 0;

    // Use this for initialization
    void Start () {
        next.onClick.AddListener(addLine);
        currentState = State.START_DIALOG;

        if (TextFile != null)
        {
            DialogLines = (TextFile.text.Split('\n'));
        }

        if (EndLine == 0)
        {
            EndLine = DialogLines.Length - 1;
        }
    }
    void addLine()
    {
        CourrentLine++;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            
            case (State.START_DIALOG):
                startDialog();
                break;
            case (State.EXPLAIN_HAND):
                explainHand();
                break;
            case (State.EXPLAIN_BOARD):
                explainBoard();
                break;
            case (State.DRAG_CARD):
                break;
            case (State.EXPLAIN_END_TURN_BUTTON):
                break;
            case (State.EXPLAIN_MONSTER_HEALTH):
                break;
            case (State.EXPLAIN_MONSTER_COUNTER):
                break;
            case (State.DRAW_2_CARD):
                break;
            case (State.EXPLAIN_COMBO):
                break;
            case (State.DRAG_2_CARDS):
                break;
            case (State.MONSTER_DEATH):
                break;
            case (State.END_DIALOG):
                break;
        }
    }

    void startDialog()
    {
        if(DialogLines[CourrentLine].Contains("DRAW"))
        {
            Debug.Log("IN RED!");
            Hand.GetComponent<DrawCard>().getSpecificCard("RED");
            CourrentLine++;
        }
        else if(DialogLines[CourrentLine].Contains("NEXT"))
        {
            Debug.Log("IN NEXT!");
            currentState = State.EXPLAIN_HAND;
            CourrentLine++;
        }
        else
        {
            MainDialog.text = DialogLines[CourrentLine];
        }
    }

    void explainHand()
    {
        if (DialogLines[CourrentLine].Contains("NEXT"))
        {
            Debug.Log("IN NEXT!");
            currentState = State.EXPLAIN_BOARD;
        }
        else
        {
            MainDialog.text = DialogLines[CourrentLine];
        }
    }

    void explainBoard()
    {
        if (DialogLines[CourrentLine].Contains("NEXT"))
        {
            Debug.Log("IN NEXT!");
            currentState = State.EXPLAIN_BOARD;
            CourrentLine++;
        }
        else
        {
            MainDialog.text = DialogLines[CourrentLine];
        }
    }

}
