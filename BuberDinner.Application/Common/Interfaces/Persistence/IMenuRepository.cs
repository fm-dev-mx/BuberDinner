using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

// Interface for Menu repository to handle data operations related to Menu.
// This interface defines the contract for menu data access operations.
public interface IMenuRepository
{
    // Method to add a new Menu to the repository.
    // This will be implemented to persist a Menu entity in the data store.
    void Add(Menu menu);
}