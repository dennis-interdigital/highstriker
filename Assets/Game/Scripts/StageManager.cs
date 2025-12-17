using UnityEngine;

//READ ME: Edit using:
//VS: ctrl+r, ctrl+r
//Rider: Shift+F6
namespace HighStriker 
{
    public class StageManager : MonoBehaviour
    {
        bool gameReady = false;

        void Start()
        {
            gameReady = true;
        }

        void FixedUpdate()
        {
            if (gameReady)
            {
                float dt = Time.deltaTime;

                //DoUpdate here
            }
        }
    }
}
