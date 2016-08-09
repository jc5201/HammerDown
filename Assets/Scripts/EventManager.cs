﻿using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    CharacterManager character1;
    CharacterManager character2;
    float position1=0;
    float position2=0;

    public Sprite[] sprite = new Sprite[30];

    // Use this for initialization
    void Start () {
        character1 = GameObject.Find("Character1").GetComponent<CharacterManager>();
        character2 = GameObject.Find("Character2").GetComponent<CharacterManager>();
    }
    
	
	// Update is called once per frame
	void Update () {
        if (position1 != character1.position)
        {
            position1 = character1.position;
            character1.gameObject.transform.position = new Vector3( -10 + position1, character1.gameObject.transform.position.y, character1.gameObject.transform.position.z);
        }
        if (position2 != character2.position)
        {
            position2 = character2.position;
            character2.gameObject.transform.position = new Vector3( -10 + position2, character2.gameObject.transform.position.y, character2.gameObject.transform.position.z);
        }
    }

    public void UpdateState(int code, string state)
    {
        if (code == 1)
        {
            
            character1.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprite[(int)System.Enum.Parse(typeof(CharacterManager.CharacterStates), state)];
        }
        else if ( code == 2)
        {
            character2.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprite[(int)System.Enum.Parse(typeof(CharacterManager.CharacterStates), state)];
        }
        // TODO: Sprite 교ㅕ체
    }
}
