using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : CollectableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CollectableCube")
        {
            EventManager.OnCubeCollected?.Invoke();
            base.DisposeObject();
        }
    }
}
