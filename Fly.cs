using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace Promovements_Fixed.Handler
    {
        class Fly
        {
		public static bool FlyOn { get; internal set; }

		public static bool infjump { get; internal set; }

		public static float FlySpeed = 11f;

		private static bool FlyFly;
		public static bool TapTp { get; internal set; }
		private static bool Jumping()
			{

			return VRCInputManager.Method_Public_Static_ObjectPublicStSiBoSiObBoSiObStSiUnique_String_0("Jump").field_Private_Single_0 != 0f;

			}
		internal static GameObject[] GetAllGameObjects()
			{
			return UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
			}

		internal static GameObject GetLocalPlayer()
			{
			foreach (GameObject gameObject in GetAllGameObjects())
				{
				if (gameObject.name.StartsWith("VRCPlayer[Local]"))
					{
					return gameObject;
					}
				}
			return new GameObject();
			}

		private static Transform camera()
			{
			return VRCPlayer.field_Internal_Static_VRCPlayer_0.transform;
			}
		private static readonly Dictionary<OVRInput.Button, float> lastTime = new Dictionary<OVRInput.Button, float>();
		public static bool HasDoubleClicked(OVRInput.Button keyCode, float threshold)
			{
			bool flag = !OVRInput.GetDown(keyCode, OVRInput.Controller.Touch);
			bool result;
			if (flag)
				{
				result = false;
				}
			else
				{
				bool flag2 = !lastTime.ContainsKey(keyCode);
				if (flag2)
					{
					lastTime.Add(keyCode, Time.time);
					}
				bool flag3 = Time.time - lastTime[keyCode] <= threshold;
				if (flag3)
					{
					lastTime[keyCode] = threshold * 2f;
					result = true;
					}
				else
					{
					lastTime[keyCode] = Time.time;
					result = false;
					}
				}
			return result;

			}


		internal static void fly()
			{

			if (!FlyOn)
				{

				if (FlyFly)
					{

					FlyFly = false;
					Physics.gravity = new Vector3(0f, -9.81f, 0f);

					}

				}
			else if (FlyOn && !(Physics.gravity == Vector3.zero))
				{

				FlyFly = true;
				Physics.gravity = Vector3.zero;

				}

			if (FlyOn && !(Player.prop_Player_0 == null))
				{

				float num = Input.GetKey(KeyCode.LeftShift) ? (Time.deltaTime * FlySpeed) : (Time.deltaTime * (FlySpeed / 3));

				if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < -0.5f)
					{
					Player.prop_Player_0.transform.position -= camera().up * num;

					}
				if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0.5f)
					{
					Player.prop_Player_0.transform.position += camera().up * num;
					}
				if (Input.GetAxis("Vertical") != 0f)
					{
					Player.prop_Player_0.transform.position += camera().forward * (num * Input.GetAxis("Vertical"));
					}
				if (Input.GetAxis("Vertical") == 0f)
					{
					Networking.LocalPlayer.SetVelocity(Vector3.zero);
					}
				if (Input.GetAxis("Horizontal") != 0f)
					{
					Player.prop_Player_0.transform.position += camera().transform.right * (num * Input.GetAxis("Horizontal"));
					}



				}

			}

		    internal static void InfJump()
			{

			if (infjump && Jumping() && !Networking.LocalPlayer.IsPlayerGrounded())
				{
				Vector3 velocity = Networking.LocalPlayer.GetVelocity();
				velocity.y = Networking.LocalPlayer.GetJumpImpulse();
				Networking.LocalPlayer.SetVelocity(velocity);
				}

			}

		internal static void Tap_Tp_Toggle()
			{


		    	if (TapTp && HasDoubleClicked((OVRInput.Button)4, 0.25f))
				{



				Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);


				if (Physics.Raycast(ray, out RaycastHit raycastHit)) GetLocalPlayer().transform.position = raycastHit.point;




				}

			}
		}
	}
