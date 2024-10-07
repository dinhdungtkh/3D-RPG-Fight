using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashDistance;
    public bool isFinishedAction = false;
    private Transform hitpoint;
    [SerializeField] ParticleSystem Hitparticle;

    public override void Activate(GameObject parent)
    {
        //Debug.Log("Actived");
        Playermove playermove = parent.GetComponent<Playermove>();
        if (playermove != null)
        {
            hitpoint = playermove.currentTransform;
            //Debug.Log(playerTransform);
            Vector3 dashDirection = hitpoint.forward;
            Vector3 newPosition = hitpoint.position + dashDirection * dashDistance;
            hitpoint.position = newPosition;
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
            Instantiate(Hitparticle,hitpoint);

        }
        else
        {

        }
    }

}
