using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : ScriptableObject
{
     public Image abilityImage;
     public float abilityCooldown;
    public Text abilityTextCoolDown;
    public KeyCode activeKey;
    public string CurrentAnimname;
    public virtual void Activate(GameObject parent)
    {
      // Debug.Log("Actived 0");
    } 


    public void ChangeAnim(string name)
    {

    }
}
