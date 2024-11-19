using Quiz_2.DTO;
using Quiz_2.Models;

namespace Quiz_2.Repository_Pattern.GenreRepository
{
    public class RepositoryGenre:IRepositoryGenre
    {
        private readonly AppDbContext _context;
        public RepositoryGenre(AppDbContext context)
        {
            _context = context;
        }

        public void AddGenre(GenreDto dto)
        {
            bool existingGenre = _context.genres.Any(x=>x.Name == dto.Name);
            if(existingGenre)
            {
                throw new Exception("Genre Already Added");
            }
            Genre genre = new Genre
            {
                Name = dto.Name,
            };
            _context.genres.Add(genre);
            _context.SaveChanges();
        }

        public List<GenreDto> GetAllGenre()
        {
            var res = _context.genres.Select(x=>new GenreDto
            {
                Name = x.Name,
            }).ToList();
            return res;
        }

        public GenreDto GetById(int id)
        {
            var res = _context.genres.FirstOrDefault(x=>x.GenreId == id);
            if(res == null)
            {
                return null;
            }
            return new GenreDto
            {
               Name = res.Name,
            };
        }

        public void UpdateGenreById(GenreDto dto, int genreId)
        {
            var res = _context.genres.FirstOrDefault(x=>x.GenreId ==  genreId); 
            if(res != null)
            {
               res.Name = dto.Name;
            }
            _context.genres.Update(res);
            _context.SaveChanges();
        }

        public void DeleteGenreById(int id)
        {
            var res = _context.genres.FirstOrDefault(x=>x.GenreId==id);
            if(res!= null)
            {
                _context.genres.Remove(res);
                _context.SaveChanges();
            }
        }
    }
}
