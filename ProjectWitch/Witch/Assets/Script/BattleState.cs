using UnityEngine;
using System.Collections;

public class BattleState : MonoBehaviour {

    public GameObject DrawCardButton;
    public GameObject EndTurnButton;
    public GameObject Hand;
    public GameObject Board;
    public GameObject MonsterArea;
    public enum State
    {
        START,
        PLAYERCHOICE,
        STATUS_CALCULATE,
        PLAYER_ATTACK,
        ENEMY_ATTACK,
        DRAW,
        ENEMY_DEAFEAT,
        ENEMY_SPAWN,
        WIN,
        LOSE
    }

    private State currentState;
    private int isMove = 0;

	// Use this for initialization
	void Start () {
        currentState = State.START;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (State.START):
                //drawCards
                DrawCardButton.GetComponent<DrawCard>().getCard();

                //generate monster,ENEMY_SPAWN
                MonsterArea.GetComponent<SpawnMonster>().getCard();
                MonsterArea.GetComponent<SpawnMonster>().getCard();
                //go to PLAYERCHOICE
                currentState = State.PLAYERCHOICE;
                break;

            case (State.PLAYERCHOICE):
                isMove++;
                if (isMove == 1)
                {
                //Reset the END TURN BUTTON
                    EndTurnButton.GetComponent<EndTurn>().updateToOn();
                //let player move cards
                    for (int i = 0; i < Hand.transform.childCount; i++)
                    {
                        Hand.transform.GetChild(i).GetComponent<Draggable>().updateIsDragable();
                    }
                }
                //set up board, left to right stat calculation
                //lock player move cards when END TURN BUTTON HIT!
                if (EndTurnButton.GetComponent<EndTurn>().isButtonActive == false)
                {
                    Debug.Log("in loop the state is: " + EndTurnButton.GetComponent<EndTurn>().isButtonActive);
                    for (int i = 0; i < Hand.transform.childCount; i++)
                    {
                        Hand.transform.GetChild(i).GetComponent<Draggable>().updateIsDragable();
                    }
                    currentState = State.STATUS_CALCULATE;
                    isMove = 0;
                }
                break;

            case (State.STATUS_CALCULATE):
                //Stack attack, draw.. etc from left to right
                //go to PLAYER_ATTACK
                break;

            case (State.PLAYER_ATTACK):
                //Play Player animation
                //Attack monster
                //if monster->live, go to ENEMY_ATTACK
                //if monster->die, go to ENEMY_DEAFEAT
                break;
            case (State.ENEMY_ATTACK):
                //counter count down
                //if counter = 0; go to LOSE
                //if counter !=0; attack
                //go to DRAW
                break;

            case (State.DRAW):
                //if CARD < max, draw card
                //if CARD = max, destroy new card
                //go to PLAYERCHOICE;
                break;

            case (State.ENEMY_DEAFEAT):
                //if monster != lastMonster, spawn next, go to Draw
                //if monster = lastMonster, go to WIN
                break;

            case (State.WIN):
                //Open LOSE Screen
                //Prompt replay
                //if YES, reloop to START
                //if NO, terminate

                break;
            case (State.LOSE):
                //Open LOSE Screen
                //Prompt replay
                //if YES, reloop to START
                //if NO, terminate
                break;

        }
	}
}
