using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private GameManager GM;
    private float horiz = 0, vertic = 0, attack1 = 0, attack2 = 0, guard = 0, grab = 0;
    private string cmd1, cmd2;

	// Use this for initialization
	void Start () {
        GM = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        {
            if (Input.GetAxis("Horizontal1") != horiz)
            {
                horiz = Input.GetAxis("Horizontal1");
                switch ((int)horiz)
                {
                    case 1:
                        cmd1 += "D";
                        break;
                    case -1:
                        cmd1 += "A";
                        break;
                    case 0:
                        break;
                    default:
                        Debug.Log("Wrong horizontal value");
                        break;
                }
            }
            if (Input.GetAxis("Vertical1") != vertic)
            {
                vertic = Input.GetAxis("Vertical1");
                switch ((int)vertic)
                {
                    case 1:
                        cmd1 += "W";
                        break;
                    case -1:
                        cmd1 += "S";
                        break;
                    case 0:
                        break;
                    default:
                        Debug.Log("Wrong vertical value");
                        break;
                }
            }
            if (Input.GetAxis("AttackA1") != attack1)
            {
                attack1 = Input.GetAxis("AttackA1");
                if (attack1 == 1) cmd1 += "U";
            }
            if (Input.GetAxis("AttackB1") != attack2)
            {
                attack2 = Input.GetAxis("AttackB1");
                if (attack2 == 1) cmd1 += "I";
            }
            if (Input.GetAxis("Guard1") != guard)
            {
                guard = Input.GetAxis("Guard1");
                if (guard == 1) cmd1 += "J";
            }
            if (Input.GetAxis("Grab2") != grab)
            {
                grab = Input.GetAxis("Grab2");
                if (grab == 1) cmd1 += "K";
            }
        }

        {
            if (Input.GetAxis("Horizontal2") != horiz)
            {
                horiz = Input.GetAxis("Horizontal2");
                switch ((int)horiz)
                {
                    case 1:
                        cmd2 += "D";
                        break;
                    case -1:
                        cmd2 += "A";
                        break;
                    case 0:
                        break;
                    default:
                        Debug.Log("Wrong horizontal value");
                        break;
                }
            }
            if (Input.GetAxis("Vertical2") != vertic)
            {
                vertic = Input.GetAxis("Vertical2");
                switch ((int)vertic)
                {
                    case 1:
                        cmd2 += "W";
                        break;
                    case -1:
                        cmd2 += "S";
                        break;
                    case 0:
                        break;
                    default:
                        Debug.Log("Wrong vertical value");
                        break;
                }
            }
            if (Input.GetAxis("AttackA2") != attack1)
            {
                attack1 = Input.GetAxis("AttackA2");
                if (attack1 == 1) cmd2 += "U";
            }
            if (Input.GetAxis("AttackB2") != attack2)
            {
                attack2 = Input.GetAxis("AttackB2");
                if (attack2 == 1) cmd2 += "I";
            }
            if (Input.GetAxis("Guard2") != guard)
            {
                guard = Input.GetAxis("Guard2");
                if (guard == 1) cmd2 += "J";
            }
            if (Input.GetAxis("Grab2") != grab)
            {
                grab = Input.GetAxis("Grab2");
                if (grab == 1) cmd2 += "K";
            }
        }
    }

    public void InputStart()
    {
        cmd1 = "";
        cmd2 = "";
    }

    public void InputEnd()
    {
        GM.Process(cmd1, cmd2);
    }

}
