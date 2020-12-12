using UnityEngine;
using TMPro;

//made by Joey Docter
//throw grenade
public class ThrowGrenade : MonoBehaviour
{
    private float throwForce = 20f;
    public GameObject grenadePrefab;
    private float throwTimer = 3f;
    public TextMeshProUGUI ammoText;
    private int maxAmmo = 1;
    private int currentAmmo;


    void Update()
    {
        // throw grenade 
        if (throwTimer >= 3f)
        {
            currentAmmo = 1;
            this.transform.localScale = new Vector3(1, 1, 1);
            if (Input.GetMouseButtonDown(0))
            {
                //disable grenade object for 3 sec
                Throw();
                throwTimer = 0f;
                this.transform.localScale = new Vector3(0, 0, 0);

                // ammo is 0
                currentAmmo--;
            }
        } else
        {
            throwTimer += Time.deltaTime;
        }
        //display ammo
        ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }

    //throw prefab grenade
    void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        //add force
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
