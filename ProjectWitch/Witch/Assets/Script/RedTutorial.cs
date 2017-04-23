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
        ATTACK_MONSTER,
        EXPLAIN_MONSTER_HEALTH,
        EXPLAIN_MONSTER_COUNTER, //MONSTER ATTACK
        DRAW_2_CARD,
        EXPLAIN_COMBO,
        DRAG_2_CARDS,
        EXPLAIN_COMBO_IN_DETAL,
        ATTACK_MONSTER_2,
        MONSTER_DEATH,
        END_DIALOG
    }

    private State currentState;
    private int isMove = 0;


    private GameObject temp;
    private GameObject temp2;
    // Use this for initialization
    void Start () {
        next.onClick.AddListener(addLine);
        currentState = State.START_DIALOG;
        MonsterArea.GetComponent<SpawnMonster>().getSpecificCard("ELITE");


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
                if(isMove == 1) { currentState = State.EXPLAIN_HAND; isMove = 0; };
                break;
            case (State.EXPLAIN_HAND):
                explainHand();
                if (isMove == 1) { currentState = State.EXPLAIN_BOARD; isMove = 0; };
                break;
            case (State.EXPLAIN_BOARD):
                explainBoard();
                if (isMove == 1) { currentState = State.DRAG_CARD; isMove = 0; };
                break;
            case (State.DRAG_CARD):
                dragCard();
                if (isMove == 1) { currentState = State.EXPLAIN_END_TURN_BUTTON; isMove = 0; };
                break;
            case (State.EXPLAIN_END_TURN_BUTTON):
                explainEndTurnButton();
                if (isMove == 1) { currentState = State.ATTACK_MONSTER; isMove = 0; };
                break;
            case (State.ATTACK_MONSTER):
                attackMonser();
                break;
            case (State.EXPLAIN_MONSTER_HEALTH):
                explainMonsterHealth();
                if (isMove == 1) { currentState = State.EXPLAIN_MONSTER_COUNTER; isMove = 0; };
                break;
            case (State.EXPLAIN_MONSTER_COUNTER):
                explainMonsterCounter();
                if (isMove == 1) { currentState = State.DRAW_2_CARD; isMove = 0; };
                break;
            case (State.DRAW_2_CARD):
                draw2Card();
                if (isMove == 1) { currentState = State.EXPLAIN_COMBO; isMove = 0; };
                break;
            case (State.EXPLAIN_COMBO):
                explainCombo();
                if (isMove == 1) { currentState = State.DRAG_2_CARDS; isMove = 0; };
                break;
            case (State.DRAG_2_CARDS):
                dragCombo();
                if (isMove == 1) { currentState = State.EXPLAIN_COMBO_IN_DETAL; isMove = 0; };
                break;
            case (State.EXPLAIN_COMBO_IN_DETAL):
                detailExplain();
                if (isMove == 1) { currentState = State.ATTACK_MONSTER_2; isMove = 0; };
                break;
            case (State.ATTACK_MONSTER_2):
                attackMonsterCombo();
                if (isMove == 1) { currentState = State.MONSTER_DEATH; isMove = 0; };
                break;
            case (State.MONSTER_DEATH):
                next.gameObject.SetActive(true);
                monsterDeath();
                if (isMove == 1) { currentState = State.END_DIALOG; isMove = 0; };
                break;
            case (State.END_DIALOG):
                endDialog();
                break;
        }
    }

    void startDialog()
    {
        if(DialogLines[CourrentLine].Contains("DRAW"))
        {
            Hand.GetComponent<DrawCard>().getSpecificCard("RED");
            CourrentLine++;
        }
        else
        {
            continuteDialog();
        }
    }

    void explainHand()
    {
        continuteDialog();
    }

    void explainBoard()
    {
        continuteDialog();
    }

    void dragCard()
    {
        if (DialogLines[CourrentLine + 1].Contains("BUTTONOFF") && isMove != 2)
        {
            MainDialog.text = DialogLines[CourrentLine];
            isMove = 2;
            Hand.transform.GetChild(0).GetComponent<Draggable>().updateToTrueIsDragable();
            temp = Hand.transform.GetChild(0).gameObject;
            next.gameObject.SetActive(false);
        }
        if(temp.GetComponent<Draggable>().dragging == false && Board.transform.childCount == 1)
        {
            CourrentLine+= 2;
            isMove = 0;
            next.gameObject.SetActive(true);
            temp.GetComponent<Draggable>().updateToFalseIsDragable();
        }
        continuteDialog();
        
    }

    void explainEndTurnButton()
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
            CourrentLine+=2;
            MainDialog.text = DialogLines[CourrentLine];
            next.gameObject.SetActive(true);
            isMove = 0;
        }

        continuteDialog();
    }

    void attackMonser()
    {
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusHealth(1);
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusCounter(1);
        MonsterArea.transform.GetChild(0).GetComponent<CardTextModifier>().updateCardData();
        Destroy(temp);
        currentState = State.EXPLAIN_MONSTER_HEALTH;
    }

    void explainMonsterHealth()
    {
        continuteDialog();   
    }

    void explainMonsterCounter()
    {
        continuteDialog();
    }

    void draw2Card()
    {
        if (DialogLines[CourrentLine].Contains("DRAW"))
        {
            StartCoroutine(drawCard());
            CourrentLine++;
        }
        continuteDialog();
    }

    void explainCombo()
    {
        continuteDialog();
    }

    void dragCombo()
    {
        if (DialogLines[CourrentLine + 1].Contains("BUTTONOFF") && isMove != 4)
        {
            MainDialog.text = DialogLines[CourrentLine];
            isMove = 4;
            for(int i = 0; i < Hand.transform.childCount; i++)
            {
                Hand.transform.GetChild(i).GetComponent<Draggable>().updateToTrueIsDragable();
            }
            temp = Hand.transform.GetChild(0).gameObject;
            temp2 = Hand.transform.GetChild(1).gameObject;
            next.gameObject.SetActive(false);
            
        }
        if (temp.GetComponent<Draggable>().dragging == false
            && temp2.GetComponent<Draggable>().dragging == false
            && Board.transform.childCount == 2 && Hand.transform.childCount == 0 && isMove == 4)
        {
            CourrentLine += 2;
            isMove = 0;
            temp.GetComponent<Draggable>().updateToFalseIsDragable();
            temp2.GetComponent<Draggable>().updateToFalseIsDragable();
        }
        continuteDialog();
    }

    void detailExplain()
    {
        if (DialogLines[CourrentLine + 1].Contains("BUTTONOFF") && isMove != 5)
        {
            isMove = 5;
            next.gameObject.SetActive(false);
            EndTurnButton.GetComponent<EndTurn>().updateToOn();
            EndTurnButton.GetComponent<HunterEndTurn>().damageCheck();
        }
        if (EndTurnButton.GetComponent<EndTurn>().isButtonActive == false && isMove == 5)
        {
            CourrentLine += 2;
            MainDialog.text = DialogLines[CourrentLine];
            next.gameObject.SetActive(true);
            isMove = 0;
        }
        continuteDialog();
    }

    void attackMonsterCombo()
    {
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusHealth(3);
        MonsterArea.transform.GetChild(0).GetComponent<MonsterStats>().minusCounter(1);
        MonsterArea.transform.GetChild(0).GetComponent<CardTextModifier>().updateCardData();
        Destroy(temp);
        Destroy(temp2);
        currentState = State.MONSTER_DEATH;
    }

    void monsterDeath()
    {
        continuteDialog();
        if (DialogLines[CourrentLine].Contains("DESTROY")){
            Destroy(MonsterArea.transform.GetChild(0).gameObject);
            CourrentLine++;
        }
        
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
    IEnumerator drawCard()
    {
        Hand.GetComponent<DrawCard>().getSpecificCard("RED");
        yield return new WaitForSeconds(0.3f);
        Hand.GetComponent<DrawCard>().getSpecificCard("RED");
        yield return new WaitForSeconds(0.3f);
    }
}
