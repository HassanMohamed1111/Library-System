using Quiz_2.DTO;

namespace Quiz_2.Repository_Pattern
{
    public interface IRepositoryAuthor
    {
        public void AddAuthor(AddAuthorDto dto);
        public void AddAllDataFromAuthor(AuthorandBookDto dto);
        public void AddAuthorToJoinTable(int authorId, int bookId);
        public List<AuthorandBookDto> GetAllDataFromAuthor();
        public AuthorandBookDto GetAuthorById(int authorId);
        public void DeleteAuthorById(int Authorid);
        public void UpdateAuthor(UpdateAuthorWithBookDto dto, int Authorid);
    }
}
