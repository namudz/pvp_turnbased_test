namespace Heroes.Health
{
    public struct HealthPoints
    {
        public float Base;
        public float Current;

        public HealthPoints(float baseHp)
        {
            Base = Current = baseHp;
        }

        public float GetCurrentHealthPercentage()
        {
            return Current / Base;
        }
    }
}