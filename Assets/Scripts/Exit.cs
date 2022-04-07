using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Quits the player when the user hits escape

public class Exit : MonoBehaviour
{
    public Button ExitGame;
    void Start()
    {
        ExitGame.onClick.AddListener(TaskOnClick);  
        
    }
    void TaskOnClick()
    {
        Application.Quit();
    }
}
