using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private GameManager GM;
    private float horiz = 0, vertic = 0, attack1 = 0, attack2 = 0, guard = 0, grab = 0;

	// Use this for initialization
	void Start () {
        GM = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") != horiz)
        {
            horiz = Input.GetAxis("Horizontal");
            Debug.Log(horiz.ToString());
        }
        if (Input.GetAxis("Vertical") != vertic)
        {
            vertic = Input.GetAxis("Vertical");
            Debug.Log(vertic.ToString());
        }
        if (Input.GetAxis("Attack1") != attack1)
        {
            attack1 = Input.GetAxis("Attack1");
            Debug.Log(attack1.ToString());
        }
        if (Input.GetAxis("Attack2") != attack2)
        {
            attack2 = Input.GetAxis("Attack2"); 
            Debug.Log(attack2.ToString());
        }
        if (Input.GetAxis("Guard") != guard)
        {
            guard = Input.GetAxis("Guard");
            Debug.Log(guard.ToString());
        }
        if (Input.GetAxis("Grab") != grab)
        {
            grab = Input.GetAxis("Grab");
            Debug.Log(grab.ToString());
        }

    }

    void InputStart()
    {

    }

    void InputEnd()
    {
    }

}
