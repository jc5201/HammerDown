using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

    public CharacterStates state
    {
        get; set;
    }

    public int HP
    {
        get; set;
    }
    
    // Use this for initialization
	void Start () {
        state = CharacterStates.Rest;
	}
	
	// Update is called once per frame
	void Update () {
	
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
