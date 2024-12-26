using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MovieService : ServiceBase, IService<Movie, MovieModel>
    {
        public MovieService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Movie record)
        {
            if (_db.Movies.Any(m => m.Name.ToUpper() == record.Name.ToUpper().Trim() &&  m.ReleaseDate== record.ReleaseDate && m.DirectorId == record.DirectorId))
                return Error("Movie with the same name, director and release date exists!");
            record.Name = record.Name?.Trim();
            record.DirectorId = record.DirectorId;
            record.ReleaseDate = record.ReleaseDate;
            record.TotalRevenue = record.TotalRevenue;
            record.Director = record.Director;
            _db.Movies.Add(record);
            _db.SaveChanges();
            return Success("Movie created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Movies.SingleOrDefault(m => m.Id == id);
            if (entity == null)
                return Error("Movie can't be found!");
           
            _db.MoviesGenres.RemoveRange(entity.MovieGenres);
            _db.Movies.Remove(entity);
            _db.SaveChanges();
            return Success("Movie deleted successfully.");
        }

        public IQueryable<MovieModel> Query()
        {
            return _db.Movies.Include(m => m.Director).Include(m=>m.MovieGenres).ThenInclude(mg=>mg.Genre).OrderByDescending(m => m.ReleaseDate).ThenBy(m => m.Name).Select(m => new MovieModel() { Record = m });
        }

        public ServiceBase Update(Movie record)
        {
            if (_db.Movies.Any(m => m.Id != record.Id && m.Name.ToUpper() == record.Name.ToUpper().Trim() && m.ReleaseDate == record.ReleaseDate))
                return Error("Movie with the same name and release date exists!");

            var entity = _db.Movies.Include(m=>m.MovieGenres).SingleOrDefault(m => m.Id == record.Id);
            if (entity == null)
                return Error("Movie can't be found!");
            _db.MoviesGenres.RemoveRange(entity.MovieGenres);
            entity.Name = record.Name?.Trim();
            entity.ReleaseDate = record.ReleaseDate;
            entity.DirectorId = record.DirectorId;
            entity.Director = record.Director;
            entity.TotalRevenue = record.TotalRevenue;
            entity.MovieGenres = record.MovieGenres;
      
            _db.Movies.Update(entity);
            _db.SaveChanges();
            return Success("Movie updated successfully.");
        }
    }
}
