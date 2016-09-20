using UnityEngine;
using System.Collections;

/// <summary>
/// To recap:
/// GameObjects are how "things" are represented in Unity- Think real life game objects like tokens, cards, the board, etc.
/// Basically Gameobjects can be created/spawned, cloned, or deleted
/// A "scene" is the collection of GameObjects currently in play. We will probably have two "scenes", a loading screen and the main game.
/// You can see a list of all GameObjects in the scene you're working on in the "Hierarchy" window.
/// When you press save in the editor, you're saving the scene.
/// 
/// GameObjects have a collection of Behaviors (also called Components or Scripts)- Think about things that a game object in real life "does" in real life
/// Behaviours can be re-used. For example, gameObject A and gameObject B might both have a DeckOfCards behaviour
/// We write behaviours in code, like this behaviour called Example
/// To start writing a new behaviour, go to "Assets>Create>C# Script" in the Unity editor
/// C# (.cs) files should only have 1 behaviour in them, and the file needs to be the same name as the behaviour class name. Like this file called Example.cs
/// Behaviours always extend MonoBehaviour. This is done automatically for you
/// 
/// The editor's "Project" windows is just a preview of the repository/Assets folder
/// Put everything in here besically
/// I set up some folders for "Models", "Sounds", "Scripts" (code) etc so we can organize our stuff by file type
/// 
/// To test/execute the game, press the play button at the top of the Unity Editor
/// Press it again to stop
/// You can also pause and step through the game
/// Unity works in "frames"
/// On the first frame, every behaviour calls Start()
/// On every frame, every behaviour calls Update()
/// </summary>
public class Example : MonoBehaviour {

	// In Unity we can manually set up parameters or references to things in the "Inspector" window
	// First, just publicly expose what variable you want to initialize
	// For example, we want to be able to manually specify a number:
	public float changeMe;
	// We can give a variable a default value for new behaviours.
	// This default value can be overridden if you'd like in the inspector
	// This way, every behaviour on every game object can have its own default values
	// Custom values form the inspector get saved when you save the scene
	public bool myBool = true;
	// If you want to reference another game object or behaviour, you need to drag it into the inspector yourself.
	public GameObject otherGameObject;
	// You can't see private variables in the inspector
	private int youCannotSeeThisInTheInspector;
	// Variables are by default private
	int thisIsPrivate;
	const int YOU_CANNOT_CHANGE_CONSTANTS_IN_THE_INSPECTOR_EITHER = 5;


	// Use this for initialization
	void Start () {
	
		// You can access another Behaviour by calling someGameObject.GetComponent<NameOfComponent>();
		// For example, I want to reference some gameObject's Renderer component
		Renderer someRenderer = otherGameObject.GetComponent<Renderer>();

		// The exception is that all GameObjects always have a Transform component-
		// You don't need to call GetComponent to get this.
		otherGameObject.transform.position = new Vector3(1, 2, 0);
		// For the behaviours in our game that have to do with 2-dimensional UI stuff, we might use RectTransform instead of Transform, and Vector2 instead of Vector3.

		// All Behaviours have am "enabled" bool
		// You can set this in the inspector too, enabling and disabling at runtime or before runtime
		// Start() and Update() will only be called if the behaviour is "enabled"
		// We can disable this other gameObject's renderer. This will make it invisible.
		someRenderer.enabled = false;

		// To reference the gameObject this behaviour is on, use "gameObject"
		// All gameObjects have a name and tag which we can set in the inspector and can use to identify stuff
		gameObject.name = "New Name";
		if (gameObject.tag == "Card") {
			// To send a message ot the editor's log, use
			Debug.Log("This is a card");
			if (gameObject.GetComponent<Renderer> () == null)
				Debug.LogError ("ERROR! This gameobject does not have a card!");
			// You can click on a debug log entry  in the "Debug" window and Unity will highlight what gameObject called the log
			// You can double-click the debug log entry as a shortcut to the line the log was called on
		}

	}
	
	// Update is called once per frame
	void Update () {
		// You can see public variables change in real-time in the inspector when the game is "playing"
		// You can access time since the game started with Time.time
		changeMe = Time.time;

		// You can edit public variables in the inspector, but there's no easy visual way to debug a method call.
		// If you are testing your stuff, you might want to use hotkeys
		// Here is an example of a hotkey listener. You need to put this in the Update() function
		if (Input.GetKeyDown (KeyCode.H)) {
			Debug.Log ("Test");
		}
	}

	// The fine details will come later, but basically UI buttons can call public void methods that take 0 or one parameters
	// We'll set up what buttons call what methods in the inspector after we write most of the code.
	public void ExampleButtonCall(string message)
	{
		Debug.Log ("You pressed a button");
	}


	// In unity, asynchronous functions/coroutines are a good way to do things that have to do with time
	// Ex. You want the AI to wait for some time before taking their turn
	// They basically work like methods
	IEnumerator ExampleCoroutine(int parameter1, int parameter2)
	{
		Debug.Log ("I'm thinking...");
		// This is how you wait
		// An IEnumerator/Coroutine must have at least one "yield"
		yield return new WaitForSeconds (3);
		if (parameter1 > 1000 && parameter2 > 1000) {
			Debug.Log ("Wow these numbers are pretty big... hmmm...");
			// Here is how you get a random number
			int random = Random.Range(0, 20);
			yield return new WaitForSeconds (random);
		}
		Debug.Log (parameter1 + parameter2);
	}

	void ThisIsHowYouCallCoroutines()
	{
		StartCoroutine (ExampleCoroutine (1, 2));
		// This is how you stop coroutines
		StopAllCoroutines();
	}
}

/// Also,
/// Each .cs file can only have one MonoBehaviour but you can define whatever else you want, too.
/// Like right here I can define as many data structs as I want
/// If you don't know C# here are some examples of C# stuff
public class DataHolder
{
	public string myName;
	public int myValue;
	public DataHolder(int newValue)
	{
		myName = "";
		myValue = newValue;
	}
}

public enum Direction { North, South, East, West }