using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence;

// Concrete implementation of IMenuRepository for managing menu data.
// This class provides methods to interact with the underlying data storage for menus.
public class MenuRepository : IMenuRepository
{
    // In-memory list to store Menu entities. This simulates a database for simplicity.
    private static readonly List<Menu> _menus = new();

    // Adds a new Menu to the in-memory list.
    // This method is called to persist a menu entity when a new menu is created.
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}