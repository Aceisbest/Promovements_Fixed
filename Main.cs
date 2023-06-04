using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Promovements_Fixed.Handler;
using ReMod.Core.Managers;
using ReMod.Core.Unity;
using ReMod.Core.VRChat;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace Promovements_Fixed
    {
    class Main : MelonMod
        {
       
        //Promovements was made by EdenFails<3


        #region WAIT FOR UI<3
           public override void OnApplicationStart()
            {

             ClassInjector.RegisterTypeInIl2Cpp<EnableDisableListener>();
             MelonCoroutines.Start(WaitForUI());






            }

        private IEnumerator WaitForUI()
            {

            yield return MenuEx.WaitForUInPatch();
            UserInterface = MenuEx.userInterface;
            MenuStart();

            }

            public override void OnUpdate()
            {
            Fly.fly();
            Fly.InfJump();
            Fly.Tap_Tp_Toggle();
            }

        #endregion

        #region Objects
        public static GameObject UserInterface;
        public static UiManager _Ui;
        public static string Color = "#ffffff";
        #endregion
        
        #region Menu<3
            internal static void MenuStart()
            {
             _Ui = new UiManager("Promovements<3", Icons.Tab,true,false,false,false,Color);

              var Move =  _Ui.MainMenu.AddCategoryPage("Movements<3", null, Icons.Tab, Color);

            #region FLY AND SPEED AND JUMP
            var Sl = Move.AddSliderCategory("Speed/Jump/Fly<3");

            Sl.AddSlider("Speed", "This is for your speed", SpeedVal =>
            {
                if (Player.prop_Player_0 != null)
                    {
                    Networking.LocalPlayer.SetRunSpeed(SpeedVal);
                    }

            }, false, 4, 0, 100);

            Sl.AddSlider("Jump<3", "This is for your jump", SpeedVal =>
            {
                if (Player.prop_Player_0 != null)
                    {
                    Networking.LocalPlayer.SetJumpImpulse(SpeedVal);
                    }

            }, false, 4, 0, 100);

            Sl.AddSlider("Fly<3", "This is for your fly", SpeedVal =>
            {
                if (Player.prop_Player_0 != null)
                    {
                    Fly.FlySpeed = (SpeedVal);
                    }

            }, false, 4, 0, 100);


            #endregion
            
            #region action menu
            
            ActionMenuPage actionPage = new("ProMovements", Icons.Tab);
            ActionMenuToggle button = new(actionPage, "Fly", (e) => ToggleFly);
            ActionMenuToggle button2 = new(actionPage, "Jetpack", (e) => ToggleInfJump);
            ActionMenuToggle button = new(actionPage, "Raycast Teleport", (e) => ToggleRayCast);
            
            #endregion
            
            #region Toggles<3
            var Sad = Move.AddCategory("Stuff<3");

            Sad.AddToggle("Fly<3", " ", ToggleFly,Color);
            Sad.AddToggle("Jetpack<3", " ", ToggleInfJump, Color);
            Sad.AddToggle("RayCast Tp<3", " ", ToggleRayCast, Color);



            #endregion

            #region Cr
            var Cr = Move.AddCategory("Credits");

            Cr.AddLabel("Maker", "EdenFails",25,Color);
           
            Cr.AddLabel("Helper", "Cyril XD", 25, Color);

            Cr.AddLabel("Fixer", "Ace", 25, Color);
            #endregion

            ////////////<3333333333333333333333333333333
            MelonLogger.Msg("-------------------------");
            MelonLogger.Msg("Promovements loadded<3");
            MelonLogger.Msg("By EdenFails<3");
            MelonLogger.Msg("Fixed by Ace");
            MelonLogger.Msg("-------------------------");
            ////////////<3333333333333333333333333333333
            }
        #endregion





        #region :3
        internal static void ToggleFly(bool value)
            {
            Fly.Flyon = value;
            Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = !value;
            }

        internal static void ToggleInfJump(bool value) => Fly.infjump = value;
            
        internal static void ToggleRayCast(bool value) => Fly.TapTp = value;

        #endregion
        }




    }
