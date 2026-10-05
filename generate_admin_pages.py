import json
import os
import re
import urllib.request

def ensure_dir(file_path):
    directory = os.path.dirname(file_path)
    if not os.path.exists(directory):
        os.makedirs(directory)

output_path = r'C:\Users\Ahmed Durwesh\.gemini\antigravity-ide\brain\bf712534-085a-49a7-9bdf-7ebbcbbb2761\.system_generated\steps\674\output.txt'
with open(output_path, 'r', encoding='utf-8') as f:
    data = json.load(f)

screen_mapping = {
    'Overview - Admin Dashboard - JamesThew.com': ('Admin', 'Dashboard', 'JamesThew.Web/Views/Admin/Dashboard.cshtml'),
    'Recipes - Admin Dashboard - JamesThew.com': ('Admin', 'Recipes', 'JamesThew.Web/Views/Admin/Recipes.cshtml'),
    'Add Recipe - Admin Dashboard - JamesThew.com': ('Admin', 'RecipeForm', 'JamesThew.Web/Views/Admin/RecipeForm.cshtml'),
    'Manage Tips - Admin Dashboard - JamesThew.com': ('Admin', 'Tips', 'JamesThew.Web/Views/Admin/Tips.cshtml'),
    'Add Tip - Admin Dashboard - JamesThew.com': ('Admin', 'TipForm', 'JamesThew.Web/Views/Admin/TipForm.cshtml'),
    'Manage Contests - Admin Dashboard - JamesThew.com': ('Admin', 'Contests', 'JamesThew.Web/Views/Admin/Contests.cshtml'),
    'Entries & Winners - Admin Dashboard - JamesThew.com': ('Admin', 'Entries', 'JamesThew.Web/Views/Admin/Entries.cshtml'),
    'Manage Members - Admin Dashboard - JamesThew.com': ('Admin', 'Members', 'JamesThew.Web/Views/Admin/Members.cshtml'),
    'Announcements - Admin Dashboard - JamesThew.com': ('Admin', 'Announcements', 'JamesThew.Web/Views/Admin/Announcements.cshtml'),
    'Feedback - Admin Dashboard - JamesThew.com': ('Admin', 'Feedback', 'JamesThew.Web/Views/Admin/Feedback.cshtml')
}

actions = []
for screen in data.get('screens', []):
    title = screen.get('title')
    html_info = screen.get('htmlCode', {})
    download_url = html_info.get('downloadUrl')
    
    if title in screen_mapping and download_url:
        controller, action, view_path = screen_mapping[title]
        actions.append(action)
        print(f"Downloading {title}...")
        try:
            req = urllib.request.Request(download_url, headers={'User-Agent': 'Mozilla/5.0'})
            with urllib.request.urlopen(req) as response:
                html = response.read().decode('utf-8')
                
            match = re.search(r'<main[^>]*>(.*?)</main>', html, re.DOTALL)
            if match:
                main_content = match.group(1).strip()
                razor_content = f"""@{{
    ViewData["Title"] = "{title.split(' - ')[0]}";
}}

{main_content}
"""
                ensure_dir(view_path)
                with open(view_path, 'w', encoding='utf-8') as f:
                    f.write(razor_content)
                print(f"-> Saved to {view_path}")
            else:
                print(f"-> Could not find <main> in {title}")
        except Exception as e:
            print(f"Failed to process {title}: {e}")

# Generate AdminController
actions_unique = set(actions)
action_template = """    public IActionResult {action_name}()
    {{
        return View();
    }}
"""
actions_code = "\\n".join([action_template.format(action_name=a) for a in actions_unique])

controller_code = f"""using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class AdminController : Controller
{{
{actions_code}
}}
"""

with open('JamesThew.Web/Controllers/AdminController.cs', 'w', encoding='utf-8') as f:
    f.write(controller_code)
print("-> Updated AdminController.cs")

