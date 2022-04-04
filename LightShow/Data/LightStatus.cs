namespace LightShow.Data
{
    public class LightStatus
    {

        public bool TurnedOn {
            get; 
            set; 
        }

        public int BrightnessLevel { get; set; }

        public LightStatus()
        {

        }

        public LightStatus(bool turnOn, int brightnessLevel)
        {
            TurnedOn = turnOn;
            BrightnessLevel = brightnessLevel;
        }
    }
}
