import axios from "axios";
import { fetchReadingList } from "./readingListApi";
import MockAdapter from "axios-mock-adapter";

const mock = new MockAdapter(axios);

describe("fetchReadingList", () => {
  it("should fetch reading list items", async () => {
    const mockData = [
      { id: 1, title: "Test Book", author: "Test Author", genre: "Fiction", isRead: false },
    ];

    mock.onGet("http://localhost:5000/api/readinglist").reply(200, mockData);

    const result = await fetchReadingList();
    expect(result).toEqual(mockData);
  });
});
