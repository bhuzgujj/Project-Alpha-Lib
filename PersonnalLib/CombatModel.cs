using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnalLib
{
    class CombatModel
    {
        // Enums
        public enum AttackType { Physical=0, Magical, Psychological }

        // Private Field
        private double __Offensive__;
        private AttackType __OffensiveType__;
        private double __PhysDefensive__;
        private double __MagicDefensive__;
        private double __PsyDefensive__;
        private int __MaxHealth__;
        private int __CurrentHealth__;

        // Getters
        public double GetOffensive() => this.__Offensive__;
        public AttackType GetOffensiveType() => this.__OffensiveType__;
        public double GetPhysDefensive() => this.__PhysDefensive__;
        public double GetMagicDefensive() => this.__MagicDefensive__;
        public double GetPsyDefensive() => this.__PsyDefensive__;
        public int GetMaxHealth() => this.__MaxHealth__;
        public int GetCurrentHealth() => this.__CurrentHealth__;

        // Setter
        public void SetOffensive(double p_offensive) 
        {
            if (p_offensive <= 0)
                throw new ArgumentOutOfRangeException();
            this.__Offensive__= p_offensive; 
        }
        public void SetOffensiveType(AttackType p_attackType) 
        { 
            this.__OffensiveType__ = p_attackType; 
        }
        public void SetPhysDefensive(double p_defensive) 
        { 
            this.__PhysDefensive__= p_defensive; 
        }
        public void SetMagicDefensive(double p_defensive) 
        {
            this.__MagicDefensive__ = p_defensive; 
        }
        public void SetPsyDefensive(double p_defensive) 
        { 
            this.__PsyDefensive__ = p_defensive; 
        }
        public void SetMaxHealth(int p_health) 
        {
            if (p_health <= 0)
                throw new ArgumentOutOfRangeException("Must be higher than 0");
            this.__MaxHealth__ = p_health; 
        }
        public void SetCurrentHealth(int p_health) 
        {
            if (p_health < 0)
                throw new ArgumentOutOfRangeException("Must be higher or equal than 0");
            if (p_health > this.__MaxHealth__)
                throw new ArgumentOutOfRangeException();
            this.__CurrentHealth__ = p_health; 
        }

        // Builders
        public CombatModel(double p_offensive, double p_physDef, double p_magicDef, double p_psyDef, int p_maxHealth, int p_currentHealth): 
            this(p_offensive, AttackType.Physical, p_physDef, p_magicDef, p_psyDef, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offensive, double p_physDef, double p_psyDef, int p_maxHealth, int p_currentHealth): 
            this(p_offensive, AttackType.Physical, p_physDef, p_physDef, p_psyDef, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offensive, AttackType p_offensiveType, double p_physDef, double p_psyDef, int p_maxHealth, int p_currentHealth): 
            this(p_offensive, p_offensiveType, p_physDef, p_physDef, p_psyDef, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offensive, double p_defensive, int p_maxHealth, int p_currentHealth): 
            this(p_offensive, AttackType.Physical, p_defensive, p_defensive, p_defensive, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offensive, AttackType p_offensiveType, double p_defensive, int p_maxHealth, int p_currentHealth): 
            this(p_offensive, p_offensiveType, p_defensive, p_defensive, p_defensive, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offensive, AttackType p_offensiveType, double p_physDef, double p_magicDef, double p_psyDef, int p_maxHealth, int p_currentHealth)
        {
            SetOffensive(p_offensive);
            SetOffensiveType(p_offensiveType);
            SetPhysDefensive(p_physDef);
            SetMagicDefensive(p_magicDef);
            SetPsyDefensive(p_psyDef);
            SetMaxHealth(p_maxHealth);
            SetCurrentHealth(p_currentHealth);
        }

        // Modifyers
        public void Damage(int p_damageTaken)
        {
            if (p_damageTaken > this.__CurrentHealth__)
                throw new ArgumentOutOfRangeException();
            this.__CurrentHealth__ -= p_damageTaken;
        }
        public void Heal(int p_heal)
        {
            if ((p_heal + this.__CurrentHealth__) > this.__MaxHealth__)
                throw new ArgumentOutOfRangeException();
            this.__CurrentHealth__ += p_heal;
        }
    }
}
