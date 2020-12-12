using UnityEngine;
using UnityEngine.UI;

//made by Joey Docter
// health display
public class HealthUI : MonoBehaviour
{
    public Slider slider;

    //start health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //change health value
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
