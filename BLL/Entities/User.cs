using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public enum UserRole { User, Admin }
    public class User
    {
        public Guid User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        private DateTime? _disabledAt;

        //public DateTime? DisabledAt { get { return _disabledAt; } }

        public UserRole Role { get; set; }

        private List<Comment> _comments;
        public Comment[] Comments
        {
            get { return _comments.ToArray(); }
        }

        public bool IsDisabled
        {
            get { return _disabledAt is not null; }
        }

        private List<Cocktail> _cocktails;
        public Cocktail[] Cocktails { get { return _cocktails.ToArray(); } }

        public User(Guid user_Id, string first_Name, string last_Name, string email, string password, DateTime createdAt, DateTime? disabledAt, string role) : this(first_Name, last_Name, email, password)
        {
            User_Id = user_Id;
            CreatedAt = createdAt;
            _disabledAt = disabledAt;
            Role = Enum.Parse<UserRole>(role);
        }

        public User(string first_Name, string last_Name, string email, string password) : this(first_Name, last_Name, email)
        {
            Password = password;
        }

        public User(string first_Name, string last_Name, string email) {
            First_Name = first_Name;
            Last_Name = last_Name;
            Email = email;
            _cocktails = new List<Cocktail>();
            _comments = new List<Comment>();
        }

        public void CreateCocktail(string name, string? description, string instructions)
        {
            Cocktail cocktail = new Cocktail(Guid.NewGuid(), name, description, instructions, DateTime.Now, this);
            _cocktails.Add(cocktail);
        }


        public void SetCocktails(IEnumerable<Cocktail> cocktails)
        {
            if (cocktails is null || cocktails.Contains(null)) throw new ArgumentNullException(nameof(cocktails));
            if (cocktails.Select(c => c.CreatedBy).Distinct().SingleOrDefault() != User_Id) throw new InvalidOperationException("Ces cocktails ne sont pas de cet utilisateur.");
            _cocktails = new List<Cocktail>(cocktails);
        }

        public void WriteComment(Cocktail cocktail, string title, string content, int? note)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            if (_cocktails.Contains(cocktail) || cocktail.CreatedBy == User_Id) throw new InvalidOperationException("Vous ne pouvez pas commenter vos propres cocktails.");
            if(note is not null && (note < 0 || note > 5)) throw new ArgumentOutOfRangeException("Votre note doit être comprise entre 0 et 5.",nameof(note));
            Comment comment = new Comment(title,content,cocktail, this, note);
            cocktail.AddComment(comment);
            _comments.Add(comment);
        }

        public void SetComments(IEnumerable<Comment> comments)
        {
            if (comments is null || comments.Contains(null)) throw new ArgumentNullException(nameof(comments));
            if (comments.Select(c => c.CreatedBy).Distinct().SingleOrDefault() != User_Id) throw new InvalidOperationException("Ces commentaires ne sont pas de cet utilisateur.");
            _comments = new List<Comment>(comments);
        }
    }
}
