using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnCubeCollected = new UnityEvent();
    public static UnityEvent OnCubeRemoved = new UnityEvent();

    public static UnityEvent OnGameStarted = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    public static UnityEvent OnGameFinished = new UnityEvent();


}
