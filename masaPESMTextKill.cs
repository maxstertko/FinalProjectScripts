using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class masaPESMTextKill : MonoBehaviour {

    //CONTAINS TIMER AND SCORE GAMELOADER IS DISABLED

    public float timer;
    public bool isAlive;
    public Text endText;
    public Text startText;
    public GameObject player;



    // Use this for initialization
    void Start () {

        timer = 10;
        isAlive = true;
        endText.text = "";
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(player == null) {
            isAlive = false;
        }

        StartCoroutine(RunGameDelay(2));
       
    }

    IEnumerator RunGameDelay(float time) {
        yield return new WaitForSeconds(time);
        startText.text = "";
        if (timer > 0 && isAlive == true) {
            timer = timer - Time.deltaTime;
        }
        else if (timer <= 0 || isAlive == false) {
            int wholeTime = 10 - (int)timer;

            endText.text = "You did this for " + wholeTime + " Seconds!";

            //GameLoader.AddScore(wholeTime);

            StartCoroutine(ByeAfterDelay(2));

        }
    }

    IEnumerator ByeAfterDelay(float time) {
        yield return new WaitForSeconds(time);

        //GameLoader.gameOn = false;
    }

   
}
