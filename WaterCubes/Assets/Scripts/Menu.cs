using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   private void Start()
   {
      //unlocks the cuerser
      Cursor.lockState = CursorLockMode.None;
      //makes the curser  visible
      Cursor.visible = true;
   }

   //is called when the user presses the "PLay again" button
   public void PlayGame()
   {
      SceneManager.LoadScene("GameScene");
   }

   //is called when the user presses the "Quit game" button.
   public void QuitGame()
   {
      Application.Quit();
   }
}
