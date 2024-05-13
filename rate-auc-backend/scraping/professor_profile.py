import json
import requests
from bs4 import BeautifulSoup

# Function to scrape data from a single page
def scrape_page(url):
    response = requests.get(url)
    if response.status_code == 200:
        soup = BeautifulSoup(response.content, 'html.parser')
        table = soup.find('table')
        rows = table.find_all('tr')
        data = []
        for row in rows[1:]:  # Skip the header row
            cells = row.find_all('td')
            professor_name = cells[0].find('a').get_text(strip=True).replace('Name', '').strip()
            professor_link = cells[0].find('a')['href']
            position = cells[1].get_text(strip=True)
            department = cells[2].get_text(strip=True)
            # Scrape professor's profile for additional info, email, and image
            email, profile_info, image_src, additional_links = scrape_professor_additional_info(professor_link)
            data.append({
                "name": professor_name,
                "position": position,
                "department": department,
                "email": email,
                "profile_info": profile_info,
                "image_src": image_src,
                "additional_links": additional_links
            })
        return data
    else:
        print("Failed to fetch page:", url)
        return []

# Function to scrape professor's profile page for additional info, email, image, and additional links
def scrape_professor_additional_info(url):
    response = requests.get(url)
    if response.status_code == 200:
        soup = BeautifulSoup(response.content, 'html.parser')
        profile_info = {}
        fields = soup.find_all(class_='field--label')
        for field in fields:
            label = field.get_text(strip=True)
            item = field.find_next(class_='field--item').get_text(strip=True)
            profile_info[label] = item
        # Search for email
        email_link = soup.find('a', href=lambda href: href and href.startswith('mailto:'))
        email = email_link.get_text(strip=True) if email_link else None
        # Search for image
        img_tag = soup.find('img', src=lambda src: src)
        image_src = str(img_tag['src'])
        # Search for additional links
        additional_links = []
        links_div = soup.find(class_='profile__content-featured--links')
        if links_div:
            links = links_div.find_all('a')
            for link in links:
                link_title = link.get_text(strip=True)
                link_src = link['href']
                additional_links.append({'title': link_title, 'src': link_src})
        return email, str(profile_info), image_src, additional_links
    else:
        print("Failed to fetch professor's profile page:", url)
        return None, None, None, None

# Base URL
base_url = "https://www.aucegypt.edu/faculty-profiles/search?page="

# Iterate through pages 0 to 34
all_data = []
for page_num in range(35):
    url = base_url + str(page_num)
    print("Scraping page:", url)
    page_data = scrape_page(url)
    all_data.extend(page_data)

# Save data to a JSON file
with open('faculty_profiles.json', 'w') as f:
    json.dump(all_data, f, indent=4)
