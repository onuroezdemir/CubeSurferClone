using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCube : MonoBehaviour
{

    private Vector3 addPosition = new Vector3(0f,1f,0f);
    private Vector3 addPlayerPoisiton = new Vector3(0f, 1.5f, 0f);
    private Vector3 addParticlePosition = new Vector3(1.75f, 1f, 1f);

    public GameObject playerModel;

    public List<GameObject> cubes;
    public GameObject cube;
    public Transform cubePosition;

    public GameObject deadCube;

    public GameObject stackParticle;
    public GameObject removeParticle;

    public static StackCube instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.OnCubeCollected.AddListener(AddCube);
        EventManager.OnCubeRemoved.AddListener(RemoveCube);
    }

    private void OnDisable()
    {
        EventManager.OnCubeCollected.RemoveListener(AddCube);
        EventManager.OnCubeRemoved.RemoveListener(RemoveCube);
    }

    public void AddCube()
    {
        GameObject newCube = (GameObject)Instantiate(cube, cubePosition.position + addPosition, cubePosition.rotation);
        GameObject newParticle = (GameObject)Instantiate(stackParticle, cubePosition.position + addParticlePosition, cubePosition.rotation);
        newCube.transform.SetParent(gameObject.transform);
        cubePosition = newCube.transform;
        cubes.Add(newCube);
        playerModel.transform.position += addPlayerPoisiton;
    }

    public void RemoveCube()
    {
        if (cubes.Count - 1 >= 1)
        {
           
            cubePosition = cubes[cubes.Count - 1].transform;
            
        }
        else
        {
            EventManager.OnGameOver?.Invoke();
        }
    }

}
