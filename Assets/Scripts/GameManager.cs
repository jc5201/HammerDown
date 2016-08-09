using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Timers;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{

    const int MAXTURN = 500;
    int turn = 0;
    int timeInterval = 0;

    CharacterManager Character1;
    CharacterManager Character2;
    InputManager IM;
    EventManager EM;
    Timer timer = new Timer();

    Slider timeSlider;
    DateTime initTime;
    Text turnText;
    string tempText = "000";

    // Use this for initialization
    void Start()
    {
        turn = 0;
        timeInterval = 1000;
        timer.Interval = timeInterval;
        timer.Elapsed += new ElapsedEventHandler(TimerEventProcessor);
        Character1 = GameObject.Find("Character1").GetComponent<CharacterManager>();
        Character2 = GameObject.Find("Character2").GetComponent<CharacterManager>();
        IM = GetComponent<InputManager>();
        EM = GetComponent<EventManager>();

        timeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();
        turnText = GameObject.Find("TurnText").GetComponent<Text>();

        

        TurnStart();
    }

    void Update()
    {
        turnText.text = tempText;

        if (timer.Enabled)
        {
            timeSlider.value = (float)(DateTime.Now.Ticks - initTime.Ticks) / 10000000;
        }
        else
        {
            timeSlider.value = 0;
        }
    }

    void TurnStart()
    {
        Debug.Log("TurnStart");
        turn += 1;
        tempText = turn.ToString("D3");
        Input();

    }

    void TurnEnd()
    {
        Debug.Log("Turn End Start");
        if (!isGameOver())
            TurnStart();
        // else gameResult ...etc
    }

    void Input()
    {
        IM.InputStart();
        initTime = DateTime.Now;
        if(Character1.state == CharacterManager.CharacterStates.Stand || Character1.state == CharacterManager.CharacterStates.Stand) timer.Start();
        else
        {
            Process("", "");
        }
        
    }

    void TimerEventProcessor(object myObject, EventArgs myEventArgs)
    {
        timer.Enabled = false;
        IM.InputEnd();
    }

    public void Process(string character1Cmd, string character2Cmd)
    {
        Debug.Log("Process Start\n" + character1Cmd + "\n" + character2Cmd);
        string line;
        string[] CommandData;

        if (Character1.state != CharacterManager.CharacterStates.Stand) character1Cmd = "";
        if (Character2.state != CharacterManager.CharacterStates.Stand) character2Cmd = "";
        if (Character1.state == CharacterManager.CharacterStates.Damage) Character1.state = CharacterManager.CharacterStates.Stand;
        if (Character2.state == CharacterManager.CharacterStates.Damage) Character2.state = CharacterManager.CharacterStates.Stand;

        using (StreamReader CommandList = new StreamReader("Assets/CommandList.csv"))
        {
            while ((line = CommandList.ReadLine()) != null)
            {
                CommandData = line.Split(',');
                if (CommandData[0].ToUpper() == character1Cmd.ToUpper())
                {
                    Character1.command = CommandData.Skip(4).Take(int.Parse(CommandData[2])).ToList<string>();
                    Character1.command.Add(CommandData[1]);
                }
                if (CommandData[0].ToUpper() == character2Cmd.ToUpper())
                {
                    Character2.command = CommandData.Skip(4).Take(int.Parse(CommandData[2])).ToList<string>();
                    Character2.command.Add(CommandData[1]);
                }
            }
        }

        Debug.Log("Cmd End");

        Run();

    }

    void Run()
    {
        Debug.Log("Run Start");
        if (Character1.command.Count > 1)
        {
            switch (Character1.command[0])
            {
                case "delay":
                    Character1.state = CharacterManager.CharacterStates.Stand;
                    break;
                case "moving-front": 
                    Character1.state = CharacterManager.CharacterStates.Move;
                    break;
                case "dash-front":
                    Character1.state = CharacterManager.CharacterStates.Dash;
                    break;
                case "moving-front-half":
                    Character1.state = CharacterManager.CharacterStates.Move_Half;
                    break;
                case "moving-back":
                    Character1.state = CharacterManager.CharacterStates.Move_Back;
                    break;
                case "dash-back":
                    Character1.state = CharacterManager.CharacterStates.Dash_Back;
                    break;
                case "moving-back-half":
                    Character1.state = CharacterManager.CharacterStates.Move_Back_Half;
                    break;
                case "punch-middle":
                    Character1.state = CharacterManager.CharacterStates.Attack_Middle;
                    break;
                case "punch-high":
                    Character1.state = CharacterManager.CharacterStates.Attack_High;
                    break;
                case "punch-low":
                    Character1.state = CharacterManager.CharacterStates.Attack_Low;
                    break;
                case "punch-middle-fast":
                    Character1.state = CharacterManager.CharacterStates.Attack_Fast;
                    break;
                case "guard-middle":
                    Character1.state = CharacterManager.CharacterStates.Guard_Middle;
                    break;
                case "guard-low":
                    Character1.state = CharacterManager.CharacterStates.Guard_Low;
                    break;
                case "sit":
                    Character1.state = CharacterManager.CharacterStates.Crouch;
                    break;
                case "grab-middle":
                    Character1.state = CharacterManager.CharacterStates.Grab_Middle;
                    break;
                case "grab-high":
                    Character1.state = CharacterManager.CharacterStates.Grab_High;
                    break;
                case "grab-low":
                    Character1.state = CharacterManager.CharacterStates.Grab_Low;
                    break;
            }
            EM.UpdateState(1, Character1.state.ToString());
            Character1.command.RemoveAt(0);
        }
        else
        {
            EM.UpdateState(1, "Stand");
        }

        if (Character2.command.Count > 1)
        {
            switch (Character2.command[0])
            {
                case "delay":
                    Character2.state = CharacterManager.CharacterStates.Stand;
                    break;
                case "moving-front":
                    Character2.state = CharacterManager.CharacterStates.Move;
                    break;
                case "dash-front":
                    Character2.state = CharacterManager.CharacterStates.Dash;
                    break;
                case "moving-front-half":
                    Character2.state = CharacterManager.CharacterStates.Move_Half;
                    break;
                case "moving-back":
                    Character2.state = CharacterManager.CharacterStates.Move_Back;
                    break;
                case "dash-back":
                    Character2.state = CharacterManager.CharacterStates.Dash_Back;
                    break;
                case "moving-back-half":
                    Character2.state = CharacterManager.CharacterStates.Move_Back_Half;
                    break;
                case "punch-middle":
                    Character2.state = CharacterManager.CharacterStates.Attack_Middle;
                    break;
                case "punch-high":
                    Character2.state = CharacterManager.CharacterStates.Attack_High;
                    break;
                case "punch-low":
                    Character2.state = CharacterManager.CharacterStates.Attack_Low;
                    break;
                case "punch-middle-fast":
                    Character2.state = CharacterManager.CharacterStates.Attack_Fast;
                    break;
                case "guard-middle":
                    Character2.state = CharacterManager.CharacterStates.Guard_Middle;
                    break;
                case "guard-low":
                    Character2.state = CharacterManager.CharacterStates.Guard_Low;
                    break;
                case "sit":
                    Character2.state = CharacterManager.CharacterStates.Crouch;
                    break;
                case "grab-middle":
                    Character2.state = CharacterManager.CharacterStates.Grab_Middle;
                    break;
                case "grab-high":
                    Character2.state = CharacterManager.CharacterStates.Grab_High;
                    break;
                case "grab-low":
                    Character2.state = CharacterManager.CharacterStates.Grab_Low;
                    break;
            }
            EM.UpdateState(2, Character2.state.ToString());
            Character2.command.RemoveAt(0);
        }
        else
        {
            EM.UpdateState(2, "Stand");
        }
        Debug.Log("Run - state update");

        Attack();
        Grab();
        if (Character1.isMoving()) Character1.Move();
        if (Character2.isMoving()) Character2.Move();

        TurnEnd();
    }

    bool isGameOver()
    {
        if (Character1.HP <= 0 || Character2.HP <= 0 || turn >= MAXTURN)
            return true;
        return false;
    }

    void Attack()
    {
        if (Character1.isAttack())
        {
            if (Math.Abs(Character1.position - Character2.position) <= 1)
            {
                if (Character2.isAttack())
                {
                    int hit1 = int.Parse(Character1.command[0]);
                    Character1.Damage(int.Parse(Character2.command[0]));
                    Character2.Damage(hit1);
                }
                else if (Character2.isGuard())
                {
                    if (Character1.state == CharacterManager.CharacterStates.Attack_Low && Character2.state == CharacterManager.CharacterStates.Guard_Middle)
                    {
                        Character2.Damage(int.Parse(Character1.command[0]));
                        Character1.command.Clear();
                    }
                    if (Character1.state == CharacterManager.CharacterStates.Attack_Middle && Character2.state == CharacterManager.CharacterStates.Guard_Low)
                    {
                        Character2.Damage(int.Parse(Character1.command[0]));
                        Character1.command.Clear();
                    }
                }
                else if (Character1.state == CharacterManager.CharacterStates.Attack_High)
                {
                    if (Character2.state == CharacterManager.CharacterStates.Crouch || Character2.state == CharacterManager.CharacterStates.Down) ;
                    else
                    {
                        Character2.Damage(int.Parse(Character1.command[0]));
                        Character1.command.Clear();
                    }
                }
                else if (Character1.state == CharacterManager.CharacterStates.Attack_Low)
                {
                    if (Character2.state == CharacterManager.CharacterStates.Jump) ;
                    else
                    {
                        Character2.Damage(int.Parse(Character1.command[0]));
                        Character1.command.Clear();
                    }
                }
                else
                {
                    Character2.Damage(int.Parse(Character1.command[0]));
                    Character1.command.Clear();
                }
            }
        }

        if (Character2.isAttack())
        {
            if (Math.Abs(Character1.position - Character2.position) <= 1)
            {
                if (Character1.isGuard())
                {
                    if (Character2.state == CharacterManager.CharacterStates.Attack_Low && Character1.state == CharacterManager.CharacterStates.Guard_Middle)
                    {
                        Character1.Damage(int.Parse(Character2.command[0]));
                        Character2.command.Clear();
                    }
                    if (Character2.state == CharacterManager.CharacterStates.Attack_Middle && Character1.state == CharacterManager.CharacterStates.Guard_Low)
                    {
                        Character1.Damage(int.Parse(Character2.command[0]));
                        Character2.command.Clear();
                    }
                }
                else if (Character2.state == CharacterManager.CharacterStates.Attack_High)
                {
                    if (Character1.state == CharacterManager.CharacterStates.Crouch || Character1.state == CharacterManager.CharacterStates.Down) ;
                    else
                    {
                        Character1.Damage(int.Parse(Character2.command[0]));
                        Character2.command.Clear();
                    }
                }
                else if (Character2.state == CharacterManager.CharacterStates.Attack_Low)
                {
                    if (Character1.state == CharacterManager.CharacterStates.Jump) ;
                    else
                    {
                        Character1.Damage(int.Parse(Character2.command[0]));
                        Character2.command.Clear();
                    }
                }
                else
                {
                    Character1.Damage(int.Parse(Character2.command[0]));
                    Character2.command.Clear();
                }
            }
        }
    }
    void Grab()
    {
        if (Character1.isGrab())
        {
            if (Math.Abs(Character1.position - Character2.position) <= 1)
            {
                if (Character1.state == CharacterManager.CharacterStates.Grab_High)
                {
                    if (Character2.state == CharacterManager.CharacterStates.Crouch || Character2.state == CharacterManager.CharacterStates.Down) ;
                    else
                    {
                        Character2.Damage(int.Parse(Character1.command[0]));
                        Character1.command.Clear();
                    }
                }
                else if (Character1.state == CharacterManager.CharacterStates.Grab_Low)
                {
                    if (Character2.state == CharacterManager.CharacterStates.Jump) ;
                    else
                    {
                        Character2.Damage(int.Parse(Character1.command[0]));
                        Character1.command.Clear();
                    }
                }
                else
                {
                    Character2.Damage(int.Parse(Character1.command[0]));
                    Character1.command.Clear();
                }
            }
        }
        if (Character2.isGrab())
        {
            if (Math.Abs(Character2.position - Character1.position) <= 2)
            {
                if (Character2.state == CharacterManager.CharacterStates.Grab_High)
                {
                    if (Character1.state == CharacterManager.CharacterStates.Crouch || Character1.state == CharacterManager.CharacterStates.Down) ;
                    else
                    {
                        Character1.Damage(int.Parse(Character2.command[0]));
                        Character2.command.Clear();
                    }
                }
                else if (Character2.state == CharacterManager.CharacterStates.Grab_Low)
                {
                    if (Character1.state == CharacterManager.CharacterStates.Jump) ;
                    else
                    {
                        Character1.Damage(int.Parse(Character2.command[0]));
                        Character2.command.Clear();
                    }
                }
                else
                {
                    Character1.Damage(int.Parse(Character2.command[0]));
                    Character2.command.Clear();
                }
            }
        }
    }
}



