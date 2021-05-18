using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWaterCube : CollectableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableCube")
        {
            if (StackCube.instance.cubes.Count - 1 >= 1)
            {
                EventManager.OnCubeRemoved?.Invoke();
                StackCube.instance.cubes.Remove(other.gameObject);

                GameObject newParticle = (GameObject)Instantiate(
                    StackCube.instance.removeParticle, 
                    new Vector3(StackCube.instance.cubePosition.position.x,1f, StackCube.instance.cubePosition.position.z),
                    StackCube.instance.cubePosition.rotation); 

                Destroy(other.gameObject);
            }
            else
            {
                EventManager.OnGameOver?.Invoke();
            }

        }
    }
}
