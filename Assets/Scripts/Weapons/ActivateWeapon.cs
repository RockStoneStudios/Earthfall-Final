using UnityEngine;
using StarterAssets;
using Cinemachine;
using TMPro;

public class ActivateWeapon : MonoBehaviour
{
    [SerializeField] WeaponScriptable startingWeapon;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] Camera weaponCamera;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;

    WeaponScriptable weaponSo;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;
    Animator animator;

    const string SHOOT_STRING = "Shoot";

    float timeSinceLanceShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startingWeapon);
        // currentWeapon = GetComponentInChildren<Weapon>();
        AdjustAmmo(weaponSo.MagazineSize);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > weaponSo.MagazineSize)
        {
            currentAmmo = weaponSo.MagazineSize;
        }
        ammoText.text = currentAmmo.ToString("D2");


    }



    public void SwitchWeapon(WeaponScriptable weaponScriptable)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponScriptable.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSo = weaponScriptable;
        AdjustAmmo(weaponScriptable.MagazineSize);
    }

    void HandleShoot()
    {
         timeSinceLanceShot += Time.deltaTime;
        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLanceShot >= weaponSo.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(weaponSo);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLanceShot = 0f;
            AdjustAmmo(-1);
        }


        if (!weaponSo.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);

        }

    }

    void HandleZoom()
    {
        

        if (!weaponSo.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = weaponSo.ZoomAmount;
            weaponCamera.fieldOfView = weaponSo.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(weaponSo.ZoomRotationSpeed);

        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);

        }
        








        }
}
