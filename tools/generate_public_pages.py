import json
import os
import re
import urllib.request

def ensure_dir(file_path):
    directory = os.path.dirname(file_path)
    if not os.path.exists(directory):
        os.makedirs(directory)

# Read output.txt
output_path = r'C:\Users\Ahmed Durwesh\.gemini\antigravity-ide\brain\bf712534-085a-49a7-9bdf-7ebbcbbb2761\.system_generated\steps\635\output.txt'
with open(output_path, 'r', encoding='utf-8') as f:
    data = json.load(f)

# Mapping from title to (Controller, Action, ViewPath)
screen_mapping = {
    'Chef James - About - JamesThew.com': ('About', 'ChefJames', 'JamesThew.Web/Views/About/ChefJames.cshtml'),
    'FAQ - Help - JamesThew.com': ('Faq', 'Index', 'JamesThew.Web/Views/Faq/Index.cshtml'),
    'Premium Tips (Guest) - Tips & Tricks - JamesThew.com': ('Tip', 'Premium', 'JamesThew.Web/Views/Tip/Premium.cshtml'),
    'Membership Plans - JamesThew.com': ('Account', 'Plans', 'JamesThew.Web/Views/Account/Plans.cshtml'),
    'Contact Us - Help - JamesThew.com': ('Contact', 'Index', 'JamesThew.Web/Views/Contact/Index.cshtml'),
    'Give Feedback - Help - JamesThew.com': ('Feedback', 'SiteFeedback', 'JamesThew.Web/Views/Feedback/SiteFeedback.cshtml'),
    'Tip Details - Tips & Tricks - JamesThew.com': ('Tip', 'Details', 'JamesThew.Web/Views/Tip/Details.cshtml'),
    'Cookery Classes - About - JamesThew.com': ('About', 'Classes', 'JamesThew.Web/Views/About/Classes.cshtml'),
    'Our Mission - About - JamesThew.com': ('About', 'Mission', 'JamesThew.Web/Views/About/Mission.cshtml'),
    'Announcements - JamesThew.com': ('Announcement', 'Index', 'JamesThew.Web/Views/Announcement/Index.cshtml'),
    'Premium Recipes (Member) - JamesThew.com': ('Recipe', 'Premium', 'JamesThew.Web/Views/Recipe/Premium.cshtml'),
    'Active Contests - Contests - JamesThew.com': ('Contest', 'Active', 'JamesThew.Web/Views/Contest/Active.cshtml'),
    'Past Winners - Contests - JamesThew.com': ('Contest', 'Winners', 'JamesThew.Web/Views/Contest/Winners.cshtml'),
    'Submit Contest Entry - Contests - JamesThew.com': ('Contest', 'Submit', 'JamesThew.Web/Views/Contest/Submit.cshtml'),
    'Recipe Details - JamesThew.com': ('Recipe', 'Details', 'JamesThew.Web/Views/Recipe/Details.cshtml'),
    'Free Tips - Tips & Tricks - JamesThew.com': ('Tip', 'Free', 'JamesThew.Web/Views/Tip/Free.cshtml'),
    'Free Recipes - Recipes - JamesThew.com': ('Recipe', 'Free', 'JamesThew.Web/Views/Recipe/Free.cshtml'),
    'Terms of Service & Privacy - JamesThew.com': ('Home', 'Terms', 'JamesThew.Web/Views/Home/Terms.cshtml') # We'll copy this to Privacy later
}

controllers_needed = set()

for screen in data.get('screens', []):
    title = screen.get('title')
    html_info = screen.get('htmlCode', {})
    download_url = html_info.get('downloadUrl')
    
    if title in screen_mapping and download_url:
        controller, action, view_path = screen_mapping[title]
        controllers_needed.add(controller)
        
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

# Generate controllers
controller_template = """using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class {controller_name}Controller : Controller
{{
{actions}
}}
"""

action_template = """    public IActionResult {action_name}()
    {{
        return View();
    }}
"""

for controller in controllers_needed:
    if controller in ['Home', 'Account']:
        continue # Already exist or partially exist
        
    actions = []
    for title, (c, a, v) in screen_mapping.items():
        if c == controller:
            actions.append(action_template.format(action_name=a))
            
    # For Tip Details / Recipe Details / Edit Tip, they might need {id}
    # But for now a basic action is enough to render the view
    
    controller_content = controller_template.format(controller_name=controller, actions="\n".join(actions))
    controller_path = f'JamesThew.Web/Controllers/{controller}Controller.cs'
    
    if not os.path.exists(controller_path):
        ensure_dir(controller_path)
        with open(controller_path, 'w', encoding='utf-8') as f:
            f.write(controller_content)
        print(f"-> Created {controller_path}")

print("Done generating views and controllers.")
