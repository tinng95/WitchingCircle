using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WitchRedTutorial : MonoBehaviour {

    public Button next;

    public GameObject bookButton;
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

    public GameObject book;
    //guide arrow
    public GameObject handGuide;
    public GameObject boardGuide;
    public GameObject healthGuide;
    public GameObject counterGuide;
    public GameObject endTurnGuide;
    //for game set-up
    public GameObject PopUp;
    public GameObject EndTurnButton;
    public GameObject ComboButton;
    public GameObject Hand;
    public GameObject Board;
    public GameObject MonsterArea;
    public enum State
    {
        START_DIALOG, //give more cards color
        DRAW_COLOR_CARD,
        EXPLAIN_BLUE_CARD,
        EXPLAIN_GREEN_CARD,
        EXPLAN_THE_CARD_COMBO_OPTION, //ONLY WORK WHEN PLAYING 2 CARDS
        DRAG_BLUE_RED_CARD,
        END_BUTTON_1,
        ATTACK_MONSTER,
        EXPLAIN_EXTRA_CARD,
        DRAW_2_CARD,
        DRAG_GREEN_GREEN_CARD,
        END_BUTTON_2,
        EXPLAIN_CONVERSION,
        DRAG_ALL_RED_CARD,
        END_BUTTON_3,
        ATTACK_MONSTER_2,
        END_DIALOG
    }

    private State currentState;
    private int isMove = 0;


    private GameObject temp;
    private GameObject temp2;
    private GameObject temp3;
    private GameObject temp4;
    private GameObject temp5;
    private GameObject temp6;

    // Use this for initialization
    void Start()
    {
        book.SetActive(false);

        bookButton.SetActive(false);
        next.onClick.AddListener(addLine);
        currentState = State.START_DIALOG;
        MonsterArea.GetComponent<SpawnMonster>().getSpecificCard("ELITE");
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusHealth(1);
        MonsterArea.transform.GetChild(0).GetComponent<CardTextModifier>().updateCardData();

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
        if (Board.transform.childCount == 2)
        {
            EndTurnButton.GetComponent<MageEndTurn>().checkHand();
        }
        else
        {
            EndTurnButton.GetComponent<HunterEndTurn>().damageCheck();
        }
        Debug.Log(currentState);
        switch (currentState)
        {

            case (State.START_DIALOG):
                startDialog();
                if (isMove == 1) { currentState = State.DRAW_COLOR_CARD; isMove = 0; };
                break;
            case (State.DRAW_COLOR_CARD):
                draw1();
                if (isMove == 1) { currentState = State.EXPLAIN_BLUE_CARD; isMove = 0; };
                break;
            case (State.EXPLAIN_BLUE_CARD):
                explainBlue();
                if (isMove == 1) { currentState = State.EXPLAIN_GREEN_CARD; isMove = 0; };
                break;
            case (State.EXPLAIN_GREEN_CARD):
                explainGreen();
                if (isMove == 1) { currentState = State.EXPLAN_THE_CARD_COMBO_OPTION; isMove = 0; };
                break;
            case (State.EXPLAN_THE_CARD_COMBO_OPTION):
                book.SetActive(true);
                bookButton.SetActive(true);
                explain_book_combo();
                if (isMove == 1) { currentState = State.DRAG_BLUE_RED_CARD; isMove = 0;
                    bookButton.SetActive(false);
                };
                break;
            case (State.DRAG_BLUE_RED_CARD):
                
                dragBlueRed();
                if (isMove == 1) { currentState = State.END_BUTTON_1; isMove = 0; };
                break;
            case (State.END_BUTTON_1):
                endButton1();
                if (isMove == 1) { currentState = State.ATTACK_MONSTER; isMove = 0; };
                break;
            case (State.ATTACK_MONSTER):
                attackMonster1();
                if (isMove == 1) { currentState = State.EXPLAIN_EXTRA_CARD; isMove = 0; };
                break;
            case (State.EXPLAIN_EXTRA_CARD):
                explainExtraCard();
                if (isMove == 1) { currentState = State.DRAW_2_CARD; isMove = 0; };
                break;
            case (State.DRAW_2_CARD):
                draw2Card();
                if (isMove == 1) { currentState = State.DRAG_GREEN_GREEN_CARD; isMove = 0; };
                break;
            case (State.DRAG_GREEN_GREEN_CARD):
                dragGreenGreen();
                if (isMove == 1) { currentState = State.END_BUTTON_2; isMove = 0; };
                break;
            case (State.END_BUTTON_2):
                endButton1();
                if (isMove == 1) { currentState = State.EXPLAIN_CONVERSION; isMove = 0; };
                break;
            case (State.EXPLAIN_CONVERSION):
                greenConversion();
                if (isMove == 1) { currentState = State.DRAG_ALL_RED_CARD; isMove = 0; };
                break;
            case (State.DRAG_ALL_RED_CARD):
                dragRedRed();
                if (isMove == 1) { currentState = State.END_BUTTON_3; isMove = 0; };
                break;
            case (State.END_BUTTON_3):
                endButton1();
                if (isMove == 1) { currentState = State.ATTACK_MONSTER_2; isMove = 0; };
                break;

            case (State.ATTACK_MONSTER_2):
                attackMonster2();
                if (isMove == 1) { currentState = State.END_DIALOG; isMove = 0; };
                break;
            case (State.END_DIALOG):
                endDialog();
                if (isMove == 1) { currentState = State.END_DIALOG; isMove = 0; };
                break;

        }
    }

    void startDialog()
    {
        if (DialogLines[CourrentLine].Contains("DRAW"))
        {
            Hand.GetComponent<DrawCard>().getSpecificCard("RED");
            CourrentLine++;
        }
        else
        {
            continuteDialog();
        }
    }

    void draw1()
    {
        if (DialogLines[CourrentLine].Contains("DRAW"))
        {
            Debug.Log("HELLLO!");
            StartCoroutine(drawCard("BLUE", "GREEN"));
            CourrentLine++;
        }
        else
        {
            continuteDialog();
        }
    }

    void explainBlue()
    {
        continuteDialog();
    }

    void explainGreen()
    {
        continuteDialog();
    }

    void explain_book_combo()
    {
        continuteDialog();
    }

    void dragBlueRed()
    {
        if (DialogLines[CourrentLine + 1].Contains("BUTTONOFF") && isMove != 4)
        {
            MainDialog.text = DialogLines[CourrentLine];
            isMove = 4;
            Hand.transform.GetChild(0).GetComponent<Draggable>().updateToTrueIsDragable();
            Hand.transform.GetChild(1).GetComponent<Draggable>().updateToTrueIsDragable();
            temp = Hand.transform.GetChild(0).gameObject;
            temp2 = Hand.transform.GetChild(1).gameObject;
            next.gameObject.SetActive(false);

        }
        if(isMove == 4)
        {
            if (temp.GetComponent<Draggable>().dragging == false
            && temp2.GetComponent<Draggable>().dragging == false
            && Board.transform.childCount == 2 && Hand.transform.childCount == 1)
            {
                CourrentLine += 2;
                isMove = 0;
                temp.GetComponent<Draggable>().updateToFalseIsDragable();
                temp2.GetComponent<Draggable>().updateToFalseIsDragable();
            }
        }
        continuteDialog();
    }

    void endButton1()
    {
        if (DialogLines[CourrentLine + 1].Contains("BUTTONOFF") && isMove != 3)
        {
            MainDialog.text = DialogLines[CourrentLine];
            isMove = 3;
            next.gameObject.SetActive(false);
            EndTurnButton.GetComponent<EndTurn>().updateToOn();
            EndTurnButton.GetComponent<HunterEndTurn>().damageCheck();
        }
        if (EndTurnButton.GetComponent<EndTurn>().isButtonActive == false && isMove == 3)
        {
            CourrentLine += 2;
            MainDialog.text = DialogLines[CourrentLine];
            next.gameObject.SetActive(true);
            isMove = 0;
        }
        continuteDialog();
    }

    void attackMonster1()
    {
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusHealth(2);
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusCounter(1);
        StartCoroutine(drawCard("GREEN", "NONE"));
        MonsterArea.transform.GetChild(0).GetComponent<CardTextModifier>().updateCardData();
        Destroy(temp);
        Destroy(temp2);
        currentState = State.EXPLAIN_EXTRA_CARD;
    }

    void explainExtraCard()
    {
        continuteDialog();
    }

    void draw2Card()
    {
        if (DialogLines[CourrentLine].Contains("DRAW"))
        {
            StartCoroutine(drawCard("GREEN", "GREEN"));
            CourrentLine++;
        }
        continuteDialog();
    }

    void dragGreenGreen()
    {
        if (DialogLines[CourrentLine + 1].Contains("BUTTONOFF") && isMove != 4)
        {
            MainDialog.text = DialogLines[CourrentLine];
            isMove = 4;
            Hand.transform.GetChild(0).GetComponent<Draggable>().updateToTrueIsDragable();
            Hand.transform.GetChild(1).GetComponent<Draggable>().updateToTrueIsDragable();
            Hand.transform.GetChild(2).GetComponent<Draggable>().updateToTrueIsDragable();
            Hand.transform.GetChild(3).GetComponent<Draggable>().updateToTrueIsDragable();
            //Hand.transform.GetChild(4).GetComponent<Draggable>().updateToTrueIsDragable();
            temp = Hand.transform.GetChild(0).gameObject;
            temp2 = Hand.transform.GetChild(1).gameObject;
            temp3 = Hand.transform.GetChild(2).gameObject;
            temp4 = Hand.transform.GetChild(3).gameObject;
            //temp5 = Hand.transform.GetChild(4).gameObject;
            next.gameObject.SetActive(false);

        }
        if (isMove == 4)
        {
            if (temp.GetComponent<Draggable>().dragging == false
            && temp2.GetComponent<Draggable>().dragging == false
            && temp3.GetComponent<Draggable>().dragging == false
            && temp4.GetComponent<Draggable>().dragging == false
            && Board.transform.childCount == 2 && Hand.transform.childCount == 2)
            {
                CourrentLine += 2;
                isMove = 0;
                temp.GetComponent<Draggable>().updateToFalseIsDragable();
                temp2.GetComponent<Draggable>().updateToFalseIsDragable();
                temp3.GetComponent<Draggable>().updateToFalseIsDragable();
                temp4.GetComponent<Draggable>().updateToFalseIsDragable();
                //temp5.GetComponent<Draggable>().updateToFalseIsDragable();
            }
        }
        continuteDialog();
    }

    void greenConversion()
    {
        if (DialogLines[CourrentLine + 1].Contains("CHOOSE") && isMove != 4)
        {
            next.gameObject.SetActive(false);
            MainDialog.text = DialogLines[CourrentLine];
            isMove = 4;
            for(int i  = 0; i <Hand.transform.childCount; i++)
            {
                Hand.transform.GetChild(0).GetComponent<Draggable>().updateToFalseIsDragable();
            }
            PopUp.GetComponent<DiscoverCard>().chooseCardRestricted("BLUE", "RED", false, true);
            for (int i = 0; i < Board.transform.childCount; i++)
            {
                Destroy(Board.transform.GetChild(i).gameObject);
            }
            CourrentLine+=2;
        }
        if (isMove == 4 && Hand.transform.GetChild(2).GetComponent<CardStats>().getName() == "RED")
        {
            next.gameObject.SetActive(true);
            isMove = 0;
        }
        continuteDialog();
    }

    void dragRedRed()
    {
        if (DialogLines[CourrentLine + 1].Contains("BUTTONOFF") && isMove != 4)
        {
            MainDialog.text = DialogLines[CourrentLine];
            isMove = 4;
            Hand.transform.GetChild(0).GetComponent<Draggable>().updateToTrueIsDragable();
            Hand.transform.GetChild(1).GetComponent<Draggable>().updateToTrueIsDragable();
            //Hand.transform.GetChild(2).GetComponent<Draggable>().updateToTrueIsDragable();
            temp = Hand.transform.GetChild(0).gameObject;
            temp2 = Hand.transform.GetChild(1).gameObject;
            //temp3 = Hand.transform.GetChild(2).gameObject;
            next.gameObject.SetActive(false);

        }
        if (isMove == 4)
        {
            if (temp.GetComponent<Draggable>().dragging == false
            && temp2.GetComponent<Draggable>().dragging == false
            && Board.transform.childCount == 2 && Hand.transform.childCount == 0)
            {
                CourrentLine += 2;
                isMove = 0;
                temp.GetComponent<Draggable>().updateToFalseIsDragable();
                temp2.GetComponent<Draggable>().updateToFalseIsDragable();
                //temp3.GetComponent<Draggable>().updateToFalseIsDragable();
            }
        }
        continuteDialog();
    }

    void attackMonster2()
    {
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusHealth(4);
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusCounter(1);
        MonsterArea.transform.GetChild(0).GetComponent<CardTextModifier>().updateCardData();
        for(int i = 0; i < Board.transform.childCount; i++)
        {
            Destroy(Board.transform.GetChild(i).gameObject);
        }
        currentState = State.END_DIALOG;
    }



    

    void continuteDialog()
    {

        if (isMove == 0)
        {
            if (DialogLines[CourrentLine].Contains("NEXT"))
            {
                isMove = 1;
                CourrentLine++;
            }
            else
            {
                MainDialog.text = DialogLines[CourrentLine];
            }
        }
        Debug.Log("Current Line: " + CourrentLine);
    }

    void endDialog()
    {

        if (DialogLines[CourrentLine].Contains("END"))
        {
            Debug.Log("Hello???!!!");
            this.GetComponent<ChangeScene>().loadScene();
        }
        else {
            continuteDialog();
        }
    }
    IEnumerator drawCard(string card1, string card2)
    {
        Debug.Log("DRAW PLEASE!!");
        Hand.GetComponent<DrawCard>().getSpecificCard(card1);
        yield return new WaitForSeconds(0.3f);

        if(card2 != "NONE")
        {
            Hand.GetComponent<DrawCard>().getSpecificCard(card2);
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
