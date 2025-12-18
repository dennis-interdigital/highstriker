using UnityEngine;

//READ ME: Edit using:
//VS: ctrl+r, ctrl+r
//Rider: Shift+F6
namespace HighStriker 
{
    public class StageManager : MonoBehaviour
    {
        public HammerController hammerController;
        public HighStrikerMachine highStrikerMachine;

        [Header("Config")]
        public float perfectScoreTreshold;

        bool gameReady = false;

        void Start()
        {
            hammerController.Init(this);
            highStrikerMachine.Init(this);

            gameReady = true;
        }

        void FixedUpdate()
        {
            if (gameReady)
            {
                float dt = Time.deltaTime;

                //DoUpdate here
                hammerController.DoUpdate(dt);
            }
        }
    }
}
