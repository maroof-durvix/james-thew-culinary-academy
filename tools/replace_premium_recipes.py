import re

with open('JamesThew.Web/Views/Recipe/Premium.cshtml', 'r', encoding='utf-8') as f:
    html = f.read()

if '@model' not in html:
    html = '@model IEnumerable<JamesThew.Web.Models.Entities.Recipe>\n' + html

card_start_idx = html.find('<!-- CARD 1 -->')
pagination_idx = html.find('<!-- Centered Pagination Controls -->')

razor_loop = '''@foreach(var recipe in Model) {
<article class="group rounded-2xl bg-surface-container/75 backdrop-blur-md overflow-hidden hover:-translate-y-1.5 transition-all duration-300 shadow-md hover:shadow-2xl flex flex-col justify-between">
<div class="relative w-full">
<div class="aspect-[16/11] w-full overflow-hidden relative">
<img class="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500" data-alt="@recipe.Title" src="@recipe.ImagePath"/>
<div class="absolute inset-0 bg-gradient-to-t from-surface-container-lowest/80 via-transparent to-black/25"></div>
</div>
<!-- Category & Premium Badges -->
<div class="absolute top-3 left-3 flex items-center gap-1.5">
<span class="px-2.5 py-1 rounded-full text-label-sm font-label-sm uppercase bg-surface-container-lowest/90 backdrop-blur-md text-secondary">
                @recipe.Category.Name
              </span>
<span class="px-2.5 py-1 rounded-full text-label-sm font-label-sm uppercase bg-primary-container text-surface-container-lowest font-bold flex items-center gap-1 shadow-sm">
<span class="material-symbols-outlined text-[13px]" style="font-variation-settings: \'FILL\' 1;">workspace_premium</span>
                Premium
              </span>
</div>
<!-- Member Bookmark Toggle -->
<button aria-label="Save Recipe" class="absolute top-3 right-3 w-8 h-8 rounded-full bg-surface-container-lowest/80 backdrop-blur-md flex items-center justify-center text-primary hover:scale-110 transition-transform cursor-pointer">
<span class="material-symbols-outlined text-[18px]" style="font-variation-settings: \'FILL\' 1;">bookmark</span>
</button>
</div>
<div class="p-space-md flex flex-col flex-1 justify-between gap-space-sm">
<div>
<div class="flex items-center gap-2 mb-2">
<span class="font-label-sm text-label-sm text-on-surface-variant flex items-center gap-1">
                  By @recipe.Author.FullName
</span>
</div>
<h2 class="font-headline-sm text-headline-sm text-on-surface line-clamp-1 group-hover:text-primary transition-colors">
                @recipe.Title
              </h2>
<p class="font-body-sm text-body-sm text-on-surface-variant line-clamp-2 mt-1">
                @recipe.Procedure.Substring(0, Math.Min(recipe.Procedure.Length, 80))...
              </p>
</div>
<div class="pt-space-sm flex flex-col gap-space-sm">
<div class="flex items-center justify-between text-label-sm font-label-sm text-outline">
<span class="flex items-center gap-1">
<span class="material-symbols-outlined text-[16px] text-secondary">schedule</span>
                  @recipe.PrepMinutes mins prep • @recipe.CookMinutes mins cook
                </span>
<span class="flex items-center gap-1 font-semibold text-primary">
<span class="material-symbols-outlined text-[15px]" style="font-variation-settings: \'FILL\' 1;">star</span>
                  5.0 <span class="text-outline font-normal">(0)</span>
</span>
</div>
<a class="w-full py-2.5 rounded-full bg-primary-container text-surface-container-lowest font-title-md text-title-md font-semibold text-center hover:bg-primary shadow-[0_4px_16px_rgba(217,138,86,0.25)] hover:shadow-[0_6px_20px_rgba(217,138,86,0.35)] transition-all flex items-center justify-center gap-1.5" href="/Recipe/Details/@recipe.Id">
<span>View Recipe</span>
<span class="material-symbols-outlined text-[18px]">arrow_forward</span>
</a>
</div>
</div>
</article>
}
'''

new_html = html[:card_start_idx] + razor_loop + html[pagination_idx:]

with open('JamesThew.Web/Views/Recipe/Premium.cshtml', 'w', encoding='utf-8') as f:
    f.write(new_html)

print("Replaced Premium recipes grid with razor loop")
