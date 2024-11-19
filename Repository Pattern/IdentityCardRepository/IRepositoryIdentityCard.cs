using Quiz_2.DTO;

namespace Quiz_2.Repository_Pattern.IdentityCardRepository
{
    public interface IRepositoryIdentityCard
    {
        public void AddIdentityCard(IdentityCardDto dto);
        public List<IdentityCardDto> GetIdentityCard();
        public IdentityCardDto GetIdentityCardById(int IdentityId);
        public void UpdateIdentityCard(IdentityCardDto dto, int IdentityId);
        public void DeleteIdentityCard(int IdentityId);
    }
}
