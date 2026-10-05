import os, re
import glob

def process_file(path):
    with open(path, 'r', encoding='utf-8') as f:
        content = f.read()

    # Remove pragma
    content = content.replace('#pragma warning disable CS8618\n', '')

    # Fix ICollection
    content = re.sub(
        r'public (virtual )?ICollection<([A-Za-z0-9_]+)>\s+([A-Za-z0-9_]+)\s*\{\s*get;\s*set;\s*\}',
        r'public \1ICollection<\2> \3 { get; set; } = new List<\2>();',
        content
    )

    # Fix DbSet
    content = re.sub(
        r'public DbSet<([A-Za-z0-9_]+)>\s+([A-Za-z0-9_]+)\s*\{\s*get;\s*set;\s*\}',
        r'public DbSet<\1> \2 { get; set; } = null!;',
        content
    )

    # Fix strings
    content = re.sub(
        r'public string ([A-Za-z0-9_]+)\s*\{\s*get;\s*set;\s*\}',
        r'public string \1 { get; set; } = string.Empty;',
        content
    )

    # Fix navigation properties (single object like Category Category or User User)
    def repl(m):
        if m.group(2) in ['DateTime', 'bool', 'int', 'decimal', 'float', 'double', 'Guid', 'TimeSpan']:
            return m.group(0)
        return f'public {m.group(1) or ""}{m.group(2)} {m.group(3)} {{ get; set; }} = null!;'
        
    content = re.sub(
        r'public (virtual )?([A-Z][A-Za-z0-9_]+)\s+([A-Za-z0-9_]+)\s*\{\s*get;\s*set;\s*\}',
        repl,
        content
    )

    with open(path, 'w', encoding='utf-8') as f:
        f.write(content)

for root, dirs, files in os.walk('JamesThew.Web'):
    if 'Migrations' in root:
        continue
    for file in files:
        if file.endswith('.cs'):
            process_file(os.path.join(root, file))
print('Done.')
