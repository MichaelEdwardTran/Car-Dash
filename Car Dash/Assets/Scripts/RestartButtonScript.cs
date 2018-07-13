using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // Required when using Event data(ipointerdownhandler)

public class RestartButtonScript : MonoBehaviour //, IPointerDownHandler
{
    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        RestartGame();
        gameObject.SetActive(false);
    }
    */
    public void RestartGame()
    {
        SceneManager.LoadScene("PlayGame"); // loads current scene
        gameObject.SetActive(false);
    }

}
