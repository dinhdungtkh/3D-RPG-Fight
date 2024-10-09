using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System.Threading.Tasks;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    public List<Ability> abilities = new List<Ability>();
    public List<Image> abilityImages = new List<Image>();
    public List<Text> abilityTexts = new List<Text>();
    public List<KeyCode> abilityKeys = new List<KeyCode>();
    public List<float> abilityCooldowns = new List<float>();

    private List<bool> isAbilityCooldown = new List<bool>();
    private List<float> currentCooldowns = new List<float>();

    

    void Start()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            abilityImages[i].fillAmount = 0;
            abilityTexts[i].text = "";
            isAbilityCooldown.Add(false);
            currentCooldowns.Add(0f);
            SetupAbilityInput(i);
        }
    }

    private void SetupAbilityInput(int index)
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(abilityKeys[index]) && !isAbilityCooldown[index])
            .Subscribe(_ =>
            {
                ActivateSkillInGame(index);
                HandleCooldownUI(index);
            }).AddTo(this);
    }

    private void ActivateSkillInGame(int index)
    {
        abilities[index].Activate(gameObject);
        m_Animator.SetTrigger($"Skill{index + 1}");
    }

    private async void HandleCooldownUI(int index)
    {
        isAbilityCooldown[index] = true;
        currentCooldowns[index] = abilityCooldowns[index];
        float cooldownDuration = abilityCooldowns[index];

        while (currentCooldowns[index] > 0)
        {
            await Task.Delay(100);
            currentCooldowns[index] -= 0.1f;

            abilityImages[index].fillAmount = currentCooldowns[index] / cooldownDuration;
            abilityTexts[index].text = Mathf.Ceil(currentCooldowns[index]).ToString();
        }

        isAbilityCooldown[index] = false;
        abilityImages[index].fillAmount = 0;
        abilityTexts[index].text = "";
    }
}
