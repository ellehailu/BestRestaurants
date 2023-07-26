Notes

- Create a website where users can add their favorite restaurants based on the type of cuisine they offer.

- Add a Cuisine class. Build out all CRUD functionality (Create, Read, Update, Delete) for this class. Remember that "Read" means to view a particular cuisine and to list out all of the cuisines.

- Add a Restaurant class. Build out all CRUD functionality for this class.

- Add properties other than name to your Restaurant class so that you can display descriptive information about the restaurants.

- Make the connection between a cuisine and a restaurant in the database. A cuisine can have many restaurants, but a restaurant can only be attached to one cuisine.

- Allow a user to search for all of a cuisine's restaurants.




### Instructions
- in your project folder open terminal and run commands 
    - $ dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0
    - $ dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0