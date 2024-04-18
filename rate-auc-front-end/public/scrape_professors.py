import requests
from bs4 import BeautifulSoup
import csv
import re

# Function to store data in a CSV file
def store_data_in_csv(data):
    # Specify the CSV file path
    csv_file = './public/professors_data.csv'

    # Open the CSV file in write mode
    with open(csv_file, 'w', newline='', encoding='utf-8') as file:
        # Define the CSV writer
        writer = csv.writer(file)
        # Write the header row
        writer.writerow(['Professor', 'Category'])
        # Write each row of data
        for professor, category in data.items():
            writer.writerow([professor, category])

# Function to scrape and store data from multiple URLs
def scrape_and_store_multiple(urls):
    # Initialize an empty dictionary to store professors with their categories
    professors_data = {}

    # Loop through each URL
    for url in urls:
        # Send a GET request to the URL
        response = requests.get(url)
        # Check if the request was successful
        if response.status_code == 200:
            # Parse the HTML content of the page
            soup = BeautifulSoup(response.content, 'html.parser')

            # Initialize variables to store current category and associated professors
            current_category = None
            current_professors = []

            # Find all h2 and h3 elements with specific classes
            headings = soup.find_all(['h2', 'h3'], class_=lambda x: x and 'faculty-spotlight' in x)

            # Loop through each heading
            for heading in headings:
                # If the heading is an h2 element (category)
                if heading.name == 'h2':
                    # If there were professors under the previous category, store them
                    if current_category and current_professors:
                        for professor in current_professors:
                            professors_data[re.sub(r'\s+', ' ', professor.strip())] = current_category

                    # Update the current category
                    current_category = heading.get_text().strip()
                    # Reset the list of current professors
                    current_professors = []

                # If the heading is an h3 element (professor)
                elif heading.name == 'h3':
                    # Get the professor name and trim extra spaces
                    professor_name = heading.get_text().strip()
                    # If there is a current category, store the professor under it
                    if current_category:
                        current_professors.append(professor_name.strip())

            # If there were professors under the last category, store them
            if current_category and current_professors:
                for professor in current_professors:
                    professors_data[re.sub(r'\s+', ' ', professor.strip())] = current_category

        else:
            # If the request was not successful, print an error message
            print(f"Error: Unable to retrieve data from the URL: {url}")

    # Return the aggregated scraped data
    return professors_data

# List of URLs to scrape
urls = ['https://sse.aucegypt.edu/people/faculty', 'https://huss.aucegypt.edu/people/faculty', 'https://business.aucegypt.edu/about/people/faculty','https://gapp.aucegypt.edu/about/people/faculty']

# Call the scrape_and_store_multiple function with the list of URLs
professors_data = scrape_and_store_multiple(urls)

if professors_data:
    # Store the scraped data into the CSV file
    store_data_in_csv(professors_data)
    print("Scraped data from multiple URLs has been saved to professors_data.csv")
else:
    print("No data was scraped.")
