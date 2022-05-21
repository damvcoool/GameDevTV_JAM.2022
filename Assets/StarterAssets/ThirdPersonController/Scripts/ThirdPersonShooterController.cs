using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform aimPosition;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private bool useRayCastHitTransform = false;
    [SerializeField] private Rig aimRig;
    [SerializeField] private Image crosshairs;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;

    private bool isAiming = false;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);

        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, aimColliderLayerMask))
        {
                mouseWorldPosition = raycastHit.point;
                aimPosition.position = raycastHit.point;
                hitTransform = raycastHit.transform;
        }


        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            thirdPersonController.SetCanSprint(false);
            isAiming = true;
            aimRig.weight = Mathf.Lerp(aimRig.weight, 1f, Time.deltaTime * 20f);
            crosshairs.CrossFadeAlpha(1f, 0.5f, false);
            animator.SetLayerWeight(1,Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));


            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            thirdPersonController.SetCanSprint(true);
            isAiming = false;
            aimRig.weight = Mathf.Lerp(aimRig.weight, 0f, Time.deltaTime * 20f);
            crosshairs.CrossFadeAlpha(0f, 0.1f, false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            
        }

        if (starterAssetsInputs.shoot && isAiming)
        {
            if (!useRayCastHitTransform)
            {
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(bulletPrefab, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            }
            else
            {
                if(hitTransform != null)
                {
                    if(raycastHit.collider.GetComponent<Target>() != null)
                        Debug.Log($"Target {raycastHit.collider.name} has been hit");
                }
            }

            starterAssetsInputs.shoot = false;
        }

        

    }
}