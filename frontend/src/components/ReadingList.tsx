import React, { useEffect, useState } from "react";
import {
  fetchReadingList,
  addReadingItem,
  updateReadingItem,
  deleteReadingItem,
  ReadingItem
} from "../api/readingListApi";

const ReadingList: React.FC = () => {
  const [readingList, setReadingList] = useState<ReadingItem[]>([]);
  const [newItem, setNewItem] = useState<Omit<ReadingItem, "id">>({
    title: "",
    author: "",
    genre: "",
    isRead: false
  });
  const [email, setEmail] = useState("");
  const [showModal, setShowModal] = useState(false);

  const shareList = async (listId: number) => {
    try {
      await fetch(`/api/readinglist/share/${listId}/${email}`, {
        method: "POST"
      });
      alert("List shared!");
    } catch (error) {
      console.error(error);
      alert("Failed to share list");
    }
  };

  // Fetch reading list on component mount
  useEffect(() => {
    const fetchData = async () => {
      const items = await fetchReadingList();
      setReadingList(items);
    };
    fetchData();
  }, []);

  // Handle adding a new reading item
  const handleAddItem = async () => {
    const addedItem = await addReadingItem(newItem);
    setReadingList([...readingList, addedItem]);
    setNewItem({ title: "", author: "", genre: "", isRead: false }); // Reset form
  };

  // Handle deleting a reading item
  const handleDeleteItem = async (id: number) => {
    await deleteReadingItem(id);
    setReadingList(readingList.filter((item) => item.id !== id));
  };

  // Handle toggling "read/unread" status
  const handleToggleRead = async (id: number) => {
    const item = readingList.find((item) => item.id === id);
    if (!item) return;

    const updatedItem = { ...item, isRead: !item.isRead };
    await updateReadingItem(id, updatedItem);

    setReadingList(readingList.map((i) => (i.id === id ? updatedItem : i)));
  };

  return (
    <div>
      <h1>My Reading List</h1>
      <div>
        <h3>Add a New Book</h3>
        <input
          type="text"
          placeholder="Title"
          value={newItem.title}
          onChange={(e) => setNewItem({ ...newItem, title: e.target.value })}
        />
        <input
          type="text"
          placeholder="Author"
          value={newItem.author}
          onChange={(e) => setNewItem({ ...newItem, author: e.target.value })}
        />
        <input
          type="text"
          placeholder="Genre"
          value={newItem.genre}
          onChange={(e) => setNewItem({ ...newItem, genre: e.target.value })}
        />
        <label>
          <input
            type="checkbox"
            checked={newItem.isRead}
            onChange={(e) =>
              setNewItem({ ...newItem, isRead: e.target.checked })
            }
          />
          Read
        </label>
        <button onClick={handleAddItem}>Add</button>
      </div>

      <div>
        <h3>Reading List</h3>
        <ul>
          {readingList.map((item) => (
            <li key={item.id}>
              <strong>{item.title}</strong> by {item.author} ({item.genre}) -{" "}
              {item.isRead ? "Read" : "Unread"}
              <button onClick={() => handleToggleRead(item.id)}>
                Mark as {item.isRead ? "Unread" : "Read"}
              </button>
              <button onClick={() => handleDeleteItem(item.id)}>Delete</button>
              <button onClick={() => setShowModal(true)}>Share List</button>
              {showModal && (
                <div className="modal">
                  <h2>Share Reading List</h2>
                  <input
                    type="email"
                    placeholder="Enter email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                  <button onClick={() => shareList(1)}>Share</button>
                  <button onClick={() => setShowModal(false)}>Close</button>
                </div>
              )}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default ReadingList;
