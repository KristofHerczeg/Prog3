// <copyright file="ILogic{T}.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HerczegKristofFejlabuak.Logic
{
    using System.Linq;
    using HerczegKristofFejlabuak.Data;
    using HerczegKristofFejlabuak.Repository;

    /// <summary>
    /// Interface for logic.
    /// </summary>
    /// <typeparam name="T"> T is classes of db tables.</typeparam>
    public interface ILogic<T>
    {
        /// <summary>
        /// Create in db.
        /// </summary>
        /// <param name="entity">Db entity.</param>
        void Create(T entity);

        /// <summary>
        /// ReadOne. Get The chosen object from db.
        /// </summary>
        /// <param name="name">The key.</param>
        /// <returns>The chosen object from db.</returns>
        T ReadOne(string name);

        /// <summary>
        /// Gets all data in table.
        /// </summary>
        /// <returns>IQuerryable table data.</returns>
        IQueryable GetAll();

        /// <summary>
        /// Update. Update the parameters of the choosen object in the db.
        /// </summary>
        /// <param name="entity">The object, with the updated parameters.</param>
        /// <param name="name">Key.</param>
        void Update(T entity, string name);

        /// <summary>
        /// Delete the choosen object from db.
        /// </summary>
        /// <param name="name">Key.</param>
        void Delete(string name);
    }

    /// <summary>
    /// Valami.
    /// </summary>
    /// <typeparam name="T">DBENtities table type.</typeparam>
    public class Logic<T> : ILogic<T>
        where T : class
    {
        private readonly IRepository<T> repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic{T}"/> class.
        /// </summary>
        public Logic()
        {
            this.repo = new Repository<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic{T}"/> class.
        /// </summary>
        /// <param name="repository">For mock.</param>
        public Logic(IRepository<T> repository)
        {
            this.repo = repository;
        }

        /// <inheritdoc/>
        public void Create(T entity)
        {
            this.repo.Create(entity);
        }

        /// <inheritdoc/>
        public void Delete(string name)
        {
            this.repo.Delete(name);
        }

        /// <inheritdoc/>
        public T ReadOne(string name)
        {
           return this.repo.GetOne(name);
        }

        /// <inheritdoc/>
        public IQueryable GetAll()
        {
            return this.repo.GetAll().AsQueryable();
        }


        /// <inheritdoc/>
        public void Update(T entity, string name)
        {
            this.repo.Update(name, entity);
        }
    }
}
