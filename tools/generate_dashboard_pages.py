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
    'Overview - Dashboard - JamesThew.com': ('Dashboard', 'Index', 'JamesThew.Web/Views/Dashboard/Index.cshtml'),
    'My Tips - Dashboard - JamesThew.com': ('Dashboard', 'MyTips', 'JamesThew.Web/Views/Dashboard/MyTips.cshtml'),
    'Add Tip - Dashboard - JamesThew.com': ('Dashboard', 'AddTip', 'JamesThew.Web/Views/Dashboard/AddTip.cshtml'),
    'Add Recipe - Dashboard - JamesThew.com': ('Dashboard', 'AddRecipe', 'JamesThew.Web/Views/Dashboard/AddRecipe.cshtml'),
    'Subscription - Dashboard - JamesThew.com': ('Dashboard', 'Subscription', 'JamesThew.Web/Views/Dashboard/Subscription.cshtml'),
    'Profile Settings - Dashboard - JamesThew.com': ('Dashboard', 'ProfileSettings', 'JamesThew.Web/Views/Dashboard/ProfileSettings.cshtml'),
    'My Contest Entries - Dashboard - JamesThew.com': ('Dashboard', 'MyContestEntries', 'JamesThew.Web/Views/Dashboard/MyContestEntries.cshtml')
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

# Inject missing MyRecipes.cshtml (Duplicate of MyTips for now)
try:
    with open('JamesThew.Web/Views/Dashboard/MyTips.cshtml', 'r', encoding='utf-8') as f:
        mytips_content = f.read()
    myrecipes_content = mytips_content.replace('My Tips', 'My Recipes').replace('Tip', 'Recipe')
    with open('JamesThew.Web/Views/Dashboard/MyRecipes.cshtml', 'w', encoding='utf-8') as f:
        f.write(myrecipes_content)
    print("-> Cloned MyRecipes.cshtml from MyTips.cshtml")
    actions.append('MyRecipes')
except Exception as e:
    print(f"Failed to clone MyRecipes: {e}")

# Generate DashboardController
controller_path = 'JamesThew.Web/Controllers/DashboardController.cs'
if os.path.exists(controller_path):
    with open(controller_path, 'r', encoding='utf-8') as f:
        existing_content = f.read()
    
    action_str = ""
    for a in set(actions):
        if f"IActionResult {a}()" not in existing_content:
            action_str += f"""
    public IActionResult {a}()
    {{
        return View();
    }}
"""
    new_content = existing_content.replace('}', f'{action_str}\n}}')
    # a bit crude, let's just rewrite the whole controller
    
actions_unique = set(actions)
action_template = """    public IActionResult {action_name}()
    {{
        return View();
    }}
"""
actions_code = "\\n".join([action_template.format(action_name=a) for a in actions_unique])

controller_code = f"""using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class DashboardController : Controller
{{
{actions_code}
}}
"""

with open('JamesThew.Web/Controllers/DashboardController.cs', 'w', encoding='utf-8') as f:
    f.write(controller_code)
print("-> Updated DashboardController.cs")

