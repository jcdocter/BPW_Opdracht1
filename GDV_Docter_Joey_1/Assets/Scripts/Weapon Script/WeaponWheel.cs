using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    public static WeaponWheel instance;

    private KeyCode wheelKey = KeyCode.Tab;
    [SerializeField] private GameObject wheelParent;
    private bool wheelEnabled;


    [Serializable]
    public class Wheel
    {
        public Sprite hightlightSprite;
        private Sprite normalSprite;
        public Image wheel;

        public Sprite NormalSprite
        {
            get => normalSprite;
            set => normalSprite = value;
        }
    }

    [SerializeField] 
    private Wheel[] wheels = new Wheel[5];

    [Header("Dots & Lines")]

    [SerializeField]
    private Transform[] dots = new Transform[6];
    private Vector2[] pos = new Vector2[6];
    private Vector2 mousePos;

    private float Area(Vector2 v1, Vector2 v2, Vector2 v3)
    {
        return Mathf.Abs((v1.x * (v2.y - v3.y) + v2.x * (v3.y - v1.y) + v3.x * (v1.y - v2.y)) / 2f);
    }

    private bool isInside(Vector2 v1, Vector2 v2, Vector2 v3, Vector2 v)
    {
        float A = Area(v1, v2, v3);
        float A1 = Area(v1, v2, v);
        float A2 = Area(v1, v, v3);
        float A3 = Area(v, v2, v3);

        return (Mathf.Abs(A1 + A2 + A3 - A) < 1f);
    }

    [SerializeField] private Camera playerCamera;

    public Image timerBar;
    public static float powerUpTimer;
    public static bool stopCounting = false;

    private void Awake()
    {
        powerUpTimer = 0f;
    }

    void Start()
    {
        DisableWheel();

        for(int i = 0; i < wheels.Length; i++)
        {
            if(wheels[i].wheel != null)
            {
                wheels[i].NormalSprite = wheels[i].wheel.sprite;
            }
        }
    }

    void Update()
    {
        if (stopCounting == false)
        {
            if (powerUpTimer <= 60f)
            {
                powerUpTimer += Time.deltaTime;
                timerBar.fillAmount = powerUpTimer / 60f;
            }
            else
            {
                stopCounting = true;
            }
        }

        if (Input.GetKey(wheelKey))
        {
            EnableWheel();
            CheckForCurrentWeapon();
        }
        else if (Input.GetKeyUp(wheelKey))
        {
            DisableWheel();
        }
    }

    void EnableWheel()
    {
        if(wheelParent != null)
        {
            wheelParent.SetActive(true);
            wheelEnabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void DisableWheel()
    {
        if (wheelParent != null)
        {
            wheelParent.SetActive(false);
            wheelEnabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    //is the wheel selected
    void EnableHighlight(int index)
    {
        for(int i = 0; i < wheels.Length; i++)
        {
            if(wheels[i].wheel != null && wheels[i].hightlightSprite != null)
            {
                if(i == index)
                {
                    wheels[i].wheel.sprite = wheels[i].hightlightSprite;
                }
                else
                {
                    wheels[i].wheel.sprite = wheels[i].NormalSprite;
                }
            }
        }
    }

    void CheckForCurrentWeapon()
    {
        if(playerCamera == null)
        {
            return;
        }

        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = playerCamera.WorldToScreenPoint(dots[i].position);
        }
        mousePos = Input.mousePosition;

        if(isInside(pos[0], pos[1], pos[2], mousePos))
        {
            EnableHighlight(0);
            SwitchWeapon.instance.SelectWeapon(0);
        }
        else if (isInside(pos[0], pos[2], pos[3], mousePos))
        {
            EnableHighlight(1);
            SwitchWeapon.instance.SelectWeapon(1);
        }
        else if (isInside(pos[0], pos[3], pos[4], mousePos))
        {
            EnableHighlight(2);
            SwitchWeapon.instance.SelectWeapon(2);
        }
        else if (isInside(pos[0], pos[4], pos[5], mousePos))
        {
            EnableHighlight(3);
            SwitchWeapon.instance.SelectWeapon(3);
        }
        else if (isInside(pos[0], pos[5], pos[1], mousePos) && stopCounting == true)
        {
            EnableHighlight(4);
            SwitchWeapon.instance.SelectWeapon(4);
        }
    }
}
