using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HighStriker
{
    public class HammerController : MonoBehaviour
    {
        public AnimationCurve powerCurve;
        public float minChargeSpeed;
        public float maxChargeSpeed;
        public Slider sliderBar;

        [Header("Runtime")]
        public float currentPower;
        public float currChargeSpeed;
        public float chargeTime;

        StageManager stageManager;

        public bool isPlaying;
        
        public void Init(StageManager inStageManager)
        {
            stageManager = inStageManager;
            isPlaying = false;
        }

        public void DoUpdate(float dt)
        {
            if (isPlaying)
            {
                chargeTime += dt * currChargeSpeed;
                float t = chargeTime % 1f;
                currentPower = powerCurve.Evaluate(t);

                sliderBar.value = currentPower;
            }
        }

        void Update()
        {
            if (isPlaying && Input.GetMouseButtonDown(0))
            {
                Hit();
            }
            else if (!isPlaying && Input.GetMouseButtonDown(0))
            {
                StartCharge();
            }
        }

        public void StartCharge()
        {
            currentPower = 0;
            chargeTime = 0;
            currChargeSpeed = Random.Range(minChargeSpeed, maxChargeSpeed);

            isPlaying = true;
        }

        public void Hit()
        {
            isPlaying = false;

            stageManager.highStrikerMachine.AnimateHit(currentPower);

            Debug.Log($"Power: {currentPower}");
        }
    }
}

