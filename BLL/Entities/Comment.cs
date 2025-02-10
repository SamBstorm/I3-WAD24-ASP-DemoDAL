using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Comment
    {

        public Guid Comment_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        private Guid _concern;
        public Guid Concern { get { return Cocktail?.Cocktail_Id ?? _concern; } }
        public Cocktail? Cocktail { get; private set; }
        private Guid? _createdBy;
        public Guid? CreatedBy { get { return Creator?.User_Id ?? _createdBy; } }
        public User? Creator { get; private set; }
        public DateTime CreatedAt { get; set; }
        public int? Note { get; set; }
        public Comment(Guid comment_Id, string title, string content, Cocktail cocktail, User? creator, DateTime createdAt, int? note)
        {
            Comment_Id = comment_Id;
            Title = title;
            Content = content;
            Cocktail = cocktail;
            Creator = creator;
            Note = note;
        }

        public Comment(string title, string content, Cocktail cocktail, User? creator, int? note) : this (Guid.NewGuid(), title, content, cocktail, creator, DateTime.Now, note)
        { }

        public Comment(Guid comment_Id, string title, string content, Guid concern, Guid? createdBy, DateTime createdAt, int? note)
        {
            Comment_Id = comment_Id;
            Title = title;
            Content = content;
            _concern = concern;
            _createdBy = createdBy;
            CreatedAt = createdAt; 
            Note = note;
        }

        public Comment(string title, string content, Guid concern, Guid? createdBy, int? note) : this(Guid.NewGuid(), title, content, concern, createdBy, DateTime.Now, note)
        { }
        
        public void SetCreator(User creator)
        {
            if (creator is null) throw new ArgumentNullException(nameof(creator));
            if (CreatedBy is null) throw new InvalidOperationException("Pas d'utilisateur à enregitrer.");
            if (CreatedBy != creator.User_Id) throw new InvalidOperationException("Mauvais utilisateur");
            Creator = creator;
        }

        public void SetCocktail(Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            if (Concern != cocktail.Cocktail_Id) throw new InvalidOperationException("Mauvais Cocktail");
            Cocktail = cocktail;
        }
    }
}
