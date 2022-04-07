using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public void OnMouseDown()
    {
        GameManager.singleton.AddScore(1);
        Destroy(gameObject);
    }
    
}
