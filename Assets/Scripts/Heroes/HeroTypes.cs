using System;

namespace Heroes
{
    public static class HeroTypes
    {
        public enum Team
        {
            Player_1,
            Player_2
        }
    }

    public static class HeroTeamExtensions
    {
        public static HeroTypes.Team GetRivalTeam(this HeroTypes.Team myTeam)
        {
            switch (myTeam)
            {
                case HeroTypes.Team.Player_1:
                    return HeroTypes.Team.Player_2;
                case HeroTypes.Team.Player_2:
                    return HeroTypes.Team.Player_1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(myTeam), myTeam, null);
            }
        }
    }
}