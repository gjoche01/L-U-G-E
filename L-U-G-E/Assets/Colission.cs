using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//create array of letters and access randomly for word player
//is to make? 
//how to get these words? read in text file to dictionary? 

public class Colission : MonoBehaviour {
	
	public string wordFinal; 
	public int letterCount; 
	public bool done; 

	private int lifeCount; //lives 
	private bool isDead; 

	public int levelCount; 

	public string wordCurrent; //letters you have already 

	//text to show on screen
	public Text wordCurrentText; 
	public Text countText; 


	void Start()
	{
		//use this for now
		wordFinal = "TAG"; 
		letterCount = 0; 
		done = false; 
		levelCount = 0; 

		isDead = false; 
		lifeCount = 10; 
		SetCountText (); 
		SetWordText (); 
	}

	void Update ()
	{
		if(lifeCount==0){
			//game over!
		}
		if (done) {
			nextLevel(); 
		}
	}
	void nextLevel ()
	{
		levelCount ++; 
		wordCurrent = string.Empty; 
		done = false; 
		letterCount = 0; 
		wordFinal = string.Empty; //HOW TO GET NEXT WORD? 
		SetWordText (); 
	}

	void SetCountText()
	{
		countText.text = "Lives Left: " + lifeCount.ToString ();
	}

	void SetWordText()
	{
		wordCurrentText.text = "Letters: " + wordCurrent; 
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Obstacle") {
			lifeCount = lifeCount - 1; 
			SetCountText (); 

		} else if (other.gameObject.tag == "Letters") {
			string temp = other.gameObject.name; 
			LetterHandler (temp); 
		}

	}
	//function that handles colisions with letters 
	void LetterHandler(string name)
	{

		//got right letter 
		if(name[0] == wordFinal[letterCount]) {
			letterCount++; 
			wordCurrent = wordCurrent + name; //add char to the string 
			SetWordText(); 
				
			//done with word
			if (wordCurrent == wordFinal) {
				done = true; 
			}
		}
		//wrong letter 
		else {
			lifeCount = lifeCount - 1;
			SetCountText(); 
		}
	}
}
