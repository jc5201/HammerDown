using UnityEngine;
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
        state = CharacterStates.Stand;
        HP = 100;
        command = new List<string>();
        if (gameObject.name == "Character1")
        {
            num = 1;
            position = 8;
        }
        else
        {
            num = 2;
            position = 12;
        }
        SliderCom = GameObject.Find("Slider" + num.ToString()).GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        SliderCom.value = (float)HP / 100;
	}

    public enum CharacterStates
    {
        Stand,
        Damage,
        Dead,
        Move, Dash, Move_Half,
        Down, Standing,
        Crouch,
        Jump,
        Attack_Fast,
        Attack_High, Attack_Middle, Attack_Low,
        Guard_Middle, Guard_Low,
        Grab_High, Grab_Middle, Grab_Low,
        Move_Back,Move_Back_Half,Dash_Back
    }

    public void Damage(int hit)
    {
        HP -= hit;
        command.Clear();
        state = CharacterStates.Damage;
    }

    public bool isAttack()
    {
        if (state >= CharacterManager.CharacterStates.Attack_Fast && state <= CharacterManager.CharacterStates.Attack_Low) return true;
        else return false;
    }

    public bool isGuard()
    {
        if (state == CharacterManager.CharacterStates.Guard_Middle || state == CharacterManager.CharacterStates.Guard_Low) return true;
        else return false;
    }

    public bool isGrab()
    {
        if (state == CharacterManager.CharacterStates.Grab_High || state == CharacterManager.CharacterStates.Grab_Middle || state == CharacterManager.CharacterStates.Grab_Low) return true;
        else return false;
    }

    public bool isMoving()
    {
        if (state >= CharacterManager.CharacterStates.Move && state <= CharacterManager.CharacterStates.Move_Half || state >= CharacterManager.CharacterStates.Move_Back && state <= CharacterManager.CharacterStates.Dash_Back) return true;
        else return false;
    }

    public void Move()
    {
        float n;
        if (num == 1) n = 1;
        else n = -1;
        switch (state)
        {
            case CharacterStates.Move:
            case CharacterStates.Dash:
                position += n * 1;
                break;
            case CharacterStates.Move_Half:
                position += n * 0.5f;
                break;
            case CharacterStates.Move_Back:
            case CharacterStates.Dash_Back:
                position += n * -1;
                break;
            case CharacterStates.Move_Back_Half:
                position += n * -0.5f;
                break;
        }
        if (position <= 0 || position >= 20)
        {
            state = CharacterStates.Dead;
            HP = 0;
        }
    }

}
