using UnityEngine;

namespace HighStriker 
{
    public class StageManager : MonoBehaviour
    {
        public HammerController hammerController;
        public HighStrikerMachine highStrikerMachine;
        public UIManager uiManager;

        [Header("Config")]
        public float perfectScoreTreshold;

        bool gameReady = false;

        void Start()
        {
            hammerController.Init(this);
            highStrikerMachine.Init(this);
            uiManager.Init(this);

            gameReady = true;

            uiManager.ShowUI(UIState.Title);
        }

        void FixedUpdate()
        {
            if (gameReady)
            {
                float dt = Time.deltaTime;

                //DoUpdate here
                hammerController.DoUpdate(dt);

                uiManager.DoUpdate(dt);
            }
        }
    }
}
