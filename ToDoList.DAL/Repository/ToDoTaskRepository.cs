using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Data;
using ToDoList.DAL.Entity;
using ToDoList.DAL.Repository.Interfaces;

namespace ToDoList.DAL.Repository
{
    public class ToDoTaskRepository : Repository<ToDoTask>, IToDoTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoTaskRepository([FromServices]ApplicationDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
