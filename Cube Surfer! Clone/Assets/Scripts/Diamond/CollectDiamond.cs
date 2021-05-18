using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDiamond : CollectableObject
{
    public Diamond diamond;

    private GameObject diamondParticleObject;
    private ParticleSystem diamondParticle;

    private void Awake()
    {
        diamondParticleObject = GameObject.Find("DiamondParticle");
        diamondParticle = diamondParticleObject.GetComponent<ParticleSystem>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableCube")
        {
            diamondParticle.Play();
            diamond.diamondAmount += 1;
            base.DisposeObject();
        }
    }
}
