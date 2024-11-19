using Quiz_2.DTO;

namespace Quiz_2.Repository_Pattern.CreditCardRepository
{
    public interface IRepositoryCreditCard
    {
        public void AddCreditCard(CreditCardDto dto);
        public List<CreditCardDto> GetAllCreditCard();
        public CreditCardDto GetCreditCardById(int CreditId);
        public void UpdateCreditCard(CreditCardDto dto, int CreditId);
        public void DeleteCreditCard(int CreditId);
    }
}
