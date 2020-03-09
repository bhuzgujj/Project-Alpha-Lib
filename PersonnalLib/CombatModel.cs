using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnalLib
{
    class CombatModel
    {
        // Struct
        public struct AttackTypes
        {
            public double Physical;
            public double Magical;
            public double Psychological;
        }

        // Enums
        public enum CombatType { Physical = 0, Magical, Psychological }

        // Private Field
        private AttackTypes __Offensives__;
        private AttackTypes __BaseOffensives__;
        private AttackTypes __Defensives__;
        private AttackTypes __BaseDefensives__;
        private int __MaxHealth__;
        private int __CurrentHealth__;

        // Getters
        public AttackTypes GetOffensives() => this.__Offensives__;
        public double GetPhysOffensive() => this.__Offensives__.Physical;
        public double GetMageOffensive() => this.__Offensives__.Magical;
        public double GetPsyOffensive() => this.__Offensives__.Psychological;

        public AttackTypes GetBaseOffensives() => this.__BaseOffensives__;
        public double GetBasePhysOffensive() => this.__BaseOffensives__.Physical;
        public double GetBaseMageOffensive() => this.__BaseOffensives__.Magical;
        public double GetBasePsyOffensive() => this.__BaseOffensives__.Psychological;

        public AttackTypes GetDefensives() => this.__Defensives__;
        public double GetPhysDefensive() => this.__Defensives__.Physical;
        public double GetMageDefensive() => this.__Defensives__.Magical;
        public double GetPsyDefensive() => this.__Defensives__.Psychological;

        public AttackTypes GetBaseDefensives() => this.__BaseOffensives__;
        public double GetBasePhysDefensive() => this.__BaseOffensives__.Physical;
        public double GetBaseMageDefensive() => this.__BaseOffensives__.Magical;
        public double GetBasePsyDefensive() => this.__BaseOffensives__.Psychological;

        public int GetMaxHealth() => this.__MaxHealth__;
        public int GetCurrentHealth() => this.__CurrentHealth__;

        // Setter
        public void SetOffensives(double p_physical, double p_magical, double p_psychological)
        {
            if (p_physical < 0 || p_magical < 0 || p_psychological < 0)
                throw new ArgumentOutOfRangeException("Offensives can't be negative!");
            this.__BaseOffensives__ = new AttackTypes { Physical = p_physical, Magical = p_magical, Psychological = p_psychological };
            this.__Offensives__ = new AttackTypes { Physical = p_physical, Magical = p_magical, Psychological = p_psychological };
        }
        public void SetDefensives(double p_physical, double p_magical, double p_psychological)
        {
            this.__BaseDefensives__ = new AttackTypes { Physical = p_physical, Magical = p_magical, Psychological = p_psychological };
            this.__Defensives__ = new AttackTypes { Physical = p_physical, Magical = p_magical, Psychological = p_psychological };
        }
        public void SetMaxHealth(int p_health)
        {
            if (p_health <= 0)
                throw new ArgumentOutOfRangeException("Max health must be higher than 0");
            this.__MaxHealth__ = p_health;
        }
        public void SetCurrentHealth(int p_health)
        {
            if (p_health < 0)
                throw new ArgumentOutOfRangeException("Current health must be higher or equal to 0");
            if (p_health > this.__MaxHealth__)
                throw new ArgumentOutOfRangeException("Current health must be lower than or equal to Max health");
            this.__CurrentHealth__ = p_health;
        }

        // Builders
        // With Currenth health
        public CombatModel(double p_physOff, double p_psyOff, double p_physDef, double p_magicDef, double p_psyDef, int p_maxHealth, int p_currentHealth) :
            this(p_physOff, p_physOff, p_psyOff, p_physDef, p_magicDef, p_psyDef, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_physOff, double p_psyOff, double p_physDef, double p_psyDef, int p_maxHealth, int p_currentHealth) :
            this(p_physOff, p_physOff, p_psyOff, p_physDef, p_physDef, p_psyDef, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offensive, double p_physDef, double p_psyDef, int p_maxHealth, int p_currentHealth) :
            this(p_offensive, p_offensive, p_offensive, p_physDef, p_physDef, p_psyDef, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offensive, double p_defensive, int p_maxHealth, int p_currentHealth) :
            this(p_offensive, p_offensive, p_offensive, p_defensive, p_defensive, p_defensive, p_maxHealth, p_currentHealth) { }
        public CombatModel(double p_offenseDefense, int p_maxHealth, int p_currentHealth) :
            this(p_offenseDefense, p_offenseDefense, p_offenseDefense, p_offenseDefense, p_offenseDefense, p_offenseDefense, p_maxHealth, p_currentHealth) { }
        public CombatModel(int p_maxHealth, int p_currentHealth) :
            this(1, 1, 1, 1, 1, 1, p_maxHealth, p_currentHealth) { }
        public CombatModel() :
            this(1, 1, 1, 1, 1, 1, 10, 10) { }
        // No current health
        public CombatModel(double p_physOff, double p_psyOff, double p_physDef, double p_magicDef, double p_psyDef, int p_maxHealth) :
            this(p_physOff, p_physOff, p_psyOff, p_physDef, p_magicDef, p_psyDef, p_maxHealth, p_maxHealth) { }
        public CombatModel(double p_physOff, double p_psyOff, double p_physDef, double p_psyDef, int p_maxHealth) :
            this(p_physOff, p_physOff, p_psyOff, p_physDef, p_physDef, p_psyDef, p_maxHealth, p_maxHealth) { }
        public CombatModel(double p_offensive, double p_physDef, double p_psyDef, int p_maxHealth) :
            this(p_offensive, p_offensive, p_offensive, p_physDef, p_physDef, p_psyDef, p_maxHealth, p_maxHealth) { }
        public CombatModel(double p_offensive, double p_defensive, int p_maxHealth) :
            this(p_offensive, p_offensive, p_offensive, p_defensive, p_defensive, p_defensive, p_maxHealth, p_maxHealth) { }
        public CombatModel(double p_offenseDefense, int p_maxHealth) :
            this(p_offenseDefense, p_offenseDefense, p_offenseDefense, p_offenseDefense, p_offenseDefense, p_offenseDefense, p_maxHealth, p_maxHealth) { }
        public CombatModel(int p_maxHealth) :
            this(1, 1, 1, 1, 1, 1, p_maxHealth, p_maxHealth) { }
        // Base
        public CombatModel(double p_physOff, double p_magicOff, double p_psyOff, double p_physDef, double p_magicDef, double p_psyDef, int p_maxHealth, int p_currentHealth)
        {
            SetOffensives(p_physOff, p_magicOff, p_psyOff);
            SetDefensives(p_physDef, p_magicDef, p_psyDef);
            SetMaxHealth(p_maxHealth);
            SetCurrentHealth(p_currentHealth);
        }

        // Modifyers
        public void Damage(int p_damageTaken)
        {
            if (p_damageTaken > this.__CurrentHealth__)
                this.__CurrentHealth__ = 0;
            else
                this.__CurrentHealth__ -= p_damageTaken;
        }
        public void Heal(int p_heal)
        {
            if (!IsDead())
            {
                if ((p_heal + this.__CurrentHealth__) > this.__MaxHealth__)
                    this.__CurrentHealth__ = this.__MaxHealth__;
                else
                    this.__CurrentHealth__ += p_heal;
            }
        }
        public bool IsDead() => this.__CurrentHealth__ == 0;
        public bool Resurection(int p_heal = 0)
        {
            if (IsDead())
            {
                if (p_heal == 0)
                    this.__CurrentHealth__ = (int)(this.__MaxHealth__ * 0.2);
                else if (p_heal < 0)
                    throw new ArgumentOutOfRangeException("Health can't be negatif");
                else if (p_heal > this.__MaxHealth__)
                    throw new ArgumentOutOfRangeException("Current health can't be higher than Max health");
                else
                    this.__CurrentHealth__ = p_heal;
                return true;
            }
            return false;
        }
        public void ModifyerOffenseAdd(CombatType p_combatType, double p_buff)
        {
            switch (p_combatType)
            {
                case CombatType.Physical: 
                    if (p_buff + this.__Offensives__.Physical >= 0) 
                    { 
                        this.__Offensives__.Physical += p_buff; 
                    } 
                    break;
                case CombatType.Magical:
                    if (p_buff + this.__Offensives__.Magical >= 0)
                    {
                        this.__Offensives__.Magical += p_buff; 
                    }
                    break;
                case CombatType.Psychological:
                    if (p_buff + this.__Offensives__.Psychological >= 0)
                    {
                        this.__Offensives__.Psychological += p_buff;
                    } 
                    break;
                default: 
                    throw new ArgumentException("CombatType invalid!");
            }
        }
        public void ModifyerOffenseMulti(CombatType p_combatType, double p_buff)
        {
            if (p_buff < 0)
                throw new ArgumentOutOfRangeException("Modifyer can't be negative!");
            switch (p_combatType)
            {
                case CombatType.Physical: this.__Offensives__.Physical *= p_buff; break;
                case CombatType.Magical: this.__Offensives__.Magical *= p_buff; break;
                case CombatType.Psychological: this.__Offensives__.Psychological *= p_buff; break;
                default: throw new ArgumentException("CombatType invalid!");
            }
        }
        public void ModifyerDefenseAdd(CombatType p_combatType, double p_buff)
        {
            switch (p_combatType)
            {
                case CombatType.Physical:
                    if (p_buff + this.__Defensives__.Physical >= 0)
                    {
                        this.__Defensives__.Physical += p_buff;
                    }
                    break;
                case CombatType.Magical:
                    if (p_buff + this.__Defensives__.Magical >= 0)
                    {
                        this.__Defensives__.Magical += p_buff;
                    }
                    break;
                case CombatType.Psychological:
                    if (p_buff + this.__Defensives__.Psychological >= 0)
                    {
                        this.__Defensives__.Psychological += p_buff;
                    }
                    break;
                default:
                    throw new ArgumentException("CombatType invalid!");
            }
        }
        public void ModifyerDefenseMulti(CombatType p_combatType, double p_buff)
        {
            if (p_buff < 0)
                throw new ArgumentOutOfRangeException("Modifyer can't be negative!");
            switch (p_combatType)
            {
                case CombatType.Physical: this.__Defensives__.Physical *= p_buff; break;
                case CombatType.Magical: this.__Defensives__.Magical *= p_buff; break;
                case CombatType.Psychological: this.__Defensives__.Psychological *= p_buff; break;
                default: throw new ArgumentException("CombatType invalid!");
            }
        }
        public void ResetAllDefenseMod()
        {
            this.__Defensives__.Physical = this.__BaseDefensives__.Physical;
            this.__Defensives__.Magical = this.__BaseDefensives__.Magical;
            this.__Defensives__.Psychological = this.__BaseDefensives__.Psychological;
        }
        public void ResetOneDefenseMod(CombatType p_combatType)
        {
            switch (p_combatType)
            {
                case CombatType.Physical:
                    this.__Defensives__.Physical = this.__BaseDefensives__.Physical;
                    break;
                case CombatType.Magical:
                    this.__Defensives__.Magical = this.__BaseDefensives__.Magical;
                    break;
                case CombatType.Psychological:
                    this.__Defensives__.Psychological = this.__BaseDefensives__.Psychological;
                    break;
                default: throw new ArgumentException("CombatType invalid!");
            }
        }
        public void ResetAllOffenseMod()
        {
            this.__Offensives__.Physical = this.__BaseOffensives__.Physical;
            this.__Offensives__.Magical = this.__BaseOffensives__.Magical;
            this.__Offensives__.Psychological = this.__BaseOffensives__.Psychological;
        }
        public void ResetOneOffenseMod(CombatType p_combatType)
        {
            switch (p_combatType)
            {
                case CombatType.Physical:
                    this.__Offensives__.Physical = this.__BaseOffensives__.Physical;
                    break;
                case CombatType.Magical:
                    this.__Offensives__.Magical = this.__BaseOffensives__.Magical;
                    break;
                case CombatType.Psychological:
                    this.__Offensives__.Psychological = this.__BaseOffensives__.Psychological;
                    break;
                default: throw new ArgumentException("CombatType invalid!");
            }
        }
    }
}