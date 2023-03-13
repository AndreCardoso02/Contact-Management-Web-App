using AutoMapper;
using Contact_Management_Web_App.IServices;
using Contact_Management_Web_App.ViewModels;

namespace Contact_Management_Web_App.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(ContactViewModel viewModel)
        {
            var contact = _mapper.Map<Contact>(viewModel);

            if (contact == null) return;

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactViewModel>> GetAll()
        {
            var result = await _context.Contacts.ToListAsync();
            return _mapper.Map<IEnumerable<ContactViewModel>>(result);
        }

        public async Task Delete(int contactId)
        {
            var contact = await _context.Contacts.FirstAsync(cont => cont.Id == contactId);
            if (contact == null) return;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<ContactViewModel> GetById(int contactId)
        {
            var result = await _context.Contacts.Where(contact => contact.Id == contactId).FirstOrDefaultAsync();
            return _mapper.Map<ContactViewModel>(result);            
        }

        public async Task Update(ContactViewModel viewModel)
        {
            var contact = _mapper.Map<Contact>(viewModel);
            if (contact == null) return;

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }
    }
}
