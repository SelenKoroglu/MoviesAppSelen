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
            if (_db.Movies.Any(m => m.Name.ToUpper() == record.Name.ToUpper().Trim() &&  m.ReleaseDate== record.ReleaseDate))
                return Error("Movie with the same name and release date exists!");
            record.Name = record.Name?.Trim();
            _db.Movies.Add(record);
            _db.SaveChanges();
            return Success("Movie created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Movies.SingleOrDefault(m => m.Id == id);
            if (entity == null)
                return Error("Movie can't be found!");
            //_db.MoviesGenres.RemoveRange(entity.MovieGenres);
            _db.Movies.Remove(entity);
            _db.SaveChanges();
            return Success("Movie deleted successfully.");
        }

        public IQueryable<MovieModel> Query()
        {
            return _db.Movies.Include(m => m.Director).OrderByDescending(m => m.ReleaseDate).ThenBy(m => m.Name).Select(m => new MovieModel() { Record = m });
        }

        public ServiceBase Update(Movie record)
        {

            if (_db.Movies.Any(m => m.Id != record.Id &&  m.Name.ToUpper() == record.Name.ToUpper().Trim() && m.ReleaseDate == record.ReleaseDate))
                return Error("Movie with the same name and release date exists!");
            record.Name = record.Name?.Trim();
            _db.Movies.Update(record);
            _db.SaveChanges();
            return Success("Movie updated successfully.");
        }
    
    }
}
