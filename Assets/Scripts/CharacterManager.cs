using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

    public CharacterStates state
    {
        get; set;
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public enum CharacterStates

    {
        Down,
        Die,
        Jump,
        Attack1,
        Attack2
    }

}
