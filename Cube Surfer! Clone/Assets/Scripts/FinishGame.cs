using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject ConfettiParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableCube")
        {
            ConfettiParticle.SetActive(true);
            EventManager.OnGameFinished?.Invoke();
        }
    }
}
