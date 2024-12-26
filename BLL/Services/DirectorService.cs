using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IDirectorService
    {
        public IQueryable<DirectorModel> Query();
        
        public ServiceBase Create(Director record);
        public ServiceBase Update(Director record);
        public ServiceBase Delete(int id);


    }
    public class DirectorService : ServiceBase, IDirectorService
    {
        public DirectorService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Director record)
        {
            if (_db.Directors.Any(d => d.Name.ToUpper() == record.Name.ToUpper().Trim() && d.Surname.ToUpper() == record.Surname.ToUpper().Trim() && d.IsRetired == record.IsRetired))
                return Error("Director with the same name, surname and working status exists!");
            record.Name= record.Name?.Trim();
            record.Surname = record.Surname.Trim();
            record.IsRetired = record.IsRetired;
            _db.Directors.Add(record);
            _db.SaveChanges();
            return Success("Director created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Directors.Include(d=> d.Movies).SingleOrDefault(d => d.Id == id);
            if (entity is null)
                return Error("Director can't be found!");
            if (entity.Movies.Any())
                return Error("Director has relational movies!");
            _db.Directors.Remove(entity);
            _db.SaveChanges();
            return Success("Director deleted successfully");

        }

        public IQueryable<DirectorModel> Query()
        {
            return _db.Directors.OrderBy(d => d.Name).Select(d => new DirectorModel() { Record = d });
        }

        public ServiceBase Update(Director record)
        {
            if (_db.Directors.Any(d=> d.Id != record.Id && d.Name.ToUpper() == record.Name.ToUpper().Trim() && d.Surname.ToUpper() == record.Surname.ToUpper().Trim()))
                return Error("Director with the same name and surname exists!");
            var entity = _db.Directors.SingleOrDefault(d=> d.Id == record.Id);
            if (entity == null)
                return Error("Director can't be found!");
            entity.Name = record.Name?.Trim();
            entity.Surname = record.Surname.Trim();
            entity.IsRetired = record.IsRetired;
            _db.Directors.Update(entity);
            _db.SaveChanges();
            return Success("Director updated successfully.");
        }
    }
}
