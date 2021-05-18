using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRemoveCube : MonoBehaviour
{
    public GameObject ConfettiParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableCube")
        {
            if (StackCube.instance.cubes.Count - 1 >= 1)
            {
                StartCoroutine(WaitAndDestroy(other.gameObject));
                EventManager.OnCubeRemoved?.Invoke();
                StackCube.instance.cubes.Remove(other.gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                ConfettiParticle.SetActive(true);
                EventManager.OnGameFinished?.Invoke();
            }

        }

        IEnumerator WaitAndDestroy(GameObject deadCube)
        {
            GameObject DeadCube = (GameObject)Instantiate(StackCube.instance.deadCube, deadCube.transform.position, deadCube.transform.rotation);
            yield return new WaitForSeconds(3f);
            Destroy(DeadCube);

        }
    }
}
