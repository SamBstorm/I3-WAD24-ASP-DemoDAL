using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Cocktail
    {

        public Guid Cocktail_Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string Instructions { get; private set; }
        public DateTime _createdAt;
        public DateOnly CreatedAt { get { return DateOnly.FromDateTime(_createdAt); } }
        private Guid? _createdBy;
        public Guid? CreatedBy { get { return Creator?.User_Id ?? _createdBy;  } }
        public User? Creator { get; private set; }

        private List<Comment> _comments;
        public Comment[] Comments
        {
            get { return _comments.ToArray(); }
        }

        public float? AvarageNote { get {  return _comments.Where(c => c.Note is not null).Select(c => (float?)c.Note).Average(); } }
        public Cocktail(string name, string? description, string instructions, DateTime createdAt) : this(Guid.NewGuid(), name, description, instructions, createdAt)
        { }

        public Cocktail(Guid cocktail_Id, string name, string? description, string instructions, DateTime createdAt)
        {
            Cocktail_Id = cocktail_Id;
            Name = name;
            Description = description;
            Instructions = instructions;
            _createdAt = createdAt;
            _comments = new List<Comment>();
        }

        public Cocktail(Guid cocktail_Id, string name, string? description, string instructions, DateTime createdAt, Guid? createdBy) : this(cocktail_Id, name,description,instructions,createdAt)
        {
            _createdBy = createdBy;
        }

        public Cocktail(Guid cocktail_Id, string name, string? description, string instructions, DateTime createdAt, User creator)
        {
            Creator = creator;
            if (Creator is not null) _createdBy = Creator.User_Id;
        }

        public void AddComment(Comment comment)
        {
            if(comment is null) throw new ArgumentNullException(nameof(comment));
            if (_comments.Contains(comment)) throw new ArgumentException("Ce commentaire a déjà été ajouté à ce cocktail.", nameof(comment));
            if (comment.Cocktail != this) throw new InvalidOperationException("Le commentaire n'appartient pas à ce cocktail");
            if (_comments.Select(c => c.Creator).Distinct().Contains(comment.Creator)) throw new InvalidOperationException("L'utilisateur ne peut commenter deux fois le même cocktail.");
            _comments.Add(comment);
        }

        public void AddComments(IEnumerable<Comment> comments)
        {
            if (comments is null) throw new ArgumentNullException(nameof(comments));
            foreach (Comment comment in comments)
            {
                AddComment(comment);
            }
        }

        public void SetCreator(User creator)
        {
            if (creator is null) throw new ArgumentNullException(nameof(creator));
            if (CreatedBy is null) throw new InvalidOperationException("Pas d'utilisateur à enregitrer.");
            if (CreatedBy != creator.User_Id) throw new InvalidOperationException("Mauvais utilisateur");
            Creator = creator;
        }

    }
}
