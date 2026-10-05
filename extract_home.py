import re

with open('docs/home.html', 'r', encoding='utf-8') as f:
    html = f.read()

match = re.search(r'<main[^>]*>(.*?)</main>', html, re.DOTALL)
if match:
    main_content = match.group(1).strip()
    
    razor_content = f"""@{{
    ViewData["Title"] = "Home";
}}

{main_content}
"""
    with open('JamesThew.Web/Views/Home/Index.cshtml', 'w', encoding='utf-8') as f:
        f.write(razor_content)
    print('Updated Index.cshtml successfully.')
else:
    print('Could not find <main> block.')
