using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Point
{
    public Transform startPoint;
    public Transform endPoint;
}

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static GameManager singleton { get; private set; }

    public List<Point> pointsList;
    public List<GameObject> butterfliesPrefs;

    private void Awake()
    {
        if (!singleton)
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Point point = pointsList[Random.Range(0, pointsList.Count)];
            ButterflyController butterflie = Instantiate(butterfliesPrefs[Random.Range(0, butterfliesPrefs.Count)], point.startPoint.position, Quaternion.identity).GetComponent<ButterflyController>();
            butterflie.startMarker = point.startPoint;
            butterflie.endMarker = point.endPoint;
            butterflie.transform.rotation = Quaternion.LookRotation(butterflie.transform.position - butterflie.endMarker.position);
            yield return new WaitForSeconds(1);
        }
    }
    public int Score = 0;

    public void AddScore(int scoreCount)
    {
        Score += scoreCount;
        scoreText.text = Score.ToString();
    }

    /* public int pause = 25;
     void Start()
     {
         // Set the playback framerate (real time will not relate to game time after this).
         Time.captureDeltaTime = 1.0f / pause;
     } */

    public int pause = 25;

   
}


