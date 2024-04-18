import sqlite3
import os
import unittest

class TestDatabaseQuery(unittest.TestCase):
    def test_fetch_departments(self):
        # Path to the SQLite database file
        db_path = os.path.join(os.path.dirname(__file__), 'professors_data.db')

        # Connect to the SQLite database
        conn = sqlite3.connect(db_path)
        cursor = conn.cursor()

        try:
            # Execute the query to fetch department names
            cursor.execute('SELECT DISTINCT category FROM professors')
            rows = cursor.fetchall()

            # Check if the query returned the expected number of rows
            self.assertGreater(len(rows), 0)

            # Check if the query returned the expected department names
            expected_departments = ['Department of Mechanical Engineering', 'Department of Electronics and Communications Engineering', 'Department of Petroleum and Energy Engineering', 'Department of Architecture', 'Department of Biology', 'Department of Chemistry', 'Department of Computer Science and Engineering', 'Department of Construction Engineering', 'Department of Mathematics and Actuarial Science', 'Department of Physics', 'Institute of Global Health and Human Ecology', 'Dean of School of Humanities and Social Sciences', 'Department of Arts', 'Department of Applied Linguistics', 'Department of Arab and Islamic Civilizations', 'Department of Educational Studies', 'Department of English and Comparative Literature', 'Department of History', 'Prince AlWaleed Bin Talal Bin AbdulAziz AlSaud Center for American Studies and Research', 'Department of Philosophy', 'Department of Political Science', 'Department of Psychology', 'Department of Sociology, Egyptology and Anthropology', 'Department of Accounting', 'Department of Economics', 'Department of Management', 'J-PAL MENA at AUC', 'Dean of School of Global Affairs and Public Policy', 'Journalism and Mass Communication Department', 'Public Policy and Administration Department', 'The Kamal Adham Center for Television and Digital Journalism', 'Center for Migration and Refugee Studies', 'The Middle East Studies Program', 'Law Department', "The Cynthia Nelson Institute for Gender and Women's Studies"]  # Update with actual expected department names
            actual_departments = [row[0] for row in rows]
            for department in expected_departments:
                self.assertIn(department, actual_departments)

        except sqlite3.Error as e:
            self.fail(f"Error executing query: {e}")

        finally:
            # Close the database connection
            conn.close()

if __name__ == '__main__':
    unittest.main()
