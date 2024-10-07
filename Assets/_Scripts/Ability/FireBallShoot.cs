using Game.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FireBallShoot : Ability
{
    public bool isFinishedAction = false;
    private Transform hitpoint;
    [SerializeField] ParticleSystem projectile;
    public override void Activate(GameObject parent)
    {
        //Debug.Log("Actived");
        Playermove playermove = parent.GetComponent<Playermove>();
        if (playermove != null)
        {
            hitpoint = playermove.currentTransform;
            Instantiate(projectile, hitpoint);
            DealDamage();
        }
        else
        {
            Debug.LogWarning("Playermove component not found on the parent GameObject.");
        }
    }

    


    public IEnumerator DealDamage()
    {
        yield return new WaitForSeconds(1.8f);
        if (!isFinishedAction)
        {
            Instantiate(projectile, hitpoint);

        }
        else
        {

        }
    }

}
