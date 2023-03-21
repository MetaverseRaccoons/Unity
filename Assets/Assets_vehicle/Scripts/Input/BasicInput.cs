using UnityEngine;
using System.Collections;
using Luminosity.IO;

namespace RVP
{
    [RequireComponent(typeof(VehicleParent))]
    [DisallowMultipleComponent]
    [AddComponentMenu("RVP/Input/Basic Input", 0)]

    // Class for setting the input with the input manager
    public class BasicInput : MonoBehaviour
    {
        VehicleParent vp;
        public string accelAxis;
        public string brakeAxis;
        public string steerAxis;
        public string ebrakeAxis;
        public string boostButton;
        public string upshiftButton;
        public string downshiftButton;
        public string pitchAxis;
        public string yawAxis;
        public string rollAxis;
        public bool clutch;

        void Start() {
            vp = GetComponent<VehicleParent>();
        }

        void Update() {

            clutch = InputManager.GetAxis("Vertical") > 0.5f ? false : true;
            
            if (InputManager.GetButtonDown("Gear1") && clutch) {
                vp.PressGear1();
            }
            if (InputManager.GetButtonDown("Gear2") && clutch) {
                vp.PressGear2();
            }
            if (InputManager.GetButtonDown("Gear3") && clutch) {
                vp.PressGear3();
            }
            if (InputManager.GetButtonDown("Gear4") && clutch) {
                vp.PressGear4();
            }
            if (InputManager.GetButtonDown("Gear5") && clutch) {
                vp.PressGear5();
            }
            if (InputManager.GetButtonDown("Gear6") && clutch) {
                vp.PressGear6();
            }
            
            // Get single-frame input presses
            if (!string.IsNullOrEmpty(upshiftButton)) {
                // if (Input.GetButtonDown(upshiftButton)) {
                //     vp.PressUpshift();
                // }
                if (InputManager.GetButtonDown(upshiftButton))
                    vp.PressUpshift();
            }

            if (!string.IsNullOrEmpty(downshiftButton)) {
                // if (Input.GetButtonDown(downshiftButton)) {
                //     vp.PressDownshift();
                // }
                if (InputManager.GetButtonDown(downshiftButton))
                    vp.PressDownshift();
            }
        }

        void FixedUpdate() {
            // Get constant inputs
            if (!string.IsNullOrEmpty(accelAxis)) {
                //vp.SetAccel(Input.GetAxis(accelAxis));
                vp.SetAccel(InputManager.GetAxis(accelAxis));
                //Debug.Log("accelAxis: " + accelAxis + " value: " + InputManager.GetAxis(accelAxis));
            }

            if (!string.IsNullOrEmpty(brakeAxis)) {
                //vp.SetBrake(Input.GetAxis(brakeAxis));
                vp.SetBrake(InputManager.GetAxis(brakeAxis));
            }

            if (!string.IsNullOrEmpty(steerAxis)) {
                //vp.SetSteer(Input.GetAxis(steerAxis));
                vp.SetSteer(InputManager.GetAxis(steerAxis));
            }

            if (!string.IsNullOrEmpty(ebrakeAxis)) {
                //vp.SetEbrake(Input.GetAxis(ebrakeAxis));
                vp.SetEbrake(InputManager.GetAxis(ebrakeAxis));
            }

            if (!string.IsNullOrEmpty(boostButton)) {
                //vp.SetBoost(Input.GetButton(boostButton));
                vp.SetBoost(InputManager.GetButton(boostButton));
            }
            // pitch axis is for motor sound
            if (!string.IsNullOrEmpty(pitchAxis)) {
                //vp.SetPitch(Input.GetAxis(pitchAxis));
                vp.SetPitch(InputManager.GetAxis(pitchAxis));
            }

            if (!string.IsNullOrEmpty(yawAxis)) {
                //vp.SetYaw(Input.GetAxis(yawAxis));
                vp.SetYaw(InputManager.GetAxis(yawAxis));
            }

            if (!string.IsNullOrEmpty(rollAxis)) {
                //vp.SetRoll(Input.GetAxis(rollAxis));
                vp.SetRoll(InputManager.GetAxis(rollAxis));
            }

            if (!string.IsNullOrEmpty(upshiftButton)) {
                //vp.SetUpshift(Input.GetAxis(upshiftButton));
                vp.SetUpshift(InputManager.GetAxis(upshiftButton));
            }

            if (!string.IsNullOrEmpty(downshiftButton)) {
                //vp.SetDownshift(Input.GetAxis(downshiftButton));
                vp.SetDownshift(InputManager.GetAxis(downshiftButton));
            }
        }
    }
}