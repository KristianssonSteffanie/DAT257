using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
   public Image[] hearts;
   //public int livesRemaining;
   public int heart = GameManager.lives;

   public void LoseLife(){
       //livesRemaining--;
       //lives[livesRemaining].enabled=false;

       heart--;
       hearts[heart].enabled = false;

       if(heart == 0){
           Debug.Log("You lost");
       }
   }

   //For testing
   //public void Update(){
  //     if (Input.GetKeyDown(KeyCode.LeftArrow))
  //      LoseLife();
 //  }
        
}
