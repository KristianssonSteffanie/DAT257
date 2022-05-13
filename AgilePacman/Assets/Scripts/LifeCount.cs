using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
   public Image[] lives;
   public int livesRemaining;

   public void LoseLife(){
       livesRemaining--;
       lives[livesRemaining].enabled=false;

       if(livesRemaining == 0){
           Debug.Log("You lost");
       }
   }

   //For testing
  // public void Update(){
    //   if (Input.GetKeyDown(KeyCode.LeftArrow))
  //
      //LoseLife();
  //}
        
}
