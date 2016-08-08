using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Timers;

public class GameManager : MonoBehaviour {

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

    // Use this for initialization
    void Start() {
        turn = 0;
        timeInterval = 1;
        timer.Interval = timeInterval;
        timer.Elapsed += new ElapsedEventHandler(TimerEventProcessor);
        Character1 = GameObject.Find("Character1").GetComponent<CharacterManager>();
        Character2 = GameObject.Find("Character2").GetComponent<CharacterManager>();
        IM = GetComponent<InputManager>();
        EM = GetComponent<EventManager>();

        timeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();

        TurnStart();
    }

    void Update()
    {
        if (timer.Enabled)
        {
            timeSlider.value = (float)(DateTime.Now.Ticks - initTime.Ticks)/10000;
        }
        else
        {
            timeSlider.value = 0;
        }
    }

    void TurnStart()
    {
        turn += 1;
        GameObject.Find("TurnText").GetComponent<Text>().text = turn.ToString("D3");
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
        timer.Start();
        initTime = DateTime.Now;
    }

    void TimerEventProcessor(object myObject, EventArgs myEventArgs)
    {
        IM.InputEnd();
        timer.Stop();
    }

    public void Process(string character1Cmd, string character2Cmd)
    {
        int i;
        for (i = 0; i < character1Cmd.Length; i++)
        {

        }
        for (i = 0; i < character2Cmd.Length; i++)
        {

        }

    }

    bool isGameOver()
    {
        if(Character1.HP <= 0 || Character2.HP <= 0 || turn >= MAXTURN)
            return true;
        return false;
    }
}



