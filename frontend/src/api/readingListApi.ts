import axios from "axios";

// Define the base URL for the backend API
const API_BASE_URL = "http://localhost:5000/api/readinglist";

// Define the ReadingItem type
export interface ReadingItem {
  id: number;
  title: string;
  author: string;
  genre: string;
  isRead: boolean;
}

// Fetch all reading items
export const fetchReadingList = async (): Promise<ReadingItem[]> => {
  const response = await axios.get(API_BASE_URL);
  return response.data;
};

// Add a new reading item
export const addReadingItem = async (item: Omit<ReadingItem, "id">): Promise<ReadingItem> => {
  const response = await axios.post(API_BASE_URL, item);
  return response.data;
};

// Update an existing reading item
export const updateReadingItem = async (id: number, updatedItem: ReadingItem): Promise<void> => {
  await axios.put(`${API_BASE_URL}/${id}`, updatedItem);
};

// Delete a reading item
export const deleteReadingItem = async (id: number): Promise<void> => {
  await axios.delete(`${API_BASE_URL}/${id}`);
};
