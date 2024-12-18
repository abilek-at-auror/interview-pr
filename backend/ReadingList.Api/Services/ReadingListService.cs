using System.Collections.Generic;
using System.Linq;
using ReadingListApi.Models;

namespace ReadingListApi.Services
{
    public class ReadingListService
    {
        private readonly List<ReadingItem> _readingList;

        public ReadingListService()
        {
            // Initialize with a few sample items for simplicity
            _readingList = new List<ReadingItem>
            {
                new ReadingItem { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Dystopian", IsRead = false },
                new ReadingItem { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", IsRead = true },
                new ReadingItem { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic", IsRead = false }
            };
        }

        // Retrieve all items in the reading list
        public IEnumerable<ReadingItem> GetAllItems()
        {
            return _readingList;
        }

        // Retrieve a single item by ID
        public ReadingItem? GetItemById(int id)
        {
            return _readingList.FirstOrDefault(item => item.Id == id);
        }

        // Add a new reading item to the list
        public ReadingItem AddItem(ReadingItem newItem)
        {
            newItem.Id = _readingList.Any() ? _readingList.Max(item => item.Id) + 1 : 1; // Auto-increment ID
            _readingList.Add(newItem);
            return newItem;
        }

        // Update an existing item
        public bool UpdateItem(int id, ReadingItem updatedItem)
        {
            var existingItem = _readingList.FirstOrDefault(item => item.Id == id);
            if (existingItem == null) return false;

            existingItem.Title = updatedItem.Title;
            existingItem.Author = updatedItem.Author;
            existingItem.Genre = updatedItem.Genre;
            existingItem.IsRead = updatedItem.IsRead;

            return true;
        }

        // Delete an item by ID
        public bool DeleteItem(int id)
        {
            var itemToRemove = _readingList.FirstOrDefault(item => item.Id == id);
            if (itemToRemove == null) return false;

            _readingList.Remove(itemToRemove);
            return true;
        }

        public void ShareReadingList(int listId, string email)
        {
            Console.WriteLine($"Sharing reading list {listId} with {email}");
            // TODO: Implement email sharing functionality
        }
    }
}