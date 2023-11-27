using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   private void Start()
   {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
   }

   public void PlayGame()
   {
      SceneManager.LoadScene("GameScene");
   }

   public void QuitGame()
   {
      Application.Quit();
   }
}
