using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CharacterAttributes", order = 1)]
public class CharacterAttributes : ScriptableObject
{
    #region movementStats
    [Header("Player Movement Attributes")]
    [SerializeField] private float wSpeed;
    [SerializeField] private float iRunSpeed;
    [SerializeField] private float rMaxSpeed;
    [SerializeField] private float rAccel;
    [SerializeField] private float rAccelAmount;
    [SerializeField] private float rDeccel;
    [SerializeField] private float rDeccelAmount;
    [SerializeField] private float jSpeed;
    [SerializeField] private float jAmount;
    [SerializeField] private float adAmount;
    [SerializeField] private float gravity;
    [SerializeField] private float friction;
    public bool isWalkingAllowed;
    public bool isRunningAllowed;
    public bool doConserveMomentum;
    public bool isBlockingAllowed;

    public float walkSpeed { get { return wSpeed; } set { wSpeed = value; } }
    public float initialRunSpeed { get { return iRunSpeed; } set { iRunSpeed = value; } }
    public float runMaxSpeed { get { return rMaxSpeed; } set { rMaxSpeed = value; } }
    public float runAccel { get { return rAccel; } set { rAccel = value; } }
    public float runAccelAmount { get { return rAccelAmount; } set { rAccelAmount = value; } }
    public float jumpSpeed { get { return jSpeed; } set { jSpeed = value; } }
    public float jumpAmount { get { return jAmount; } set { jAmount = value; } }
    public float airDashAmount { get { return adAmount; } set { adAmount = value; } }


    
    
    #endregion

    #region healthStats
    [Header("Player Health Attributes")]
    private int health = 420;
    public int guts;
    public float defenseRating;
    #endregion

    #region weightNWakeupStats
    [Header("Player Weight and Wakeup Attributes")]
    [SerializeField] private float faceDownTime;
    [SerializeField] private float faceUpTime;
    public string characterWeight;
    #endregion

}
