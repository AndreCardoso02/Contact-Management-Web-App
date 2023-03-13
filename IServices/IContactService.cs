using Contact_Management_Web_App.ViewModels;

namespace Contact_Management_Web_App.IServices
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetById(int contactId);
        Task Add(CreateUpdateContactViewModel viewModel);
        Task Update(CreateUpdateContactViewModel viewModel);
        Task Delete(int contactId);
    }
}
