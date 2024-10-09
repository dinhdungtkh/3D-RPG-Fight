using Game.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FireBallShoot : Ability
{
    private Playermove movement;
    [SerializeField] private float projectileSpeed = 15f;

    [Header("Bullets Config")]
    [SerializeField] private GameObject fireballFXPrefab;
    

    private Vector3 aimPosition;

    public override void Activate(GameObject parent)
    {
        Playermove playermove = parent.GetComponent<Playermove>();
        if (playermove != null)
        {
            GameObject fireballFX = Instantiate(fireballFXPrefab, playermove.currentTransform.position, Quaternion.identity);
           Bullet bullet = fireballFX.GetComponent<Bullet>();
            bullet.Initialize(20f, null);
            Vector3 direction = playermove.transform.forward;
            Rigidbody rb = fireballFX.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogWarning("Playermove component not found on the parent GameObject.");
        }
    }

}
