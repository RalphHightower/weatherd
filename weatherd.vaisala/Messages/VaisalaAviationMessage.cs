﻿namespace weatherd.datasources.Vaisala.Messages
{
    public class VaisalaAviationMessage : VaisalaMessage
    {
        public const int Parts = 12;

        public VaisalaValue<int> OneMinuteAverageVisibility { get; private set; }
        public VaisalaValue<int> TenMinuteAverageVisibility { get; private set; }
        public VaisalaValue<string> NWSWeatherCode { get; private set; }
        public VaisalaValue<WMOCodeTable> InstantaneousWeather { get; private set; }
        public VaisalaValue<WMOCodeTable> Weather15Minute { get; private set; }
        public VaisalaValue<WMOCodeTable> Weather1Hour { get; private set; }
        public VaisalaValue<float> OneMinuteWaterIntensity { get; private set; }
        public VaisalaValue<float> CumulativeWater { get; private set; }
        public VaisalaValue<int> CumulativeSnow { get; private set; }
        public VaisalaValue<float> Temperature { get; private set; }
        public VaisalaValue<int> BackgroundLuminance { get; private set; }

        public VaisalaAviationMessage() :
            base(VaisalaMessageType.Aviation) { }

        /// <inheritdoc />
        protected override VaisalaMessage Parse(SpanSplitEnumerator spanSplit)
        {
            if (!ParseAlarms(ref spanSplit))
                return null;
            
            bool isValid = true;
            
            OneMinuteAverageVisibility = VaisalaValue<int>.Parse(ref spanSplit, ref isValid);
            TenMinuteAverageVisibility = VaisalaValue<int>.Parse(ref spanSplit, ref isValid);
            NWSWeatherCode = VaisalaValue<string>.Parse(ref spanSplit, ref isValid);
            InstantaneousWeather = VaisalaValue<WMOCodeTable>.Parse(ref spanSplit, ref isValid);
            Weather15Minute = VaisalaValue<WMOCodeTable>.Parse(ref spanSplit, ref isValid);
            Weather1Hour = VaisalaValue<WMOCodeTable>.Parse(ref spanSplit, ref isValid);
            OneMinuteWaterIntensity = VaisalaValue<float>.Parse(ref spanSplit, ref isValid);
            CumulativeWater = VaisalaValue<float>.Parse(ref spanSplit, ref isValid);
            CumulativeSnow = VaisalaValue<int>.Parse(ref spanSplit, ref isValid);
            Temperature = VaisalaValue<float>.Parse(ref spanSplit, ref isValid);
            BackgroundLuminance = VaisalaValue<int>.Parse(ref spanSplit, ref isValid);

            return !isValid ? null : this;
        }
    }
}
