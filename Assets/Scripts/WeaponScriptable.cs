using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects / Weapon")]
public class WeaponScriptable : ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public GameObject HitVFX;
    public bool isAutomatic = false;
    public bool CanZoom = false;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = .3f;
    public int MagazineSize = 12;
}
