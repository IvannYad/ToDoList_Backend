﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Data;
using ToDoList.DAL.Repository.Interfaces;

namespace ToDoList.DAL.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private DbSet<T> _dbSet { get; set; }
        public Repository(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public T? Get(Expression<Func<T, bool>> selector, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
                query = query.AsNoTracking();

            return query.FirstOrDefault(selector);
        }

        public IEnumerable<T>? GetAll(Expression<Func<T, bool>>? filter = null)
        {
            var query = _dbSet.AsNoTracking();
            if (filter is not null)
                query = query.Where(filter);

            return query;
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
