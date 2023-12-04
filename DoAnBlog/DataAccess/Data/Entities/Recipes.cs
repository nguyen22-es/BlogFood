using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    internal class Recipes
    {
    public  string RecipeID { get; set; }

    public string PostID { get; set; }
    public string  Ingredients { get; set; }

    public string Instructions { get; set; }

    public virtual Post? Post { get; set; }


    }
}


/*
 * CREATE TABLE Recipes (
    RecipeID INT PRIMARY KEY AUTO_INCREMENT,
    FoodID INT,
    Ingredients TEXT,
    Instructions TEXT,
    FOREIGN KEY (FoodID) REFERENCES Foods(FoodID)
);
 * */