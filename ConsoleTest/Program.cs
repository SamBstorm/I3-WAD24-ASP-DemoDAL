using BLL.Entities;
using BLL.Services;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*CocktailService service = new CocktailService();
            foreach (Cocktail c in service.Get())
            {
                Console.WriteLine($"{c.Cocktail_Id} : {c.Name}\nCréé le : {c.CreatedAt.ToShortDateString()}\n{c.Description}\n{c.Instructions}");
            }*/

            User u1 = new User("Samuel", "Legrain", "samuel.legrain@bstorm.be");

            u1.CreateCocktail("Pisang sans alcool", "Boisson rafraichissante", "1. Versez un cinquième de pisang sans alcool.\n2. Ajoutez des glaçons.\n3. Remplissez le reste avec du jus d'orange avec pulpe.");

            User u2 = new User("Michael", "Person", "michael.person@bstorm.be");
            u2.WriteComment(u1.Cocktails[0], "Trop bon!", "Rafraichissant!", 5);

            Console.ReadLine();
        }
    }
}
