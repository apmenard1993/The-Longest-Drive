using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
			float tilt_h = CrossPlatformInputManager.GetAxis ("Tilt_Horizontal");
            Boolean jump = false;
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.LoadLevel (1);
            }
 //           for(int i = 0; i < Input.touchCount; i++)
   //         {
     //           if (Input.touches[i].phase == TouchPhase.Began)
       //         {
         //           jump = true;
           //     }
             //}
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                jump = true;
            }
            m_Car.Move(h, v, 0f, jump, tilt_h);
        }
    }
}
