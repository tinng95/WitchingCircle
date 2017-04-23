using UnityEngine;
using System.Collections;

public class BattleState : MonoBehaviour {
    public GameObject PopUp;
    public GameObject EndTurnButton;
    public GameObject ComboButton;
    public GameObject Hand;
    public GameObject Board;
    public GameObject MonsterArea;
    public GameObject MageAttack;
    public GameObject HunterAttack;
    public GameObject EndScreen;
    private GameObject board;
    public enum State
    {
        START,
        PLAYERCHOICE,
        STATUS_CALCULATE,
        PLAYER_ATTACK,
        MAGE_ATTACK,
        HUNTER_ATTACK,
        ENEMY_ATTACK,
        DRAW,
        ENEMY_DEAFEAT,
        ENEMY_SPAWN,
        WIN,
        LOSE
    }

    public int MonsterNum;

    //private bool isLost = false; // extra
    private int damage;//extra
    private State currentState;
    private int isMove = 0;
    

	// Use this for initialization
	void Start () {
        currentState = State.START;
        this.board = Board;
        board.GetComponent<CardCombo>().setCombo();
        EndScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (State.START):
                //drawCards
                //generate monster,ENEMY_SPAWN
                //go to PLAYERCHOICE
                startState();
                break;

            case (State.PLAYERCHOICE):
                //Reset the END TURN BUTTON
                //let player move cards
                //set up board, left to right stat calculation
                //lock player move cards when END TURN BUTTON HIT!
                playerChoiceState();
                break;

            case (State.MAGE_ATTACK):
                mageAttackState();
                break;

            case (State.HUNTER_ATTACK):
                hunterAttackState();
                break;

            case (State.STATUS_CALCULATE):
                //If card == 2, do COMBO
                //ELSE, Attack monster
                //remove cards on boar
                ////if monster->live, go to ENEMY_ATTACK
                //if monster->die, go to ENEMY_DEAFEAT
                statCalculateState();
                break;

            case (State.ENEMY_ATTACK):
                //counter count down
                //if counter = 0; go to LOSE
                //if counter !=0; show anymation, GO TO DRAW
                //go to DRAW
                enemyAttackState();
                break;

            case (State.DRAW):
                //if CARD < max, draw card
                //if CARD = max, destroy new card
                //go to PLAYERCHOICE;
                drawState();
                break;

            case (State.ENEMY_DEAFEAT):
                //if monster != lastMonster, spawn next, go to Draw
                //if monster = lastMonster, go to WIN
                enemyDefeatState();
                break;

            case (State.WIN):
                //Open LOSE Screen
                //Prompt replay
                //if YES, reloop to START
                //if NO, terminate
                winState();
                break;

            case (State.LOSE):
                //Open LOSE Screen
                //Prompt replay
                //if YES, reloop to START
                //if NO, terminate
                loseState();
                break;

        }
	}

    void startState() {
        //drawCards
        Hand.GetComponent<DrawCard>().getCard(5, false);

        //generate monster,ENEMY_SPAWN
        //MonsterArea.GetComponent<SpawnMonster>().getCard();
        MonsterArea.GetComponent<SpawnMonster>().getSpecificCard("RANDOM");

        //go to PLAYERCHOICE
        currentState = State.PLAYERCHOICE;
    }

    void playerChoiceState()
    {
        isMove++;
        if (isMove == 1)
        {
            //Reset the END TURN BUTTON
            EndTurnButton.GetComponent<EndTurn>().updateToOn();
            ComboButton.GetComponent<EndTurn>().updateToOff();
            //let player move cards
            for (int i = 0; i < Hand.transform.childCount; i++)
            {
                Hand.transform.GetChild(i).GetComponent<Draggable>().updateToTrueIsDragable();
            }
        }

        //set up board, left to right stat calculation
        
        ComboButton.GetComponent<MageEndTurn>().checkHand();
        EndTurnButton.GetComponent<HunterEndTurn>().damageCheck();
        //lock player move cards when END TURN BUTTON HIT!
        if (EndTurnButton.GetComponent<EndTurn>().isButtonActive == false || ComboButton.GetComponent<EndTurn>().isButtonActive == true)
        {

            if (EndTurnButton.GetComponent<EndTurn>().isButtonActive == false)
            {
                currentState = State.HUNTER_ATTACK;
            }
            else if (ComboButton.GetComponent<EndTurn>().isButtonActive == true)
            {



                currentState = State.MAGE_ATTACK;
            }
            EndTurnButton.GetComponent<EndTurn>().updateToOff();
            ComboButton.GetComponent<EndTurn>().updateToOff();
            for (int i = 0; i < Hand.transform.childCount; i++)
            {
                Hand.transform.GetChild(i).GetComponent<Draggable>().updateToFalseIsDragable();
            }
            //currentState = State.PLAYER_ATTACK;
            isMove = 0;
        }
    }

    void mageAttackState()
    {
        if (isMove == 0)
        {
            MageAttack.GetComponent<PlayerAttack>().playerAttack();
            isMove++;
        }
        //move to STATUS_CALCULATE
        else {
            if (MageAttack.GetComponent<PlayerAttack>().isVisible == false)
            {
                isMove = 0;
                Board.GetComponent<CardCombo>().comboCheck();
                Board.GetComponent<CardCombo>().comboAction();
                currentState = State.STATUS_CALCULATE;
            }

        }
    }

    void hunterAttackState()
    {
        if (isMove == 0)
        {
            HunterAttack.GetComponent<PlayerAttack>().playerAttack();
            isMove++;
        }
        //move to STATUS_CALCULATE
        else {
            if (HunterAttack.GetComponent<PlayerAttack>().isVisible == false)
            {
                isMove = 0;
                for (int i = 0; i < Board.transform.childCount; i++)
                {
                    damage++;
                }
                //Debug.Log("ATTACK MONSTER WITH: " + damage + " damage");
                for (int i = 0; i < MonsterArea.transform.childCount; i++)
                {
                    MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().minusHealth(damage);
                    MonsterArea.transform.GetChild(i).GetComponent<CardTextModifier>().updateCardData();
                }
                damage = 0;
                currentState = State.STATUS_CALCULATE;
            }

        }
    }

    void statCalculateState()
    {
        //remove cards on boar
        if (PopUp.GetComponent<DiscoverCard>().getIsDisUp() == false)
        {
            for (int i = 0; i < Board.transform.childCount; i++)
            {
                Destroy(Board.transform.GetChild(i).gameObject);
            }
            ////if monster->live, go to ENEMY_ATTACK
            if (MonsterArea.GetComponentInChildren<MonsterStats>().getHealth() > 0)
            {
                currentState = State.ENEMY_ATTACK;
            }

            //if monster->die, go to ENEMY_DEAFEAT
            else
            {
                Destroy(MonsterArea.transform.GetChild(0).gameObject);
                currentState = State.ENEMY_DEAFEAT;
            }
            isMove = 0;
        }
    }

    void enemyAttackState()
    {
        //counter count down
        if (isMove == 0)
        {
            isMove++;
            for (int i = 0; i < MonsterArea.transform.childCount; i++)
            {
                MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().minusCounter(1);
                MonsterArea.transform.GetChild(i).GetComponent<CardTextModifier>().updateCardData();
            }
            //if counter = 0; go to LOSE
            for (int i = 0; i < MonsterArea.transform.childCount; i++)
            {
                if (MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getCounter() <= 0)
                {
                    currentState = State.LOSE;
                }
            }
            //if counter !=0; show anymation, GO TO DRAW
            if (currentState != State.LOSE)
            {
                //Monster.GetComponent<PlayerAttack>().playerAttack();

                StartCoroutine(HoldTime(1.5f));

                
                //monsterAttack

            }
        }
        else {
            if (MonsterArea.GetComponent<MonsterAttack>().isDestroyed == true)
            {
                MonsterArea.GetComponent<MonsterAttack>().isDestroyed = false;
                isMove = 0;
                currentState = State.DRAW;
            }
        }
        //go to DRAW
    }

    void drawState()
    {
        //if CARD < max, draw card
        //if CARD = max, destroy new card
        Hand.GetComponent<DrawCard>().getCard(2, true);
        //go to PLAYERCHOICE;
        currentState = State.PLAYERCHOICE;
    }

    void enemyDefeatState()
    {
        //if monster != lastMonster, spawn next, go to Draw
        MonsterNum--;
        Debug.Log("CURRENT MONSTER NUMBER IS: "+ MonsterNum);
        if (MonsterNum > 0)
        {
            if (MonsterNum == 1)
            {
                Debug.Log("Spawn FINAL BOSS!");
                MonsterArea.GetComponent<SpawnMonster>().getSpecificCard("NZOTH");
            }
            else if (MonsterNum == 2)
            {
                Debug.Log("Spawn Mini BOSS!");
                MonsterArea.GetComponent<SpawnMonster>().getSpecificCard("DEATHWING");
                //MonsterArea.GetComponent<SpawnMonster>().getCard();
            }
            else if (MonsterNum > 2)
            {
                Debug.Log("Spawn new Monster!");
                MonsterArea.GetComponent<SpawnMonster>().getSpecificCard("RANDOM");
            }
            currentState = State.DRAW;
        }
        //if monster = lastMonster, go to WIN
        else
        {
            currentState = State.WIN;
        }
    }

    void winState()
    {
        //Open LOSE Screen
        Debug.Log("CONGRAT, YOU HAVE WON THIS STAGE!!!");
        EndScreen.GetComponent<EndGame>().setCondition("WIN");
        EndScreen.SetActive(true);
        //Prompt replay
        //if YES, reloop to START
        //if NO, terminate
        //EndScreen.GetComponent<EndGame>().pick();
    }

    void loseState()
    {
        //Open LOSE Screen
        Debug.Log("Sorry, you lost.");
        EndScreen.GetComponent<EndGame>().setCondition("LOSE");
        EndScreen.SetActive(true);
        //Prompt replay
        //if YES, reloop to START
        //if NO, terminate
        //EndScreen.GetComponent<EndGame>().pick();
    }

    IEnumerator HoldTime(float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        MonsterArea.GetComponent<MonsterAttack>().attack();
        Debug.Log("DONG ATTACK");
    }

}

