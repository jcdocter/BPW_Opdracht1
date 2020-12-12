using UnityEngine;
using System.Collections;
using TMPro;

//made by Joey Docter
// change weapon functions
public class WeaponHandler : MonoBehaviour
{
    public float damage = 10f;
    private float range = 100f;
    private float fireRate = 5f;

    private float nextTimeToFire = 0f;

    public float maxAmmo = 10f;
    private float currentAmmo;
    private float reloadTime = 1f;
    private bool isReloading = false;

    public TextMeshProUGUI ammoText;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    public Animator animator;
    public GameObject weaponType;

    public enum WeaponType
    {
        M1911,
        AK74,
        SUPERWEAPON
    }

    private WeaponType weaponTypes;

    void Awake()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        switch (weaponTypes)
        {
            case WeaponType.M1911: Pistol();
                break;
            case WeaponType.AK74: Rifle();
                break;
            case WeaponType.SUPERWEAPON: PowerUp();
                break;
        }

        //update ammo text
        Ammo();
    }

    void Pistol()
    {
        //Pistol weapon
            if (currentAmmo < 10f)
            {
                if (currentAmmo <= 0f || Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Reload());
                    return;
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }


        if (weaponType.gameObject.name == "AK74")
        {
            weaponTypes = WeaponType.AK74;
        }

        else if (weaponType.gameObject.name == "Super weapon")
        {
            weaponTypes = WeaponType.SUPERWEAPON;
        }
    }

    void Rifle()
    {
        //AutoWeapon
        if (currentAmmo < 30f)
            {
                if (currentAmmo <= 0f || Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Reload());
                    return;
                }
            }

            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }


        if (weaponType.gameObject.name == "M1911")
        {
            weaponTypes = WeaponType.M1911;
        }

        else if (weaponType.gameObject.name == "Super weapon")
        {
            weaponTypes = WeaponType.SUPERWEAPON;
        }
    }

    void PowerUp()
    {
        //Power up weapon
        // ammo is equal to 60 from the timer
        currentAmmo = Mathf.RoundToInt(WeaponWheel.powerUpTimer);

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            WeaponWheel.powerUpTimer--;
        }


        if (weaponType.gameObject.name == "M1911")
        {
            weaponTypes = WeaponType.M1911;
        }

        //force cahnge weapon
        else if (currentAmmo <= 0f)
        {
            SwitchWeapon.instance.SelectWeapon(0);
            weaponTypes = WeaponType.M1911;

            WeaponWheel.powerUpTimer = 0f;
            WeaponWheel.stopCounting = false;
        }

        else if (weaponType.gameObject.name == "AK74")
        {
            weaponTypes = WeaponType.AK74;
        }
    }

    void Shoot()
    {
        //activate shoot animation
        muzzleFlash.Play();

        //decrease ammo
        currentAmmo--;

        //hit enemy
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            target?.TakeDamage(damage);
        }
    }

    //reload weapon
    IEnumerator Reload()
    {
        isReloading = true;

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);

        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        currentAmmo = maxAmmo;

        isReloading = false;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    //display ammo
    void Ammo()
    {
        ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }
}
