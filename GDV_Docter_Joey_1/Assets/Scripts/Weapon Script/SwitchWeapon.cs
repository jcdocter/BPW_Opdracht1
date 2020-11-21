using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    private int currentWeapon = 0;

    public static SwitchWeapon instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        weapons[currentWeapon].gameObject.SetActive(true);
    }


    public void SelectWeapon(int weaponIndex)
    {
       if(currentWeapon == weaponIndex)
        {
            return;
        }

        currentWeapon = weaponIndex;
        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i] == null)
            {
                break;
            }
            if(i != currentWeapon)
            {
                weapons[i].gameObject.SetActive(false);
            }
            else
            {
                weapons[i].gameObject.SetActive(true);
                currentWeapon = weaponIndex;
            }
        }
    }
}
