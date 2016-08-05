using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    const int MAXTURN = 500;
    int turn = 0;
    int timeInterval = 0;
    
    GameObject Character1;
    GameObject Character2;
    InputManager IM;
    EventManager EM;
    CommandCompare CC;

	// Use this for initialization
	void Start () {
        turn = 0;
        timeInterval = 1;
        Character1 = GameObject.Find("Character1");
        Character2 = GameObject.Find("Character2");
        IM = GetComponent<InputManager>();
        CC = GetComponent<CommandCompare>();
        EM = GetComponent<EventManager>();
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

    }

    void Input()
    {
        IM.InputStart();
        Invoke(IM.InputEnd(), timeInterval);
    }

    void Process(GameObject character, string characterCommand)
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
}



