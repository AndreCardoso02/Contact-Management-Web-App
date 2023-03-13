using Contact_Management_Web_App.ViewModels;

namespace Contact_Management_Web_App.IServices
{
    public interface IContactService
    {
        Task<IEnumerable<ContactViewModel>> GetAll();
        Task<ContactViewModel> GetById(int contactId);
        Task Add(ContactViewModel viewModel);
        Task Update(ContactViewModel viewModel);
        Task Delete(int contactId);
    }
}
