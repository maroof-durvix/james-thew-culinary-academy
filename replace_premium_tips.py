import re

with open('JamesThew.Web/Views/Tip/Premium.cshtml', 'r', encoding='utf-8') as f:
    html = f.read()

if '@model' not in html:
    html = '@model IEnumerable<JamesThew.Web.Models.Entities.Tip>\n' + html

# find the start of the grid
grid_start_idx = html.find('<div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-gutter mb-space-xl">') + len('<div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-gutter mb-space-xl">\n')
grid_end_idx = html.find('</div>\n</div>\n</div>') # End of grid and container

razor_loop = '''@foreach(var tip in Model) {
    var isLocked = !(User.Identity?.IsAuthenticated ?? false);
<div class="relative rounded-[18px] bg-surface-container-high/80 p-space-lg flex flex-col justify-between overflow-hidden shadow-lg group hover:shadow-[0_8px_32px_rgba(0,0,0,0.5)] transition-all">
<div class="relative z-10 flex flex-col h-full">
<div class="flex items-center justify-between gap-space-xs mb-space-md">
<div class="inline-flex items-center gap-1.5 px-2.5 py-1 rounded-full bg-primary-container/20 text-primary-container font-label-sm text-label-sm font-semibold">
<span class="material-symbols-outlined text-[13px]">military_tech</span>
<span>Premium</span>
</div>
<span class="px-2.5 py-1 rounded-full bg-surface-container text-secondary font-label-sm text-label-sm">@tip.Category.Name</span>
</div>
<h3 class="font-headline-sm text-headline-sm text-on-surface mb-space-sm leading-snug group-hover:text-primary transition-colors">@tip.Title</h3>
<div class="flex items-center gap-space-xs text-outline font-label-sm text-label-sm mb-space-md">
<span class="material-symbols-outlined text-[16px] text-primary-container">verified</span>
<span class="truncate">@tip.Author.FullName • Culinary Master</span>
</div>
<div class="relative mt-auto pt-space-xs">
<div class="@(isLocked ? "blur-[5px] select-none pointer-events-none" : "") text-outline font-body-sm text-body-sm leading-relaxed line-clamp-4">
              @tip.Content
            </div>
@if(isLocked) {
<div class="absolute inset-0 bg-surface-container-high/40 rounded-xl flex flex-col items-center justify-center p-space-sm text-center">
<div class="w-8 h-8 rounded-full bg-primary-container/20 text-primary-container flex items-center justify-center mb-1.5 shadow-[0_2px_10px_rgba(217,138,86,0.3)]">
<span class="material-symbols-outlined text-[18px]">lock</span>
</div>
<span class="font-label-sm text-label-sm text-on-surface font-semibold tracking-wide uppercase mb-1">Members Only • Secret Executive Formula</span>
<a class="mt-1 inline-flex items-center gap-1 text-primary-container hover:text-primary font-label-md text-label-md font-semibold transition-colors" href="/Account/Login">
                Unlock Tip <span class="material-symbols-outlined text-[14px]">arrow_forward</span>
</a>
</div>
}
</div>
<div class="mt-space-md pt-space-sm flex items-center justify-between font-label-sm text-label-sm text-outline">
<span class="flex items-center gap-1"><span class="material-symbols-outlined text-[14px]">calendar_today</span> @tip.CreatedAt.ToString("MMM dd, yyyy")</span>
<span class="text-primary-container font-medium">Vault File #@tip.Id</span>
</div>
</div>
</div>
}
'''

new_html = html[:grid_start_idx] + razor_loop + html[grid_end_idx:]

with open('JamesThew.Web/Views/Tip/Premium.cshtml', 'w', encoding='utf-8') as f:
    f.write(new_html)

print("Replaced Premium tips grid with razor loop")
