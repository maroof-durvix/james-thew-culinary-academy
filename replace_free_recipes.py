import re

with open('JamesThew.Web/Views/Recipe/Free.cshtml', 'r', encoding='utf-8') as f:
    html = f.read()

# Prepend Model if not exists
if '@model' not in html:
    html = '@model IEnumerable<JamesThew.Web.Models.Entities.Recipe>\n' + html

card_start_idx = html.find('<!-- Card 1:')
pagination_idx = html.find('<!-- Pagination Section -->')

razor_loop = '''@foreach(var recipe in Model) {
<article class="group relative flex flex-col bg-surface-container-high/80 backdrop-blur-xl rounded-[18px] overflow-hidden shadow-lg hover:shadow-2xl transition-all duration-300 hover:-translate-y-1.5">
<div class="relative w-full h-56 overflow-hidden">
<div class="w-full h-full bg-cover bg-center transition-transform duration-700 group-hover:scale-105" data-alt="@recipe.Title" style="background-image: url('@recipe.ImagePath')"></div>
<div class="absolute inset-0 bg-gradient-to-t from-surface-container-high via-transparent to-black/30"></div>
<div class="absolute top-space-sm left-space-sm flex items-center gap-space-xs">
<span class="px-space-sm py-0.5 rounded-full bg-secondary-container/90 text-secondary font-label-sm text-label-sm tracking-wider uppercase font-semibold backdrop-blur-md">
                @recipe.Access
              </span>
<span class="px-space-sm py-0.5 rounded-full bg-surface-container-lowest/80 text-on-surface-variant font-label-sm text-label-sm uppercase backdrop-blur-md">
                @recipe.Category.Name
              </span>
</div>
<button aria-label="Bookmark Recipe" class="absolute top-space-sm right-space-sm w-8 h-8 rounded-full bg-surface-container-lowest/70 backdrop-blur-md flex items-center justify-center text-primary hover:bg-primary-container hover:text-surface-container-lowest transition-colors">
<span class="material-symbols-outlined text-[16px]">bookmark</span>
</button>
</div>
<div class="flex flex-col flex-1 p-space-md justify-between">
<div>
<div class="flex items-center justify-between text-label-sm text-outline font-label-sm mb-space-xs">
<span>By @recipe.Author.FullName</span>
<span class="flex items-center gap-1 text-primary-container font-semibold">
<span class="material-symbols-outlined text-[14px]" style="font-variation-settings: \'FILL\' 1;">star</span> 5.0
                </span>
</div>
<h2 class="font-headline-sm text-headline-sm text-on-surface group-hover:text-primary transition-colors leading-snug mb-space-sm">
                @recipe.Title
              </h2>
</div>
<div class="pt-space-sm mt-space-sm border-t border-surface-container-highest/60 flex items-center justify-between">
<div class="flex items-center gap-space-xs text-on-surface-variant font-body-sm text-body-sm">
<span class="material-symbols-outlined text-outline text-[16px]">schedule</span>
<span>@(recipe.PrepMinutes + recipe.CookMinutes) mins</span>
</div>
<a class="inline-flex items-center gap-1 px-space-md py-space-xs rounded-full bg-primary-container text-surface-container-lowest font-title-md text-title-md hover:bg-primary transition-all shadow-[0_2px_10px_rgba(217,138,86,0.25)]" href="/Recipe/Details/@recipe.Id">
<span>View</span>
<span class="material-symbols-outlined text-[16px]">arrow_forward</span>
</a>
</div>
</div>
</article>
}
'''

new_html = html[:card_start_idx] + razor_loop + html[pagination_idx:]

with open('JamesThew.Web/Views/Recipe/Free.cshtml', 'w', encoding='utf-8') as f:
    f.write(new_html)

print("Replaced Free recipes grid with razor loop")
