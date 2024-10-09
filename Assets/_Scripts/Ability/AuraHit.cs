using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraHit : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab;
    [SerializeField] private float damage = 20f;
    public virtual void OnInit()
    {
        Destroy(gameObject, 3f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            CharacterHealth characterHealth = other.GetComponent<CharacterHealth>();
            characterHealth.ReceiveDamage(damage);

        }
    }

}