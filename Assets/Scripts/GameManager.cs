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

	// Use this for initialization
	void Start () {
        turn = 0;
        timeInterval = 1;
        Character1 = GameObject.Find("Character1").GetComponent<CharacterManager>();
        Character2 = GameObject.Find("Character2").GetComponent<CharacterManager>();
        IM = GetComponent<InputManager>();
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

    public void Process(string character1Cmd, string character2Cmd)
    {
        int i;
        for(i = 0; i < character1Cmd.Length; i++)
        { 
        }
        for(i = 0; i < character2Cmd.Length; i++)
        {

        }
              
    }
   
    bool isCharacterCanMove(CharacterManager Character)
    {
        if (Character.state != CharacterManager.CharacterStates.Rest)
            return true;
        return false;
    }
    
    
    bool isGameOver()
    {
        /*
        if(chracter1.HP < 0 || charcter2.HP
            return true;
        */
        return true;
    }
}



