using UnityEngine;

//made by Joey Docter
//switch weapon
public class SwitchWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    private int currentWeapon = 0;

    public static SwitchWeapon instance;

    void Awake()
    {
        instance = this;

        //weapon on index 0 is active
        weapons[currentWeapon].gameObject.SetActive(true);
    }


    public void SelectWeapon(int weaponIndex)
    {
       if(currentWeapon == weaponIndex)
        {
            return;
        }

        currentWeapon = weaponIndex;
        
        //get all weapons in the array
        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i] == null)
            {
                break;
            }
            if(i != currentWeapon)
            {
                //disable current weapon
                weapons[i].gameObject.SetActive(false);
            }
            else
            {
                //get weaponIndex
                weapons[i].gameObject.SetActive(true);
                currentWeapon = weaponIndex;
            }
        }
    }
}
