using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;

    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    [Header("Detection UI")]
    public GameObject alertIcon;

    [Header("Detection Sound")]
    public AudioSource audioSource;
    public AudioClip detectedSound;

    [Header("Rotation")]
    public float rotationSpeed = 5f;

    private bool wasSeeingPlayer;
    private PlayerStealth playerStealth;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        if (playerRef != null)
        {
            playerStealth = playerRef.GetComponent<PlayerStealth>();
        }

        if (alertIcon != null)
        {
            alertIcon.SetActive(false);
        }

        StartCoroutine(FOVRoutine());
    }

    private void Update()
    {
        if (canSeePlayer && playerRef != null)
        {
            RotateTowardPlayer();
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;

            wasSeeingPlayer = canSeePlayer;

            FieldOfViewCheck();

            if (alertIcon != null)
            {
                alertIcon.SetActive(canSeePlayer);
            }

            if (canSeePlayer && !wasSeeingPlayer)
            {
                PlayDetectionSound();
            }
        }
    }

    private void FieldOfViewCheck()
    {
        if (playerStealth != null && playerStealth.isHidden)
        {
            canSeePlayer = false;
            return;
        }
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else
        {
            canSeePlayer = false;
        }
    }

    private void RotateTowardPlayer()
    {
        Vector3 direction = playerRef.transform.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.01f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private void PlayDetectionSound()
    {
        if (audioSource != null && detectedSound != null)
        {
            audioSource.PlayOneShot(detectedSound);
        }
    }
}