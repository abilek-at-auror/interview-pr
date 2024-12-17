import React from "react";
import { render, screen } from "@testing-library/react";
import App from "./App";

// Test to check if the app renders correctly
describe("App", () => {
  it("renders the main heading", () => {
    render(<App />);
    const heading = screen.getByText(/My Reading List/i); // Looks for the heading in ReadingList component
    expect(heading).toBeInTheDocument();
  });

  it("renders the Add a New Book section", () => {
    render(<App />);
    const addSection = screen.getByText(/Add a New Book/i); // Verifies "Add a New Book" form is present
    expect(addSection).toBeInTheDocument();
  });
});
