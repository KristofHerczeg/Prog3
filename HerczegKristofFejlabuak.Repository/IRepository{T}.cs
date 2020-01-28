// <copyright file="IRepository{T}.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HerczegKristofFejlabuak.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HerczegKristofFejlabuak.Data;

    /// <summary>
    /// IRepo interface, wich is implemented by Generic repo class, crud and linq methods.
    /// </summary>
    /// <typeparam name="T">is class of db. </typeparam>
    public interface IRepository<T>
           where T : class
    {
        /// <summary>
        /// Create. Insert an object into databese, where the object is a class of the db.
        /// </summary>
        /// <param name="entity">The insertable object: specie, classification, sub_class. </param>
        void Create(T entity);

        /// <summary>
        /// ReadOne. Get The chosen object from db.
        /// </summary>
        /// <param name="name">The key.</param>
        /// <returns>The chosen object from db.</returns>
        T GetOne(string name);

        /// <summary>
        /// Update. Update the parameters of the choosen object in the db.
        /// </summary>
        /// <param name="name">Key.</param>
        /// <param name="entity">The object, with the updated parameters.</param>
        void Update(string name, T entity);

        /// <summary>
        /// Delete the choosen object from db.
        /// </summary>
        /// <param name="name">Key.</param>
        void Delete(string name);

        /// <summary>
        /// Gets all classification data fro specie.
        /// </summary>
        /// <returns>Formed string.</returns>
        string Group();

        /// <summary>
        /// Gets all classification data fro specie.
        /// </summary>
        /// <param name="name">Key.</param>
        /// <returns>Formed string.</returns>
        string Short(string name);

        /// <summary>
        /// Gets all classification data fro specie.
        /// </summary>
        /// <param name="name">The key.</param>
        /// <returns>Formed string.</returns>
        string GroupSpecies();

        /// <summary>
        /// Gets all data in table.
        /// </summary>
        /// <returns>IQuerryable table data.</returns>
        IQueryable<T> GetAll();
    }

    /// <summary>
    /// Gets data from db and gives it to Logic.
    /// </summary>
    /// <typeparam name="T">Type of class DbEntitis table type.</typeparam>
    public class Repository<T> : IRepository<T>
             where T : class
    {
        private DBEntities dB = new DBEntities();

        /// <inheritdoc/>
        public void Create(T entity)
        {
                this.dB.Set<T>().Add(entity);
                this.dB.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(string name)
        {
                this.dB.Set<T>().Remove(this.GetOne(name));
                this.dB.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
                var a = this.dB.Set<T>().AsQueryable();
                return a;
        }

        /// <inheritdoc/>
        public T GetOne(string name)
        {
            return this.dB.Set<T>().Find(name);
        }

        /// <inheritdoc/>
        public void Update(string name, T entity)
        {
                T modositando = this.GetOne(name);
                this.dB.Entry(modositando).CurrentValues.SetValues(entity);
                this.dB.SaveChanges();
        }

        /// <inheritdoc/>
        public string Short(string input)
        {
            try
            {
                var q1 = from species in this.dB.species
                         join classification in this.dB.classification on species.genus_name equals classification.genus_name
                         join subclass in this.dB.subclass on classification.subclass_name equals subclass.subclass_name
                         where species.species_name == input
                         select new { species.species_name, classification.genus_name, classification.order_, classification.family, subclass.subclass_name, };

                string s = "Subclass: " + q1.FirstOrDefault().subclass_name + " Family: " + q1.FirstOrDefault().family + " Order: " + q1.FirstOrDefault().order_ + " Specie: " + q1.FirstOrDefault().species_name;
                return s;
            }
            catch (Exception)
            {
                return "Nincs teljes ág";
            }
        }

        /// <inheritdoc/>
        public string Group()
        {
            try
            {
                var q1 = from species in this.dB.species
                         join classification in this.dB.classification on species.genus_name equals classification.genus_name
                         group species by classification.family into g
                         select new { g.Key, V = g.Count() };
                string s = string.Empty;
                foreach (var item in q1)
                {
                    s += "Family: " + item.Key + " Number of species under: " + item.V + "\n";
                }

                return s;
            }
            catch (Exception)
            {

                return "Nincs teljes ág";
            }
        }

        /// <inheritdoc/>
        public string GroupSpecies()
        {
            try
            {
                var q1 = from species in this.dB.species
                         join classification in this.dB.classification on species.genus_name equals classification.genus_name
                         join subclass in this.dB.subclass on classification.subclass_name equals subclass.subclass_name
                         group species by subclass.subclass_name into c
                         select new { c.Key, v = c.Count() };
                string s = string.Empty;
                foreach (var item in q1)
                {
                    s += "Subclass: " + item.Key + " Number of species under: " + item.v + "\n";
                }

                return s;
            }
            catch (Exception)
            {
                return "Nincs teljes ág";
            }
        }
    }
}
