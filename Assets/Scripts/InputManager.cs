using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private GameManager GM;
    private float horiz1 = 0, vertic1 = 0, attacka1 = 0, attackb1 = 0, guard1 = 0, grab1 = 0;
    private float horiz2 = 0, vertic2 = 0, attacka2 = 0, attackb2 = 0, guard2 = 0, grab2 = 0;
    private string cmd1, cmd2;

	// Use this for initialization
	void Start () {
        GM = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        {
            if (Input.GetAxis("Horizontal1") != horiz1)
            {
                horiz1 = Input.GetAxis("Horizontal1");
                switch ((int)horiz1)
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
            if (Input.GetAxis("Vertical1") != vertic1)
            {
                vertic1 = Input.GetAxis("Vertical1");
                switch ((int)vertic1)
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
            if (Input.GetAxis("AttackA1") != attacka1)
            {
                attacka1 = Input.GetAxis("AttackA1");
                if (attacka1 == 1) cmd1 += "U";
            }
            if (Input.GetAxis("AttackB1") != attackb1)
            {
                attackb1 = Input.GetAxis("AttackB1");
                if (attackb1 == 1) cmd1 += "I";
            }
            if (Input.GetAxis("Guard1") != guard1)
            {
                guard1 = Input.GetAxis("Guard1");
                if (guard1 == 1) cmd1 += "J";
            }
            if (Input.GetAxis("Grab2") != grab1)
            {
                grab1 = Input.GetAxis("Grab2");
                if (grab1 == 1) cmd1 += "K";
            }
        }

        {
            if (Input.GetAxis("Horizontal2") != horiz2)
            {
                horiz2 = Input.GetAxis("Horizontal2");
                switch ((int)horiz2)
                {
                    case 1:
                        cmd2 += "A";
                        break;
                    case -1:
                        cmd2 += "D";
                        break;
                    case 0:
                        break;
                    default:
                        Debug.Log("Wrong horizontal value");
                        break;
                }
            }
            if (Input.GetAxis("Vertical2") != vertic2)
            {
                vertic2 = Input.GetAxis("Vertical2");
                switch ((int)vertic2)
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
            if (Input.GetAxis("AttackA2") != attacka2)
            {
                attacka2 = Input.GetAxis("AttackA2");
                if (attacka2 == 1) cmd2 += "U";
            }
            if (Input.GetAxis("AttackB2") != attackb2)
            {
                attackb2 = Input.GetAxis("AttackB2");
                if (attackb2 == 1) cmd2 += "I";
            }
            if (Input.GetAxis("Guard2") != guard2)
            {
                guard2 = Input.GetAxis("Guard2");
                if (guard2 == 1) cmd2 += "J";
            }
            if (Input.GetAxis("Grab2") != grab2)
            {
                grab2 = Input.GetAxis("Grab2");
                if (grab2 == 1) cmd2 += "K";
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
