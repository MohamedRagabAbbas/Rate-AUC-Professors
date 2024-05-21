import unittest
from unittest.mock import MagicMock, patch
import json
from professor_profile import scrape_page, extract_data, scrape_professor_additional_info, scrape_faculty_profile_page, scrape_faculty_profiles

class TestScrapingFunctions(unittest.TestCase):

    def setUp(self):
        self.sample_soup = MagicMock()

    @patch('requests.get')
    def test_scrape_page(self, mock_requests_get):
        # Mock response from requests.get
        mock_response = MagicMock()
        mock_response.content = b'<html><body><table><tr><td><a href="/professor">Professor Name</a></td><td>Position</td><td>Department</td></tr></table></body></html>'
        mock_requests_get.return_value = mock_response
        
        # Mock BeautifulSoup object
        mock_soup = MagicMock()
        mock_soup.find.return_value = MagicMock()
        mock_soup.find.return_value.find_all.return_value = [
            MagicMock(get_text=lambda x, strip: "Professor Name"),
            MagicMock(get_text=lambda x, strip: "Position"),
            MagicMock(get_text=lambda x, strip: "Department")
        ]
        mock_soup.find.return_value.find_all.return_value[0].find.return_value.get_text.return_value = "Professor Name"

        # Patch BeautifulSoup constructor to return the mocked soup object
        with patch('bs4.BeautifulSoup', return_value=mock_soup):
            data = scrape_page("http://example.com")
            # self.assertEqual(len(data), 1)
            self.assertEqual(data[0]['name'], "Professor Name")
            self.assertEqual(data[0]['position'], "Position")
            self.assertEqual(data[0]['department'], "Department")



    # def test_extract_data(self):
    #     self.sample_soup.find.return_value = MagicMock()
    #     self.sample_soup.find.return_value.find_all.return_value = [
    #         MagicMock(get_text=lambda x, strip: "Professor Name"),
    #         MagicMock(get_text=lambda x, strip: "Position"),
    #         MagicMock(get_text=lambda x, strip: "Department")
    #     ]
    #     self.sample_soup.find.return_value.find_all.return_value[0].find.return_value.get_text.return_value = "Professor Name"
    #     data = extract_data(self.sample_soup)
    #     self.assertEqual(len(data), 1)
    #     self.assertEqual(data[0]['name'], "Professor Name")
    #     self.assertEqual(data[0]['position'], "Position")
    #     self.assertEqual(data[0]['department'], "Department")

    # def test_scrape_professor_additional_info(self):
    #     with patch('requests.get') as mock_requests_get:
    #         mock_response = MagicMock()
    #         mock_response.content = b'<html><body><div class="field--label">Label</div><div class="field--item">Value</div><a href="mailto:test@example.com">Email</a><img src="http://example.com/image.jpg"/><div class="profile__content-featured--links"><a href="http://example.com/link">Link</a></div></body></html>'
    #         mock_requests_get.return_value = mock_response
    #         email, profile_info, image_src, additional_links = scrape_professor_additional_info("http://example.com")
    #         self.assertEqual(email, "Email")
    #         self.assertEqual(profile_info, "{'Label': 'Value'}")
    #         self.assertEqual(image_src, "http://example.com/image.jpg")
    #         self.assertEqual(len(additional_links), 1)
    #         self.assertEqual(additional_links[0]['title'], "Link")
    #         self.assertEqual(additional_links[0]['src'], "http://example.com/link")

    # @patch('your_script_name.scrape_page')
    # def test_scrape_faculty_profile_page(self, mock_scrape_page):
    #     mock_scrape_page.return_value = [{'name': 'Professor Name', 'position': 'Position', 'department': 'Department'}]
    #     data = scrape_faculty_profile_page(1)
    #     self.assertEqual(len(data), 1)
    #     self.assertEqual(data[0]['name'], 'Professor Name')
    #     self.assertEqual(data[0]['position'], 'Position')
    #     self.assertEqual(data[0]['department'], 'Department')

    # @patch('your_script_name.scrape_faculty_profile_page')
    # def test_scrape_faculty_profiles(self, mock_scrape_faculty_profile_page):
    #     mock_scrape_faculty_profile_page.side_effect = [
    #         [{'name': 'Professor Name 1', 'position': 'Position 1', 'department': 'Department 1'}],
    #         [{'name': 'Professor Name 2', 'position': 'Position 2', 'department': 'Department 2'}]
    #     ]
    #     data = scrape_faculty_profiles(2)
    #     self.assertEqual(len(data), 2)
    #     self.assertEqual(data[0]['name'], 'Professor Name 1')
    #     self.assertEqual(data[0]['position'], 'Position 1')
    #     self.assertEqual(data[0]['department'], 'Department 1')
    #     self.assertEqual(data[1]['name'], 'Professor Name 2')
    #     self.assertEqual(data[1]['position'], 'Position 2')
    #     self.assertEqual(data[1]['department'], 'Department 2')

if __name__ == '__main__':
    unittest.main()
