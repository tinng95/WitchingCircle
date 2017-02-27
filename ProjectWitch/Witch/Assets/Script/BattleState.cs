﻿using UnityEngine;
using System.Collections;

public class BattleState : MonoBehaviour {

    public GameObject DrawCardButton;
    public GameObject EndTurnButton;
    public GameObject Hand;
    public GameObject Board;
    public GameObject MonsterArea;
    public GameObject Player;
    public GameObject Monster;
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

    public int MonsterNum;

    //private bool isLost = false; // extra
    private int damage;//extra
    private State currentState;
    private int isMove = 0;
    

	// Use this for initialization
	void Start () {
        currentState = State.START;
        Player.SetActive(false);
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
                
                for (int i = 0; i < MonsterArea.transform.childCount; i++)
                {
                    Debug.Log("Monster name is: " + MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getName());
                    Debug.Log("Monster Health is: " + MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getHealth());
                    Debug.Log("Monster Counter is: " + MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getCounter());
                }
                
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
                        Hand.transform.GetChild(i).GetComponent<Draggable>().updateToTrueIsDragable();
                    }
                }
                //set up board, left to right stat calculation
                //lock player move cards when END TURN BUTTON HIT!
                if (EndTurnButton.GetComponent<EndTurn>().isButtonActive == false)
                {
                    Debug.Log("in loop the state is: " + EndTurnButton.GetComponent<EndTurn>().isButtonActive);
                    for (int i = 0; i < Hand.transform.childCount; i++)
                    {
                        Hand.transform.GetChild(i).GetComponent<Draggable>().updateToFalseIsDragable();
                    }
                    currentState = State.STATUS_CALCULATE;
                    isMove = 0;
                }
                break;

            case (State.STATUS_CALCULATE):
                //Stack attack, draw.. etc from left to right
                //remove cards on board
                
                for (int i = 0; i < Board.transform.childCount; i++)
                {
                    damage++;
                    Destroy(Board.transform.GetChild(i).gameObject);
                }
                //go to PLAYER_ATTACK
                currentState = State.PLAYER_ATTACK;
                break;

            case (State.PLAYER_ATTACK):
                //Play Player animation
                if (isMove == 0)
                {
                    Player.GetComponent<PlayerAttack>().playerAttack();
                    isMove++;
                } 
                else {
                    if (Player.GetComponent<PlayerAttack>().isVisible == false)
                    {
                        //Attack monster
                        Debug.Log("ATTACK MONSTER WITH: " + damage + " damage");
                        for (int i = 0; i < MonsterArea.transform.childCount; i++)
                        {
                            MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().minusHealth(damage);
                            Debug.Log("Current monster health is: " +
                         MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getHealth());
                        }
                        damage = 0;
                        //if monster->live, go to ENEMY_ATTACK
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
                break;

            case (State.ENEMY_ATTACK):
                //counter count down
                if (isMove == 0)
                {
                    for (int i = 0; i < MonsterArea.transform.childCount; i++)
                    {
                        MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().minusCounter(1);
                        Debug.Log("Current monster counter is: " +
                             MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getCounter());
                    }
                    //if counter = 0; go to LOSE
                    for (int i = 0; i < MonsterArea.transform.childCount; i++)
                    {
                        if (MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getCounter() <= 0)
                        {
                            currentState = State.LOSE;
                        }
                    }
                    if(currentState != State.LOSE)
                    {
                        Monster.GetComponent<PlayerAttack>().playerAttack();
                        isMove++;
                    }
                }
                else {
                    //if counter !=0; show anymation, GO TO DRAW
                    if (Monster.GetComponent<PlayerAttack>().isVisible == false)
                    {
                        isMove = 0;
                        currentState = State.DRAW;
                    }
                }
                
            
                
                //go to DRAW
                break;

            case (State.DRAW):
                //if CARD < max, draw card
                //if CARD = max, destroy new card
                DrawCardButton.GetComponent<DrawCard>().getCard();
                //go to PLAYERCHOICE;
                currentState = State.PLAYERCHOICE;
                break;

            case (State.ENEMY_DEAFEAT):
                //if monster != lastMonster, spawn next, go to Draw
                MonsterNum--;
                if ( MonsterNum > 0)
                {
                    Debug.Log("Spawn new Monster!");
                    MonsterArea.GetComponent<SpawnMonster>().getCard();
                    Debug.Log("NUM leftover monster is:" + MonsterNum);
                    currentState = State.DRAW;
                }
                //if monster = lastMonster, go to WIN
                else
                {
                    currentState = State.WIN;
                }
                break;

            case (State.WIN):
                //Open LOSE Screen
                Debug.Log("CONGRAT, YOU HAVE WON THIS STAGE!!!");
                //Prompt replay
                //if YES, reloop to START
                //if NO, terminate

                break;
            case (State.LOSE):
                //Open LOSE Screen
                Debug.Log("Sorry, you lost.");
                //Prompt replay
                //if YES, reloop to START
                //if NO, terminate
                break;

        }
	}
    
}
