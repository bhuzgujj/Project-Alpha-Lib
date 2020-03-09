using System;

namespace PersonnalLib
{
    class CombatSimulation
    {
        public const double MidigationBase = 10;
        public static int SimpleDamageCalculation(double p_offensiveStats, double p_poucentageMidigated) => (int)(p_offensiveStats * p_poucentageMidigated);
        public static double MidigationCalculation(double p_defense) => 1 - (MidigationBase / MidigationBase * p_defense);
    }
}
