using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    const int MAXTURN = 500;
    int turn = 0;
    int timeInterval = 0;
    
    CharacterManager Character1;
    CharacterManager Character2;
    InputManager IM;
    EventManager EM;
    CommandCompare CC;

	// Use this for initialization
	void Start () {
        turn = 0;
        timeInterval = 1;
        Character1 = GameObject.Find("Character1").GetComponent<CharacterManager>();
        Character2 = GameObject.Find("Character2").GetComponent<CharacterManager>();
        IM = GetComponent<InputManager>();
        CC = GetComponent<CommandCompare>();
        EM = GetComponent<EventManager>();


        TurnStart();
    }

    void Update ()
    {

    }

    void TurnStart()
    {
        turn += 1;
      //if(isCharacterCanMove(Character1) && isCharacterCanMove(Character2))
        Input();

    }

    void TurnEnd()
    {
        if(!isGameOver())
            TurnStart();
    }

    void Input()
    {
        IM.InputStart();
        Invoke(IM.InputEnd(), timeInterval);
    }

    public void Process(string character, string characterCommand)
    {
        int i;
        for(i = 0; i < characterCommand.Length; i++)
        {

            /*
            input form 
            characterCommand[i]

            characterState update
            */
        }
              
    }
    /*
    bool isCharacterCanMove(GameObject Character)
    {
        if(Character.state != Stunned )
    }
    */
    
    bool isGameOver()
    {
        /*
        if(chracter1.HP < 0 || charcter2.HP
            return true;
        */
        return true;
    }
}



