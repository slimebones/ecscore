using Scellecs.Morpeh;
using Slimebones.ECSCore.Logging;
using Slimebones.ECSCore.Audio;
using Slimebones.ECSCore.Object;
using Slimebones.ECSCore.Input;
using Slimebones.ECSCore.React;
using Slimebones.ECSCore.Request;
using Slimebones.ECSCore.UI.Settings;
using Slimebones.ECSCore.Utils.Parsing;
using System;
using TMPro;
using UnityEngine.UI;

namespace Slimebones.ECSCore.Config.Specs
{
    public class EnvironmentVolumeConfigSpec: IConfigSpec
    {
        public string Key =>
            "slimebones.ecscore.config-spec.environment-volume";
        public string DefaultValueStr => "100";
        public static readonly int MinValue = 0;
        public static readonly int MaxValue = 100;

        private World world;
        public World World
        {
            get => world;
            set => world = value;
        }

        public Action<string> OnSettingInit(Entity e)
        {
            var go = GoUtils.GetUnity(e);
            Slider sliderUnity = go.GetComponent<Slider>();

            TextMeshProUGUI displayText =
                ReactUtils.GetListenerFromReactEntity<SettingListener>(e)
                    .displayText;

            sliderUnity.minValue = MinValue;
            sliderUnity.maxValue = MaxValue;
            sliderUnity.wholeNumbers = true;

            return (string value) =>
            {
                int parsed = Parse(value);
                sliderUnity.SetValueWithoutNotify(parsed);
                SetDisplayText(parsed.ToString(), displayText);
            };
        }

        public bool OnChange(string value, out string newValue)
        {
            newValue = "";

            int volume;
            try
            {
                volume = Parse(value);
            }
            catch
            {
                Log.Error(
                    "cannot parse {0} => use default {1}",
                    value,
                    DefaultValueStr
                );
                newValue = DefaultValueStr;
                return true;
            }

            SendVolumeReq(volume);
            return false;
        }

        private void SendVolumeReq(int volume)
        {
            ref var reqc = ref RequestUtils.Create<SetAudioByTypeReq>();
            reqc.type = AudioType.Environment;
            reqc.volume = (float)volume / MaxValue;
        }

        private int Parse(string value)
        {
            int res = int.Parse(value);

            if (res < MinValue || res > MaxValue)
            {
                throw new Exception();
            }

            return res;
        }
        
        private void SetDisplayText(string text, TextMeshProUGUI displayText)
        {
            if (displayText != null)
            {
                displayText.text = text;
            }
        }
    }
}