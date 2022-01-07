using UnityEngine;
using UnityEngine.UI;
using StageSystem;
namespace HealthSystem
{
    public class PlayerHealth : MonoBehaviour
    {
        float minHP = 0f;
        float criticalHP = 25f;
        float lowHP = 40f;
        float maxHP = 100f;
        public float currHP = 100f;

        float lowSpeed = 1f;
        float mediumSpeed = 2f;
        float topSpeed = 4f;

        public Slider hpSlider = null;
        public Gradient gradient = null;
        public Color iconColor;

        public Image fill = null;
        public Image icon = null;
        public GameObject electric = null;

        public PlayerMovement playerMovement = null;

        public GameObject deathPanel = null; 
        public Animator deathAnim = null;
        public Animator deadTextAnim = null;
        public StageManager stageManager = null;

        void Start()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            stageManager = FindObjectOfType<StageManager>();

            topSpeed = playerMovement.xZSpeed;
            electric.SetActive(false);

            hpSlider.minValue = minHP;
            hpSlider.maxValue = maxHP;
            iconColor = icon.color;
            fill.color = gradient.Evaluate(1f);

            deathPanel.SetActive(false);
        }
        public void SetDeath()
        {
            currHP = minHP;
            deathPanel.SetActive(true);
            deathAnim.Play("Death Anim", 0, 0.1f);
            deadTextAnim.Play("Dead Text Anim", 0, 0.1f);
            stageManager.RestartStage();
        }
        public void SetHealth()
        {
            if (currHP <= minHP)
            {
                SetDeath();
                currHP = minHP;
            }
            else if (currHP <= criticalHP)
            {
                icon.color = Color.black;
                playerMovement.xZSpeed = lowSpeed;
            }
            else
            {
                if (currHP <= lowHP) playerMovement.xZSpeed = mediumSpeed;
                else
                {
                    playerMovement.xZSpeed = topSpeed;
                    if (currHP > maxHP) currHP = maxHP;
                }
                icon.color = iconColor;
            }
            hpSlider.value = currHP;
            fill.color = gradient.Evaluate(hpSlider.normalizedValue);
        }
        public void Heal(float heal)
        {
            currHP += heal;
            SetHealth();
        }
        public void TakeDamage(float damage)
        {
            currHP -= damage;
            SetHealth();
        }
    }
}