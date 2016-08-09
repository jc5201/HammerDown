﻿using UnityEngine;
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
        if (!isGameOver())
            TurnStart();
        // else gameResult ...etc
    }

    void Input()
    {
        IM.InputStart();
        initTime = DateTime.Now;
        timer.Start();
        
    }

    void TimerEventProcessor(object myObject, EventArgs myEventArgs)
    {
        timer.Enabled = false;
        IM.InputEnd();
    }

    public void Process(string character1Cmd, string character2Cmd)
    {
        
        string line;
        string[] CommandData;

        using (StreamReader CommandList = new StreamReader("/Assets/CommandList.csv", System.Text.Encoding.Default))
        {
            while ((line = CommandList.ReadLine()) != null)
            {
                CommandData = line.Split(',');
                if (CommandData[0] == character1Cmd)
                {
                    Character1.command = CommandData.Skip(4).Take(int.Parse(CommandData[2])).ToList<string>();
                    Character1.command.Add(CommandData[1]);
                }
                if (CommandData[0] == character2Cmd)
                {
                    Character2.command = CommandData.Skip(4).Take(int.Parse(CommandData[2])).ToList<string>();
                    Character2.command.Add(CommandData[1]);
                }
            }
        }
        
        Run();

    }

    void Run()
    {
        
        if (Character1.command.Count > 1)
        {
            EM.UpdateState(1, Character1.command[0]);
            Character1.command.RemoveAt(0);
        }
        else
        {
            EM.UpdateState(1, "Rest");
        }

        if (Character2.command.Count > 1)
        {
            EM.UpdateState(2, Character2.command[0]);
            Character2.command.RemoveAt(0);
        }
        else
        {
            EM.UpdateState(2, "Rest");
        }
        TurnEnd();
    }

    bool isGameOver()
    {
        if (Character1.HP <= 0 || Character2.HP <= 0 || turn >= MAXTURN)
            return true;
        return false;
    }
}



