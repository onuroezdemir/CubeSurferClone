using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    private GameObject player;
    private GameObject finish;
    private GameObject levelProgressBar;

    private Image fillImage;

    private float playerStartPosition;
    private float playerPosition;
    private float finishPosition;

    private float totalDistance;
    private float currentDistance;

    private float progress;

    void Awake()
    {
        player = GameObject.Find("Player");
        finish = GameObject.Find("FinishProgress");
        levelProgressBar = GameObject.Find("LevelProgressBar");
        fillImage = levelProgressBar.GetComponent<Image>();

        playerStartPosition = player.transform.position.z;
        finishPosition = finish.transform.position.z;
        totalDistance = finishPosition - playerStartPosition;
        currentDistance = finishPosition - playerStartPosition;
    }


    void Update()
    {
        CheckProgress();
    }

    void CheckProgress()
    {
        playerPosition = player.transform.position.z;
        currentDistance = finishPosition - playerPosition;
        progress = (totalDistance - currentDistance) / totalDistance;
        fillImage.fillAmount = progress;
    }
}
