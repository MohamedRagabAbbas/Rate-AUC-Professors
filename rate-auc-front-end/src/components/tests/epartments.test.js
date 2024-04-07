import React from 'react';
import { render, fireEvent, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import DepartmentsList from '../departments.js';
import App from "../../App.js"; 

// Mock fetch function
global.fetch = jest.fn(() =>
  Promise.resolve({
    body: {
      getReader: jest.fn(() => ({
        read: jest.fn(() =>
          Promise.resolve({
            value: new TextEncoder().encode('Category,Professor\nMath,John Doe\n')
          })
        )
      }))
    }
  })
);

describe('DepartmentsList component', () => {
  it('renders Departments heading', async () => {
    const { getByText } = render(<DepartmentsList />);
    expect(getByText('Departments')).toBeInTheDocument();
  });

  it('renders categories after clicking on Departments button in navbar', async () => {
    const { getByText, getByTestId, getAllByText } = render(<App />);
    const allDepartmentsButtons = getAllByText('Departments');
    const departmentsButton = allDepartmentsButtons.find(button => button.type === 'button'); // Assuming the button has type attribute set to 'button'
    fireEvent.click(departmentsButton[0]); // Click the first button found
    await waitFor(() => expect(getByText('Department')).toBeInTheDocument());
  });

  it('renders professors when category is clicked', async () => {
    const { getByText, getAllByText, getByTestId } = render(<App />);
    const departmentsLink = getByText('Departments');
    fireEvent.click(departmentsLink);
    await waitFor(() => expect(getByText('Math')).toBeInTheDocument());
    
    const category = getByText('Math');
    fireEvent.click(category);
    await waitFor(() => expect(getByText('John Doe')).toBeInTheDocument());
  });

  it('returns to Departments when return button is clicked', async () => {
    const { getByText, getByTestId } = render(<App />);
    const departmentsLink = getByText('Departments');
    fireEvent.click(departmentsLink);
    await waitFor(() => expect(getByText('Math')).toBeInTheDocument());
    
    const category = getByText('Math');
    fireEvent.click(category);
    await waitFor(() => expect(getByText('John Doe')).toBeInTheDocument());
    
    const returnButton = getByTestId('return-button');
    fireEvent.click(returnButton);
    await waitFor(() => expect(getByText('Departments')).toBeInTheDocument());
  });
});
