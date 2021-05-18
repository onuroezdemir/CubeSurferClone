using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        DefaultGameState,
        StartGameState,
        GameOverState,
        FinishState
    }

    public GameState currentState;

    public static GameManager instance;

    private GameObject canvas;

    private GameObject defaultCanvas;
    private GameObject inGameCanvas;
    private GameObject failCanvas;
    private GameObject successCanvas;

    private GameObject player;
    private Animator playerAnimator;

    public GameObject finishCamera;

    private void OnEnable()
    {
        EventManager.OnGameStarted.AddListener(StartGame);
        EventManager.OnGameOver.AddListener(GameOver);
        EventManager.OnGameFinished.AddListener(FinishGame);
    }

    private void OnDisable()
    {
        EventManager.OnGameStarted.RemoveListener(StartGame);
        EventManager.OnGameOver.RemoveListener(GameOver);
        EventManager.OnGameFinished.RemoveListener(FinishGame);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        canvas = GameObject.Find("Canvas");
        defaultCanvas = FindObject(canvas, "DefaultCanvas");
        inGameCanvas = FindObject(canvas, "InGameCanvas");        
        failCanvas = FindObject(canvas, "FailCanvas");
        successCanvas = FindObject(canvas, "SuccessCanvas");

        player = GameObject.Find("PlayerModel");
        playerAnimator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.DefaultGameState:
                inGameCanvas.SetActive(true);
                defaultCanvas.SetActive(true);
                failCanvas.SetActive(false);
                successCanvas.SetActive(false);

                break;
            case GameState.StartGameState:
                inGameCanvas.SetActive(true);
                defaultCanvas.SetActive(false);
                failCanvas.SetActive(false);
                successCanvas.SetActive(false);
                break;
            case GameState.GameOverState:
                inGameCanvas.SetActive(true);
                defaultCanvas.SetActive(false);
                failCanvas.SetActive(true);
                successCanvas.SetActive(false);
                break;
            case GameState.FinishState:
                inGameCanvas.SetActive(true);
                defaultCanvas.SetActive(false);              
                failCanvas.SetActive(false);
                successCanvas.SetActive(true);
                break;
        }
    }


    public void StartGame()
    {
        currentState = GameState.StartGameState;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        currentState = GameState.GameOverState;
        playerAnimator.SetBool("isFallen", true);
    }

    public void FinishGame()
    {
        currentState = GameState.FinishState;
        playerAnimator.SetBool("isFinished", true);
        Camera.main.gameObject.SetActive(false);
        finishCamera.SetActive(true);

    }

    public GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }


}
