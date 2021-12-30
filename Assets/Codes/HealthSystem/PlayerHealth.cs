using UnityEngine;
using UnityEngine.UI;
namespace HealthSystem
{
    public class PlayerHealth : MonoBehaviour
    {
        float minHP = 0f;
        float criticalHP = 25f;
        float maxHP = 100f;
        public float currHP = 100f;

        public Slider hpSlider = null;
        public Gradient gradient = null;
        public Color iconColor;

        public Image fill = null;
        public Image icon = null;

        void Start()
        {
            hpSlider.minValue = minHP;
            hpSlider.maxValue = maxHP;
            iconColor = icon.color;
            fill.color = gradient.Evaluate(1f);
        }
        public void SetHealth()
        {
            if (currHP < minHP) currHP = minHP;
            else if (currHP <= criticalHP) icon.color = Color.black;
            else if (currHP > criticalHP)
            {
                icon.color = iconColor;
                if (currHP > maxHP) currHP = maxHP;
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