import json
import urllib.request
import re

output_path = r'C:\Users\Ahmed Durwesh\.gemini\antigravity-ide\brain\bf712534-085a-49a7-9bdf-7ebbcbbb2761\.system_generated\steps\674\output.txt'
with open(output_path, 'r', encoding='utf-8') as f:
    data = json.load(f)

for screen in data.get('screens', []):
    if screen.get('title') == 'Submit Contest Entry - Contests - JamesThew.com':
        url = screen['htmlCode']['downloadUrl']
        print('Downloading Submit Contest Entry...')
        req = urllib.request.Request(url, headers={'User-Agent': 'Mozilla/5.0'})
        with urllib.request.urlopen(req) as response:
            html = response.read().decode('utf-8')
        match = re.search(r'<main[^>]*>(.*?)</main>', html, re.DOTALL)
        if match:
            with open('JamesThew.Web/Views/Contest/Submit.cshtml', 'w', encoding='utf-8') as out_f:
                out_f.write('@{\n    ViewData["Title"] = "Submit Contest Entry";\n}\n\n' + match.group(1).strip())
            print('Saved to Views/Contest/Submit.cshtml')
        else:
            print('Could not find <main>')
