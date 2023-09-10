using BepInEx;
using BepInEx.Configuration;
using Photon.Pun;
using UnityEngine;

namespace StreamOverlay
{
    [BepInPlugin("com.qltesinc.streamingutils", "QlsStreamingUtils", "1.0.0")]
    public class StreamingUtils : BaseUnityPlugin
    {
        private static bool CodeDisplay;
        private static bool PlayerCount;
        private static bool GamemodeDisplay;
        private static bool SubGoal;
        private static bool Tutorial;
        private ConfigEntry<int> subGoalConfig;

        private void Awake()
        {
            subGoalConfig = Config.Bind("General", "Sub Goal", 100, "Change Sub Goal");
        }

        public void OnGUI()
        {
            GUI.skin.label.fontSize = 30;
            GUI.skin.label.fontStyle = FontStyle.Normal;
            GUI.color = Color.white;

            CodeDisplay = GUI.Toggle(new Rect(5f, 45f, 110f, 20f), CodeDisplay, "Code");
            PlayerCount = GUI.Toggle(new Rect(5f, 65f, 140f, 20f), PlayerCount, "Player Count");
            GamemodeDisplay = GUI.Toggle(new Rect(5f, 85f, 130f, 20f), GamemodeDisplay, "Gamemode");
            SubGoal = GUI.Toggle(new Rect(5f, 105f, 130f, 20f), SubGoal, "Sub Goal");
            Tutorial = GUI.Toggle(new Rect(5f, 125f, 130f, 20f), Tutorial, "Tutorial");

            if (SubGoal)
            {
                int subGoalValue = subGoalConfig.Value;
                GUI.Label(new Rect(10f, Screen.height - 85f, 200f, 40f), "Sub Goal: " + subGoalValue);
            }
            if (Tutorial)
            {
                GUI.Label(new Rect(10f, Screen.height - 105f, 7000f, 40f), "Open Bepinex, Config, Open com.qltesinc.streamingutils.cfg, edit sub goal, Relaunch");
            }

            if (PlayerCount)
            {
                if (PhotonNetwork.InRoom)
                {
                    GUI.Label(new Rect(Screen.width - 400f, 35f, 450f, 300f), "Player Count:" + PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "");
                }
                else
                {
                    GUI.Label(new Rect(Screen.width - 400f, 35f, 450f, 300f), "Not in a Room!");
                }
            }

            if (CodeDisplay)
            {
                if (PhotonNetwork.InRoom)
                {
                    GUI.Label(new Rect(Screen.width - 400f, 5f, 400f, 300f), "Code:" + PhotonNetwork.CurrentRoom.Name + "");
                }
                else
                {
                    GUI.Label(new Rect(Screen.width - 400f, 5f, 400f, 300f), "Not in a Room!");
                }
            }

            if (GamemodeDisplay)
            {
                if (PhotonNetwork.InRoom)
                {
                    GUI.Label(new Rect(10f, Screen.height - 45f, 7000f, 40f), "Current Gamemode:" + GorillaGameManager.instance.GameMode());
                }
                else
                {
                    GUI.Label(new Rect(10f, Screen.height - 45f, 450f, 40f), "Not in a Room!");
                }
            }
        }
    }
}
