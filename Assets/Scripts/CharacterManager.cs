﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour {

    public CharacterStates state
    {
        get; set;
    }

    public int HP
    {
        get; set;
    }

    public float position
    {
        get; set;
    }

    public List <string> command         
    {
        get; set;
    }

    Slider SliderCom;
    int num=0;
    
	void Start () {
        state = CharacterStates.Rest;
        HP = 100;
        if (gameObject.name == "Character1") num = 1;
        else num = 2;
        SliderCom = GameObject.Find("Slider" + num.ToString()).GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        SliderCom.value = (float)HP / 100;
	}

    public enum CharacterStates

    {
        Rest,
        Dead,
        Move,
        Down,
        Jump,
        Attack,
        Guard,
        Grab
    }

}
