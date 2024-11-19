using Quiz_2.DTO;

namespace Quiz_2.Repository_Pattern.GenreRepository
{
    public interface IRepositoryGenre
    {
        public void AddGenre(GenreDto dto);
        public List<GenreDto> GetAllGenre();
        public GenreDto GetById(int id);
        public void UpdateGenreById(GenreDto dto ,int genreId);
        public void DeleteGenreById(int id);

    }
}
