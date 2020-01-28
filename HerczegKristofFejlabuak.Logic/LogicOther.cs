namespace HerczegKristofFejlabuak.Logic
{
    using System;
    using System.Linq;
    using HerczegKristofFejlabuak.Data;
    using HerczegKristofFejlabuak.Repository;

    /// <summary>
    /// Contains other Logic methods.
    /// </summary>
    public class LogicOther
    {
        private Logic<species> _speciesLogic;
        private Logic<classification> _classificationLogic;
        private Logic<subclass> _subclassLogic;
        private IRepository<species> isprepo;
        private IRepository<classification> icrepo;
        private IRepository<subclass> isubrepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicOther"/> class.
        /// Generate a standard logic other.
        /// </summary>
        public LogicOther()
        {
            this._classificationLogic = new Logic<classification>();
            this._speciesLogic = new Logic<species>();
            this._subclassLogic = new Logic<subclass>();
            this.isprepo = new Repository<species>();
            this.icrepo = new Repository<classification>();
            this.isubrepo = new Repository<subclass>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicOther"/> class.
        /// Contains other Logic methods.
        /// </summary>
        /// <param name="sub">Entity of Generic Logic for subclass.</param>
        /// <param name="sp">Entity of Generic Logic for specie.</param>
        /// <param name="cl">Entity of Generic Logic for classification.</param>
        public LogicOther(IRepository<subclass> sub, IRepository<species> sp, IRepository<classification> cl)
        {
            this._classificationLogic = new Logic<classification>();
            this._speciesLogic = new Logic<species>();
            this._subclassLogic = new Logic<subclass>();
            this.isprepo = sp;
            this.icrepo = cl;
            this.isubrepo = sub;
        }

        /// <summary>
        /// return all classification for given specie.
        /// </summary>
        /// <param name="name">chosen specie.</param>
        /// <returns>In formed string.</returns>
        public string BranchWriteout(string name)
        {
            return this.isprepo.Short(name);
        }

        /// <summary>
        /// All subclass and the count of species under.
        /// </summary>
        /// <returns>In formed string.</returns>
        public string SpeciesUnderSubClassCount()
        {
            return this.isprepo.GroupSpecies();
        }

        /// <summary>
        /// íReturns all family and the species count under.
        /// </summary>
        /// <returns>In formed string.</returns>
        public string FamilyCount()
        {
            return this.isprepo.Group();
        }

        /// <summary>
        /// Write out all speciel characteristics.
        /// </summary>
        /// <param name="name">name of the specie</param>
        /// <returns>In string.</returns>
        public string SpecialStatWriteOut(string name)
        {
            var lvl1 = this._speciesLogic.ReadOne(name);
            var lvl2 = this._classificationLogic.ReadOne(lvl1.genus_name);
            if (lvl2 != null)
            {
                var lvl3 = this._subclassLogic.ReadOne(lvl2.subclass_name);
                if (lvl3 != null)
                {

                    string kimenet = string.Empty;
                    kimenet = $"Name: {lvl1.species_name}  Avarage size: {lvl1.atlagos_meret}  Max size: {lvl1.legnagyobb_meret} External Shell: {this.BitConvert((byte)lvl3.external_shell)} Cute: { this.BitConvert((byte)lvl1.cute)} Cthulhu Approvved: {this.BitConvert((byte)lvl2.cthulh_aproved)}";
                    return kimenet;
                }
            }

            return "nincs teljes háló";
        }

        public string GroupSpecies()
        {
            try
            {
                var q1 = from species in this.isprepo.GetAll().AsQueryable()
                         join classification in this.icrepo.GetAll().AsQueryable() on species.genus_name equals classification.genus_name
                         join subclass in this.isubrepo.GetAll().AsQueryable() on classification.subclass_name equals subclass.subclass_name
                         group species by subclass.subclass_name into c
                         select new { c.Key, v = c.Count() };
                string s = string.Empty;
                foreach (var item in q1)
                {
                    s += "Subclass: " + item.Key + " Number of species under: " + item.v + "\n";
                }

                return s;
            }
            catch (Exception E)
            {
                return "Nincs teljes ág";
            }

        }
        private double LenghtConverter(string lengt)
        {
            string seged = string.Empty;
            if (lengt[lengt.Length-2].ToString().ToLower() == "m")
            {
               return 0.001 * int.Parse(lengt.Substring(0, lengt.Length - 3).TrimEnd(' '));
            }
            if (lengt[lengt.Length-2].ToString().ToLower() == "c")
            {
                return 0.01 * int.Parse(lengt.Substring(0, lengt.Length - 3).TrimEnd(' '));
            }
            if (lengt[lengt.Length - 2].ToString().ToLower() == "d")
            {
                return 0.1 * int.Parse(lengt.Substring(0, lengt.Length - 3).TrimEnd(' '));
            }
            else
            {
                return (double) int.Parse(lengt.Substring(0, lengt.Length - 2).TrimEnd(' '));
            }

        }

        private bool BitConvert(byte num)
        {
            if (num == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
