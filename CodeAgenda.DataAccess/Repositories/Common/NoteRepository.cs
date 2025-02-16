using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.DataAccess.Repositories
{
    public class NoteRepository
        : RepositoryBase, INoteRepository
    {

        public NoteRepository(ApplicationContext context) : base(context)
        {
        }
        public void Add(Note Note)
        {
            _context.Note.Add(Note);
        }

        Note? INoteRepository.GetById(Guid id)
        {
            var note = _context.Note.FirstOrDefault(x => x.Id == id);
            if (note == null)
            {
                throw new Exception("Note not found");
            }
            return note;
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Note.ToList();
        }

        public void Update(Note Note)
        {
            _context.Note.Update(Note);
        }

        public void Delete(Note Note)
        {
            _context.Note.Remove(Note);
        }
    }
}
