# Stitch Screens

## Master List (43 Screens)
| Screen Name | Route | Layout | Status |
|---|---|---|---|
| Active Contests - Contests - JamesThew.com | /Contest/Index | _Layout | Planned |
| Add Recipe - Admin Dashboard - JamesThew.com | /Admin/Recipes | _DashboardLayout | Planned |
| Add Recipe - Dashboard - JamesThew.com | /Dashboard/Recipes | _DashboardLayout | Planned |
| Add Tip - Admin Dashboard - JamesThew.com | /Admin/Tips | _DashboardLayout | Planned |
| Add Tip - Dashboard - JamesThew.com | /Dashboard/Tips | _DashboardLayout | Planned |
| Announcements - Admin Dashboard - JamesThew.com | /Admin/Announcements | _DashboardLayout | Planned |
| Announcements - JamesThew.com | /Announcement/Index | _Layout | Planned |
| Chef James - About - JamesThew.com | /About/ChefJames | _Layout | Planned |
| Contact Us - Help - JamesThew.com | /Support/Contact | _Layout | Planned |
| Cookery Classes - About - JamesThew.com | /About/Classes | _Layout | Planned |
| Entries & Winners - Admin Dashboard - JamesThew.com | /Admin/Entries | _DashboardLayout | Planned |
| FAQ - Help - JamesThew.com | /Support/FAQ | _Layout | Planned |
| Feedback - Admin Dashboard - JamesThew.com | /Admin/Feedbacks | _DashboardLayout | Planned |
| Forgot Password - JamesThew.com | /Auth/ForgotPassword | _Layout | Planned |
| Free Recipes - Recipes - JamesThew.com | /Recipe/Free | _Layout | Planned |
| Free Tips - Tips & Tricks - JamesThew.com | /Tip/Free | _Layout | Planned |
| Give Feedback - Help - JamesThew.com | /Support/Feedback | _Layout | Planned |
| Home - JamesThew.com | /Home/Index | _Layout | Planned |
| Home - JamesThew.com (Mobile) | /Home/Index | _Layout | Planned |
| Join Now - Registration & Membership - JamesThew.com | /Auth/Register | _Layout | Planned |
| Login - JamesThew.com | /Auth/Login | _Layout | Planned |
| Manage Contests - Admin Dashboard - JamesThew.com | /Admin/Contests | _DashboardLayout | Planned |
| Manage Members - Admin Dashboard - JamesThew.com | /Admin/Members | _DashboardLayout | Planned |
| Manage Tips - Admin Dashboard - JamesThew.com | /Admin/Tips | _DashboardLayout | Planned |
| Membership Plans - JamesThew.com | /Membership/Plans | _Layout | Planned |
| My Contest Entries - Dashboard - JamesThew.com | /Dashboard/Entries | _DashboardLayout | Planned |
| My Tips - Dashboard - JamesThew.com | /Dashboard/Tips | _DashboardLayout | Planned |
| Our Mission - About - JamesThew.com | /About/Mission | _Layout | Planned |
| Overview - Admin Dashboard - JamesThew.com | /Admin/Index | _DashboardLayout | Planned |
| Overview - Dashboard - JamesThew.com | /Dashboard/Index | _DashboardLayout | Planned |
| Past Winners - Contests - JamesThew.com | /Contest/Winners | _Layout | Planned |
| Premium Recipes (Guest) - JamesThew.com | /Recipe/Premium | _Layout | Planned |
| Premium Recipes (Member) - JamesThew.com | /Recipe/Premium | _Layout | Planned |
| Premium Tips (Guest) - Tips & Tricks - JamesThew.com | /Tip/Premium | _Layout | Planned |
| Profile Settings - Dashboard - JamesThew.com | /Dashboard/Profile | _DashboardLayout | Planned |
| Recipe Details (Guest Locked) - JamesThew.com | /Recipe/Details/{id} | _Layout | Planned |
| Recipe Details - JamesThew.com | /Recipe/Details/{id} | _Layout | Planned |
| Recipe Details - JamesThew.com (Mobile) | /Recipe/Details/{id} | _Layout | Planned |
| Recipes - Admin Dashboard - JamesThew.com | /Admin/Recipes | _DashboardLayout | Planned |
| Submit Contest Entry - Contests - JamesThew.com | /Contest/Submit | _Layout | Planned |
| Subscription - Dashboard - JamesThew.com | /Dashboard/Subscription | _DashboardLayout | Planned |
| Terms of Service & Privacy - JamesThew.com | /Support/TermsPrivacy | _Layout | Planned |
| Tip Details - Tips & Tricks - JamesThew.com | /Tip/Details/{id} | _Layout | Planned |

## Page Specifications

### Active Contests - Contests - JamesThew.com
**ID/Slug:** `contest-active`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/luxurious-culinary-toolkit-arrangement-featuring-7094ec.jpg`
- `/images/a-cold-press-artisanal-infusion-arrangement-feat-3163bd.jpg`
- `/images/rustic-freshly-baked-artisanal-sourdough-loaf-wi-613a73.jpg`

**Visual Elements:**
```text
a: Home [chevron_right]
a: Contests [chevron_right] Active Contests Culinary Competitions
h1: Active Culinary Contests
p: Showcase your kitchen craft, earn guild recognition, and win exclusive artisanal culinary kits.

  ## SECTION
h2: Best Italian Recipe or Summer Juice Tip
p: Post your best Italian Recipe or Summer Juice Tip to win an Exclusive Culinary Kit! Submission Window Closes In 12 Days : 18 Hours : 44 Mins
a: Participate Now [arrow_forward]
a: Read Full Guidelines [stars] Official Award Kit
p: Grand Prize Package: Chef James's Artisanal 7-Piece Copper & Steel Master Kit (Valued at $650) + 1-on-1 Masterclass Consultation

  ## SECTION
h3: Numbered Contest Rules
p: Please adhere to the official standards to qualify for final guild deliberation and prize adjudication.
li: 1
h4: Original Recipe or Tip
p: All submissions must be authentic domestic or professional kitchen creations developed by the entrant.
li: 2
h4: Comprehensive Documentation
p: Recipes require exact gram measurements and clear steps; Tips must include practical execution context.
li: 3
h4: Photography Guidelines
p: Include at least one authentic high-resolution photograph of the finished dish or technique step.
li: 4
h4: Open Eligibility
p: Everyone can participate — registered member or guest visitor.
li: 5
h4: Fair Judging
p: Chef James and the culinary evaluation committee review balance, innovation, and technique clarity. [SIDEBAR]

  ## SECTION
h2: Other Active Challenges
p: Expand your competitive footprint across botanical beverages, rustic sourdough ferments, and regional masterworks. Juices & Botanicals [hour
h3: Spring Herb & Botanical Infusions
p: Craft pristine botanical syrups, cold extract tonics, or herbal refreshers highlighting seasonal spring provenance. [redeem] Prize: Artisana
a: View Contest Details
a: Enter Now Italian & Bakery [hourglass_top] Ends in: 40 Days
h3: Artisan Sourdough & Ancient Grains Showcase
p: Demonstrate sourdough hydration mastery, wild levain fermentation cycles, and stone-ground heritage grain loaves. [redeem] Prize: Cast-Iron 
a: View Contest Details
a: Enter Now

  ## SECTION
p: Looking for previous champions?
a: View Past Winners [arrow_forward]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads `Contest` and `ContestSubmission` tables.

---

### Add Recipe - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-recipe-form`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`

**Visual Elements:**
```text
h1: Publish New Recipe
button: Preview Layout
button: Discard
h2: Core Information
label: Recipe Title
<input text 'e.g., Truffle-Infused Wild Mushroom Risotto'>
label: Category
<select  ''>
option: Fine Dining
option: Vegetarian
option: Pastry & Dessert
option: Juices & Elixirs
option: Italian Classics
label: Prep Time (mins)
<input number '25'>
label: Cooking Time (mins)
<input number '40'>
h2: Kitchencraft & Ingredients
label: Ingredients List (one per line) Include precise measurements
<textarea  '400g Carnaroli rice
1.2l rich vegetable stock
200g wild porcini mushrooms'>
label: Procedure & Technique Step-by-step instructions
<textarea  '1. Gently warm the stock in a separate pan...
2. Sauté shallots in extra virgin olive oil until translucent...'>
h2: Access Tier
p: Determine membership accessibility level for this publication.
<input radio ''>
<input radio ''>
h2: Featured Photography
<input file ''>
p: Click to upload image
p: SVG, PNG, JPG or WEBP (16:10 ratio recommended)
button: [publish] Publish Recipe
button: [save] Save Draft
```

**Business Logic:**
- Validate form inputs.
- If Guest trying to submit, redirect to Login/Register.
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Creates/Updates `Recipe` table.

---

### Add Recipe - Dashboard - JamesThew.com
**ID/Slug:** `dashboard-add-recipe`

**Image Paths:**
- `/images/uploaded-culinary-dish-preview-showing-finished-95aa79.jpg`

**Visual Elements:**
```text
h2: Publish New Creation [workspace_premium] Member Tier: Exclusive Premium Publication
label: Recipe Title
<input text 'e.g., Truffle Infused Wild Mushroom Risotto'>
label: Category
<select  ''>
option: Vegetarian
option: Non-Vegetarian
option: Italian
option: Juices & Elixirs [expand_more]
label: Preparation Time
<input text 'e.g., 25 mins'>
label: Cooking Time
<input text 'e.g., 40 mins'>
label: Ingredients List one ingredient per line
<textarea  '2 cups Carnaroli rice
400g fresh wild porcini mushrooms
1L warm vegetable stock
1/2 cup aged Parmigiano-Reggiano'>
label: Cooking Procedure one step per line
<textarea  'Gently warm the vegetable stock in a separate saucepan over low heat.
Sauté sliced wild mushrooms in extra virgin olive oil until golden brown.
Toast the Carnaroli rice dry in a heavy-bottomed pan before adding wine.
Gradually ladle warm stock into the rice while stirring continuously.'>
label: Recipe Imagery
<input file ''>
p: Drop your culinary photography here, or browse
p: High-resolution PNG, JPG or WEBP up to 10MB (16:10 ratio recommended)
button: [close] [info]
p: Publication Notice: All member-submitted recipes undergo sommelier and chef review before being published as Premium content within The Sanc
button: Cancel
button: [verified] Submit Recipe [lightbulb]
h3: Tips for a Great Recipe 1
p: Precise Measurements: Always specify exact weights and volumes (e.g., grams or milliliters) for baking and pastry items to ensure reproducib
p: Sensory Cues: In procedural steps, describe textures and aromas (e.g., "until edges turn golden amber and fragrant") rather than just cookin
p: Plating Suggestions: Add a brief final note on ideal glassware, dishware, or garnishes to elevate the member dining experience.
h4: [analytics] Your Contribution Stats 12 Published 99.4% Rating Score [task_alt] Recipe Submitted Successfully
p: Your recipe has been queued for chef review.
```

**Business Logic:**
- Validate form inputs.
- If Guest trying to submit, redirect to Login/Register.
- Only accessible to logged-in Members.
- Shows user-specific data (their submissions, favorites).

**DB Impact:**
- Creates/Updates `Recipe` table.

---

### Add Tip - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-tip-form`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`

**Visual Elements:**
```text
h1: Craft Master Tip
p: Share kitchen wisdom, techniques, and secret curation notes with the James Thew community. Formatted with Michelin-grade precision.
button: Save as Draft
button: [publish] Publish Tip
label: Tip Title *
p: A compelling title summarizing the technique or secret.
<input text 'e.g., The Secret to Achieving Perfect Glaze Emulsification'>
label: Category *
<select  ''>
option: Knife Skills & Prep
option: Sauces & Emulsions
option: Baking & Pastry
option: Heat Control & Searing
option: Plating & Aesthetics
label: Estimated Read / Practice Time
<input text 'e.g., 4 mins read'>
label: Description & Instructions * Markdown & HTML supported
p: Provide step-by-step guidance, scientific explanations, or chef's notes.
<textarea  'Detail the steps clearly. Mention temperatures, tools, and common pitfalls...'>
h2: Access Tier
p: Select who can view this tip content.
<input radio ''>
p: Available to all registered and guest members exploring James Thew kitchen insights.
<input radio ''>
p: Exclusive to subscribers and contest winners unlocking high-tier culinary secrets.
h2: Featured Image
p: Optional visual asset to accompany the tip. [add_photo_alternate] Click to upload image PNG, JPG, WEBP up to 10MB
a: Cancel
button: Publish Tip
```

**Business Logic:**
- Validate form inputs.
- If Guest trying to submit, redirect to Login/Register.
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Creates/Updates `Tip` table.

---

### Add Tip - Dashboard - JamesThew.com
**ID/Slug:** `dashboard-add-tip`

**Image Paths:** None specific

**Visual Elements:**
```text
h2: Publish a Professional Tip
p: Share your refined techniques, pairing secrets, or kitchen shortcuts with the community. Member-submitted tips are curated and published dir
label: Tip Title * [title]
<input text 'e.g., The Secret to Crystal-Clear Consomé Every Time'>
p: Craft a compelling, descriptive headline for your culinary insight.
label: Category * [category]
<select  ''>
option: Select kitchen domain...
option: Knife Skills & Prep
option: Sauces & Stocks
option: Baking & Pastry Precision
option: Heat Control & Searing
option: Plating & Presentation
option: Flavor Pairing & Seasoning [expand_more]
label: Tip Description & Methodology * [description]
<textarea  'Describe your technique step-by-step. Include the science, the exact conditions, and why this elevates the dish...'>
label: Demonstration Visual (Optional)
<input file ''>
p: Drag & drop visual evidence here
p: Supports high-res PNG, JPG, WebP up to 15MB Browse Files
a: Cancel
button: [publish] Submit Tip lg:col-span-4 space-y-6"> [workspace_premium]
h3: The Executive Standard
p: Tips published to The Sanctuary undergo peer review by our executive kitchen panel. Ensure your instructions are precise, reproducible, and 
h4: Your Tip Headline Appears Here
p: Category selection and short description will be indexed instantly upon successful submission. By Executive Chef (You) Pending Review [verif
p: Your submission is now queued for Premium archival review.
```

**Business Logic:**
- Validate form inputs.
- If Guest trying to submit, redirect to Login/Register.
- Only accessible to logged-in Members.
- Shows user-specific data (their submissions, favorites).

**DB Impact:**
- Creates/Updates `Tip` table.

---

### Announcements - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-announcements`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`

**Visual Elements:**
```text
h1: Announcements & Bulletins
p: Broadcast master-class updates, contest alerts, and winner laurels to the entire James Thew culinary community.
button: [add] New Announcement Active Bulletins 12 [trending_up] +2 this week [campaign] Total Reach 48.2k [group] Active subscribers [visibility] P
<input text 'Filter announcements...'>
<select  ''>
option: All Types
option: Winner
option: Update
option: New Contest Showing 4 of 12 entries
th: Type
th: Title & Excerpt
th: Publish Date
th: Actions [trophy]Winner Autumn Truffle Masterclass Winners Announced
p: Congratulations to Chef Elena Vance and Marcus Brody for their sublime execution of the reduction... Oct 24, 2023
button: [edit]
button: [delete] [bolt]New Contest The 2024 Winter Patisserie Open
p: Submit your most avant-garde chocolate soufflé or layered entremet for a chance to win the Master Knife set... Nov 02, 2023
button: [edit]
button: [delete] [update]Update Pantry Inventory & Sourcing Guidelines Update
p: We have refreshed our organic herb supplier list. Please check the resources tab for the latest certified local farms... Nov 14, 2023
button: [edit]
button: [delete] [update]Update Masterclass Schedule Revision for December
p: Live streaming times for the holiday roast session have been adjusted by 30 minutes to accommodate global attendees... Nov 20, 2023
button: [edit]
button: [delete] Page 1 of 3
button: Previous
button: 1
button: 2
button: 3
button: Next [campaign]
h2: New Announcement
button: [close]
label: Announcement Type
<select  ''>
option: Winner Announcement
option: Kitchen Update
option: New Contest Alert
label: Title
<input text 'e.g., Masterclass Special Edition...'>
label: Message
<textarea  'Compose your culinary bulletin...'>
<input checkbox ''>
button: Cancel
button: Publish
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads/Updates `Announcement` table.

---

### Announcements - JamesThew.com
**ID/Slug:** `announcements`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/gourmet-saffron-glazed-seabass-resting-on-shaved-e509e5.jpg`
- `/images/heirloom-hand-forged-7-piece-copper-cookware-col-9127d0.jpg`

**Visual Elements:**
```text
a: Home / Announcements Official Dispatches & Honors
h1: Announcements & Guild News
p: Official proclamations, seasonal contest winner announcements, and culinary academy updates directly from Chef James Thew.

  ## SECTION
h2: Farah Al-Sayed
p: Winning Formulation: “Saffron Spiced Seabass with Fennel & Meyer Lemon Glaze” [format_quote] “A breathtaking display of heat control and aci
a: View Winning Recipe Details
a: View Full Honor Roll [arrow_forward] Chronological Guild Log [flag] New Contest Feb 28, 2026
h3: Monthly Master Challenge: Best Italian Recipe or Summer Juice Tip Now Open
p: Submissions have officially commenced for this season's dual-track challenge. Members and aspiring home gourmets are invited to file their s
a: Read Full Guidelines [arrow_forward] [notifications] Update Feb 20, 2026
h3: Spring 2026 Weekend Cookery Classes: Schedule & Syllabi Released
p: Registration is now unlocked for hands-on, weekend culinary immersions hosted at the Culinary Suite in Karachi. The upcoming term concentrat
a: Read More [arrow_forward] [emoji_events] Winner Jan 31, 2026
h3: January 2026 Champion: Hand-Folded Agnolotti with Charred Thyme
p: The evaluation guild salutes Marco Valenti for his masterclass in artisanal pasta dough lamination. His delicate pine nut and goat curd fond
a: Read More [arrow_forward] [notifications] Update Jan 15, 2026
h3: Haute Cuisine Recipe Vault Expansion: 12 New Plant-Based Formulations Added
p: Chef James has formally released a curated anthology of plant-forward gastronomy, highlighting cold-press botanical emulsions, clarified roo
a: Read More [arrow_forward]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads/Updates `Announcement` table.

---

### Chef James - About - JamesThew.com
**ID/Slug:** `about-chef-james`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/chef-james-thew-portrait-061708.jpg`
- `/images/dark-emerald-book-cover-design-featuring-golden-570694.jpg`
- `/images/opulent-culinary-cookbook-cover-titled-botanica-c4ed26.jpg`
- `/images/sophisticated-cookbook-cover-with-elegant-serif-518764.jpg`
- `/images/dramatic-dynamic-kitchen-shot-of-chef-james-sear-70a0b1.jpg`
- `/images/extreme-close-up-macro-of-an-exquisite-michelin-09ca9c.jpg`
- `/images/vibrant-top-down-view-of-an-antique-karachi-spic-a81f0d.jpg`
- `/images/artisanal-sourdough-dough-kneading-and-hand-roll-e5386d.jpg`
- `/images/chef-james-thew-smiling-warmly-in-a-dark-green-a-c439c1.jpg`

**Visual Elements:**
```text
## SECTION
a: Home / About / Chef James

  ## SECTION
p: Executive Residence
p: Mövenpick & Luxury Suites [stars] Master of Modern Gastronomy
h1: James Thew
p: 5-Star Hotel Chef • Cookbook Author • TV Recipe Show Host
p: Pioneering sensory dining through the lens of heritage terroir and artisanal modernism. Over two decades spearheading luxury culinary operat

  ## SECTION
h2: Heritage, Discipline & The Five-Star Standard
p: Trained across iconic classical brigades and modern European kitchens, Chef James brought his rigorous international discipline to Pakistan’
p: His craft relies on ancestral techniques—slow coal embers, botanical macerations, and handcrafted stocks—recast through ultra-modern culinar
h2: Screen, Ink & Community Academy
p: Beyond luxury dining rooms, Chef James became a household mentor through his high-ratings national television series, demystifying complex f
p: His published volumes have earned international praise, chronicling centuries of aromatic subcontinental marinades, restorative raw juice fo

  ## SECTION
h3: Executive Chef & Culinary Director • Mövenpick Hotel Karachi
p: Leading culinary operations spanning 5 luxury outlets, premier banqueting halls, and private head-of-state diplomatic dinners. Spearheaded t
h3: Host & Lead Chef • “The Master’s Hearth” (National Prime-Time TV)
p: Produced and hosted over 180 episodes of prime-time weekend cooking pedagogy. Welcomed guest celebrity restaurateurs, conducted regional ing
h3: Chef de Cuisine • Pearl Continental Luxury Suites
p: Commanded signature Italian and Continental dining rooms. Curated bespoke botanical juice pairings and introduced organic cold-press menu ar
h3: Cookbook Author & Culinary Research Scholar
p: Authored three internationally reviewed monographs detailing heirloom sauce science, whole-plant gastronomy, and modern artisanal pastry str

  ## SECTION
h2: Published Cookbooks
p: Comprehensive master volumes blending historical documentation with exact brigade formulations for ambitious home gourmands. 2021 • 1st Edit
h3: The Five-Star Pantry
p: Foundational master sauces, slow reductions, aromatic braises, and secret kitchen prep doctrines used by five-star brigade executives. 320 P
h3: Botanica & Flame
p: A deep dive into high-end vegetarian cookery, cold-pressed living juices, and charcoal-kissed organic root disciplines. 284 Pages • Illustra
h3: The Silk & Olive Path
p: Classical Italian pasta mechanics enriched with subcontinental spices, botanical tinctures, and coastal seafood alchemy. 350 Pages • Collect

  ## SECTION
h2: Awards & Culinary Honors [military_tech] National Hospitality Circle • 2022
h3: Culinary Master of the Year
p: Awarded for outstanding standard-bearer leadership across luxury five-star operations and championing modern Pakistani gastronomy. [tv_gen] 
h3: Top Culinary Media Personality
p: Honored for elevating home culinary education and inspiring a generational surge in amateur and professional foodcraft. [school] Karachi Cul
h3: Brigade Mentorship Medal
p: Recognized for graduating over 150 sous chefs into executive restaurant roles across Europe, the Middle East, and South Asia.

  ## SECTION
h2: Craft, Passion & Kitchen Mastery Behind The Pass Live Brigade
h4: High-Heat Pan Sear • Service Pass
h4: Artisanal Botanical Plating
h4: Spice Market Selection
h4: Handcrafted Pasta Mechanics Masterclass
h4: Weekend Cookery Academy Demo

  ## SECTION
h2: Experience Haute Cuisine at Home
p: Join Chef James Thew's culinary inner circle. Unlock step-by-step masterclasses, tested hotel recipes, and personalized mentoring.
a: Join Now
a: Browse Free Recipes
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Contact Us - Help - JamesThew.com
**ID/Slug:** `contact`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/contact-img-12baab.png`

**Visual Elements:**
```text
a: Home
li: [chevron_right]
li: Help
li: [chevron_right]
li: Contact Us Academy Concierge & Inquiries
h1: Contact Chef James Thew
p: Inquire about Weekend Cookery Classes, culinary academy enrollment, contest adjudication, or press engagements. [location_on] Culinary Suite
p: Weekend in-person classes held here [mail] Electronic Inquiries
a: contact@jamesthew.com
p: General response within 24–48 hours [phone] Academy Desk +92 (21) 358X-XXXX
p: Available Tuesday to Sunday, 10 AM – 6 PM PKT [restaurant] Chef James Thew Culinary Suite • Karachi [pin_drop]
p: Suite 4B, Clifton Coastal Enclave, Karachi, Pakistan
p: Follow Chef James & The Academy
a: [public] Facebook
a: [photo_camera] Instagram
a: [play_circle] YouTube
a: [workspace_premium] LinkedIn
h2: Send an Inquiry
p: Our culinary concierge will attend to your request promptly.
label: Name
<input text 'e.g. Eleanor Rigby'>
label: Email
<input email 'e.g. eleanor@domain.com'>
label: Subject
<input text 'e.g. Weekend Class Enrollment Inquiry'>
label: Message
<textarea  'Describe your inquiry, workshop date preference, or question in detail...'>
button: Send Message [send] [verified_user]
p: We respect your privacy. No promotional spam will ever be sent. [check_circle] Inquiry Dispatched Chef James's academy team will respond wit
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Cookery Classes - About - JamesThew.com
**ID/Slug:** `about-classes`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/artisanal-cold-pressed-botanical-juices-clarifyi-2bc7cb.jpg`
- `/images/gourmet-roasted-heirloom-vegetables-caramelized-5bdc19.jpg`
- `/images/a-sizzling-thick-cut-dry-aged-steak-resting-alon-924634.jpg`
- `/images/handcrafted-fresh-tagliatelle-pasta-tossed-in-ag-6c7b12.jpg`
- `/images/about-classes-img-87cf20.jpg`
- `/images/about-classes-img-2070ec.png`

**Visual Elements:**
```text
## SECTION
a: Home [chevron_right] About [chevron_right] Cookery Classes [workspace_premium] Haute Cuisine Guild • Weekend Series
h1: Weekend Cookery Classes with Chef James
p: Learn signature recipes near home at affordable fees. Step behind the line into an artisanal kitchen laboratory tailored for home gourmets a
a: Contact Us to Enrol [arrow_forward] [verified] Bespoke small batches • Intimate practical guidance

  ## SECTION
h2: Why Cook with Chef James
p: Stripping away high-strung restaurant pretension in favor of pure technical mastery and welcoming, sensorial exploration. [skillet]
h3: Hands-on learning
p: Command your own fully equipped culinary station. No passive slide decks; prepare, cook, and plate every dish from scratch. Active Knife & F
h3: Affordable fees
p: Michelin-informed techniques distilled into structured community masterclasses at subsidized, accessible local tuition rates. Pantry & Tool 
h3: Learn from Chef James
p: Gain personal mentorship from a 5-star hotel chef and cookbook author, unraveling fine-dining seasoning heuristics. Personal Critique & Insi
h3: Share your feedback
p: Every masterclass culminates in communal tasting rounds, constructive peer critique, and direct dialogue with the chef. Open Guild Discussio

  ## SECTION
h2: Course Concentrations
p: Focused single-session weekend intensives targeting quintessential kitchen methodologies and flavor profiles. [local_offer] Low fee Mixology
h3: Artisanal Juices & Tonics
p: Cold-pressing, clarifying herbal reductions, natural fermentation, and craft botanical spritzers balanced for digestive elegance. [timer] 2.
h3: Vegetarian Gastronomy
p: Elevating humble roots, pulses, and greens using French braising, umami reduction stocks, and modern emulsification. [timer] 3.5 Hours Satur
h3: Non-Vegetarian Mastery
p: Mastering protein thermodynamics, pan-basting with clarified butter and thyme, artisanal jus reductions, and carving etiquette. [timer] 4.0 
h3: Authentic Italian Classics
p: Zero-machine egg yolk pasta dough, rolling silk-thin sheets, silky carbonara emulsification, and slow-simmered regional ragù. [timer] 3.5 Ho

  ## SECTION
h2: Weekend Schedule
p: Class routines conducted consistently every Saturday and Sunday at the Culinary Suite.
th: Day & Time
th: Course Name
th: Category
th: Core Focus Topic
th: Delivery Mode SAT 09:30 AM – 12:00 PM Botanical Elixirs & Cold Presses Juices Enzymatic preservation, herbal extraction, zero-sugar shrubs L

  ## SECTION
h3: Affordable Fee Details
p: Chef James believes fine cuisine technique should be attainable to all serious enthusiasts. Our fees are kept deliberately low to cover only
h3: Culinary Suite, Karachi
p: Conveniently situated in the central culinary enclave, offering a high-spec stainless kitchen environment designed for immersive weekend mas

  ## SECTION
h3: Essential Notes for Attendees
p: Ensure an optimal workshop experience by reviewing our house standards prior to your weekend arrival. [check_circle] Station Uniform Provide

  ## SECTION
h2: Ready to master the craft with Chef James?
p: Inquire regarding forthcoming weekend dates, course syllabus downloads, or cohort arrangements directly through our concierge.
a: Contact Us to Enrol [send]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Entries & Winners - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-entries`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`
- `/images/portrait-of-an-enthusiastic-home-cook-smiling-in-d72d7e.jpg`
- `/images/portrait-of-a-passionate-culinary-enthusiast-wea-a35cd8.jpg`
- `/images/portrait-of-a-young-culinary-student-focused-on-ade404.jpg`

**Visual Elements:**
```text
h1: Entries & Winners
<select  ''>
option: Autumn Truffle & Wild Mushroom Showdown (Active)
option: Heritage Heirloom Tomato Masterclass (Closed)
option: Artisanal Sourdough & Fermentation Cup (Upcoming) [expand_more] Submitted Entries (24) Sort by:
button: Newest Recipe Submitted Oct 24, 2023
<input radio ''>
h3: Pan-Seared Duck Breast with Blackberry Reduction Clara Oswald Member
p: Key Ingredients Preview:
p: Free-range duck breast, fresh blackberries, aged balsamic vinegar, shallots, rosemary sprigs, unsalted butter, microgreens.
button: View Full Entry [chevron_right] [star] 4.9 (42 votes) Tip Submitted Oct 25, 2023
<input radio ''>
h3: The Secret to Mirror-Glazed Chocolate Ganache Marcus Vance Guest
p: Key Procedure Preview:
p: Always strain your warm ganache through a fine-mesh sieve twice before application to eliminate micro-bubbles and achieve absolute gloss.
button: View Full Entry [chevron_right] [star] 4.8 (38 votes) Recipe Submitted Oct 26, 2023
<input radio ''>
h3: Truffle Infused Risotto with Wild Porcini Elena Rostova Member
p: Key Ingredients Preview:
p: Arborio rice, fresh porcini mushrooms, black truffle oil, Parmigiano-Reggiano 24-month, shallots, dry white wine, vegetable stock.
button: View Full Entry [chevron_right] [star] 4.7 (29 votes)
h2: [trophy] Announce Winner Panel Ready to Publish Selected Winner
h4: The Secret to Mirror-Glazed Chocolate Ganache
p: Submitted by Marcus Vance (Guest)
label: Chef James's Commendation Note
<textarea  'Write a personal note praising this winning entry...'>
p: “Marcus demonstrated exceptional technique here. The attention to temperature control and the patience to strain twice elevates a home kitch
button: [campaign] Publish Winner Announcement [check_circle]
p: Winner Announcement Published!
p: Notifications have been dispatched to all members.
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads static or CMS data.

---

### FAQ - Help - JamesThew.com
**ID/Slug:** `faq`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`

**Visual Elements:**
```text
a: Home [chevron_right] Help [chevron_right] FAQ Knowledge Base & Guidance
h1: Frequently Asked Questions
p: Everything you need to know about membership tiers, recipes, tip exchanges, contest rules, and academy access. [search]
<input text 'Search questions, membership rules, contest policies...'>
button: All Questions
button: Membership & Pricing
button: Recipes & Tips
button: Contests
button: Feedback
button: 01 How to become the member of this site? expand_more
p: Click ‘Join Now’ on any page or navigation bar, select your preferred pass (Monthly at $10/month or Yearly at $100/year), complete the secur
button: 02 Will there be any subscription charges? expand_more
p: Yes. We offer two transparent subscription passes: Monthly ($10) or Yearly ($100, saving $20) for full catalog access and exclusive executiv
button: 03 How to view the recipes and tips? Will there be any charges for that? expand_more
p: Free recipes and tips can be explored freely without charge or registration by visiting the Free Recipes and Free Tips sections. The full pr
button: 04 I am not the registered member of the site. Can I participate in the contest held? expand_more
p: Yes, general users and guests can participate freely by submitting their original recipes or tips to any active contest. Our culinary challe
button: 05 How to upload or post the recipes and tips? expand_more
p: Logged-in members can simply use the ‘+ Add Recipe’ or ‘+ Add Tip’ actions accessible directly from their member dashboard or the recipe lib
button: 06 How to post a feedback? expand_more
p: You can post recipe feedback and tasting notes directly on each individual recipe page under the ‘Community Feedback’ section. For overall w
button: 07 I have posted a recipe or a tip with respect to the contest. How can I know who is the winner? expand_more
p: Contest winners are officially announced on the Announcements page and archived in Past Winners following comprehensive review and adjudicat
p: Can't find the answer you're looking for? Reach out directly to our academy support desk and concierge.
a: Contact Us
a: Give Feedback [FOOTER]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Feedback - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-feedbacks`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`

**Visual Elements:**
```text
p: Average Rating 4.8 / 5.0 [star]
p: Total Feedback 1,284 [forum]
p: Positive Sentiment 94% [trending_up]
button: Recipe Feedback
button: Site Feedback [search]
<input text 'Search feedback...'>
<select  ''>
option: All Ratings
option: 5 Stars
option: 4 Stars
option: 3 Stars & Below
<select  ''>
option: Latest First
option: Oldest First
th: User
th: Recipe Name
th: Rating
th: Comment Excerpt
th: Date
th: Actions Showing 1-5 of 1,284 entries
button: Previous
button: 1
button: 2
button: 3
button: Next
button: [close]
h3: Feedback Details User
p: Chef Eleanor Vance (eleanor@example.com) Recipe
p: Truffle Infused Risotto Rating [star] [star] [star] [star] [star] Full Comment
p: "The balance of the truffle oil with the Carnaroli rice was masterclass. I followed Chef James's tip on continuous stock addition and it tur
p: October 24, 2023 • 14:32 EST
button: Close
button: Delete Feedback
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads `Feedback` table.

---

### Forgot Password - JamesThew.com
**ID/Slug:** `forgot-password`

**Image Paths:**
- `/images/intense-portrait-of-executive-chef-james-thew-in-5f6208.jpg`
- `/images/forgot-password-img-9a1fc8.jpg`

**Visual Elements:**
```text
a: [restaurant_menu] JamesThew .com Haute Cuisine Sanctuary Kitchen Closed • Private Access Chef's Note “Precision is born in patience. When he
a: [restaurant_menu] JamesThew .com
a: [arrow_back] Login
button: 1. Request Form
button: 2. Confirmation Preview

  ## SECTION
h1: Reset your password
p: Enter the email associated with your JamesThew.com account and we'll send you an encrypted reset link.
label: Email Address [mail]
<input email 'chef.patron@domain.com'>
button: Send Reset Link [arrow_forward]
a: [arrow_back] Back to Login

  ## SECTION
h2: Check your email
p: We have dispatched password recovery instructions to your email address . Please inspect your inbox and spam folder. [info]
p: For security reasons, this single-use authentication key will expire precisely after 15 minutes.
button: [replay] Did not receive? Resend Link
a: [login] Return to Login
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Free Recipes - Recipes - JamesThew.com
**ID/Slug:** `recipes-free`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/recipes-free-img-d981a1.jpg`
- `/images/recipes-free-img-8b5875.jpg`
- `/images/recipes-free-img-7a7e39.jpg`
- `/images/recipes-free-img-bf42fd.jpg`
- `/images/recipes-free-img-36689f.jpg`
- `/images/recipes-free-img-fb1f76.jpg`
- `/images/recipes-free-img-5739ee.jpg`
- `/images/recipes-free-img-b92741.jpg`

**Visual Elements:**
```text
## SECTION
a: Home [chevron_right] Recipes [chevron_right] Free Recipes [lock_open] Open Access Sanctuary
h1: Free Recipes by Chef James
p: No registration needed. Meticulously tested Michelin-grade foundational techniques, broths, and platings curated for passionate home gourman
button: All
button: Juices
button: Vegetarian
button: Non-Vegetarian
button: Italian [ search ]
<input text 'Search ingredients, methods...'>
button: [bookmark] By Chef James Thew [star] 4.9
h2: Emerald Green Detox Elixir [schedule] 15 mins
a: View [arrow_forward] Free Vegetarian
button: [bookmark] By Chef James Thew [star] 4.8
h2: Smoked Aubergine & Pomegranate Risotto [schedule] 40 mins
a: View [arrow_forward] Free Non-Veg
button: [bookmark] By Chef James Thew [star] 5.0
h2: Karachi Spiced Pan-Seared Snapper [schedule] 30 mins
a: View [arrow_forward] Free Italian
button: [bookmark] By Chef James Thew [star] 4.9
h2: Hand-Rolled Truffle Tagliatelle [schedule] 25 mins
a: View [arrow_forward] Free Juices
button: [bookmark] By Chef James Thew [star] 4.7
h2: Cold-Pressed Citrus & Mint Spritz [schedule] 10 mins
a: View [arrow_forward] Free Vegetarian
button: [bookmark] By Chef James Thew [star] 4.9
h2: Saffron Wild Mushroom Polenta [schedule] 35 mins
a: View [arrow_forward] Free Non-Veg
button: [bookmark] By Chef James Thew [star] 5.0
h2: Slow-Braised Tamarind Lamb Shank [schedule] 2 hrs
a: View [arrow_forward] Free Italian
button: [bookmark] By Chef James Thew [star] 4.9
h2: Heritage Roasted Tomato Rigatoni [schedule] 20 mins
a: View [arrow_forward]
a: [chevron_left] Previous
a: 1
a: 2
a: 3
a: Next [chevron_right] [workspace_premium] The Chef's Inner Cellar
h3: Want the full premium collection? Join Now
p: Unlock over 400+ secret reserve preparations, sous-vide temperature guides, live tasting notes, and direct quarterly culinary critiques from
a: Join Now ($10/mo)
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads `Recipe` table.

---

### Free Tips - Tips & Tricks - JamesThew.com
**ID/Slug:** `tips-free`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/tips-free-img-cfbf1b.jpg`

**Visual Elements:**
```text
a: Home / Tips & Tricks / Free Tips Open Culinary Knowledge
h1: Free Cooking Tips & Tricks
p: Practical, chef-tested kitchen wisdom, foundational knife skills, and seasoning secrets accessible to all. 48 Open Guides 100% Complimentary

  ## SECTION
<input search 'Search foundational techniques, oils, pans...'>
button: All
button: Juices
button: Vegetarian
button: Non-Vegetarian
button: Italian

  ## SECTION
h2: The Secret to Crystal-Clear Citrus Clarification
p: Using gentle agar-agar freeze-thaw cycles or quick milk-washing allows pristine enzymatic sediment binding without losing bright floral terp
a: Read Tip [arrow_forward] [lightbulb] Vegetarian Free
h2: Tempering Whole Spices in Cold-Pressed Mustard Oil
p: Mastering the exact smoke threshold neutralizes pungent isothiocyanates into warm, nutty aromatics while preserving delicate black mustard e
a: Read Tip [arrow_forward] [lightbulb] Vegetarian Free
h2: Retaining Vibrant Chlorophyll in Blanched Greens
p: Rapid thermal shock in heavily salted rolling water followed by an aggressive ice-bath stops chlorophyll conversion into dull pheophytin. Ch
a: Read Tip [arrow_forward] [lightbulb] Italian Free
h2: Emulsifying Pan Sauces with Ice-Cold Unsalted Butter
p: Monte al banco: Whisking cubes straight from the freezer off direct heat forces dairy solids and water to encapsulate pan fond without break
a: Read Tip [arrow_forward] [lightbulb] Non-Vegetarian Free
h2: Resting Meat on Warm Salt Tile Racks
p: Allowing seared proteins to relax over warm Himalayan blocks ensures muscle fibers reabsorb precious cellular juices without losing skin cri
a: Read Tip [arrow_forward] [lightbulb] Italian Free
h2: Balancing Acidity with Charred Lemon Zest
p: Blistering citrus skins under extreme broil converts harsh citric acidity into deep caramel-bitter notes, lending unmatched finish to heavy 
a: Read Tip [arrow_forward]
button: Previous
button: 1
button: 2
button: 3
button: Next
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads `Tip` table.

---

### Give Feedback - Help - JamesThew.com
**ID/Slug:** `feedback-site`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/feedback-site-img-3930f2.jpg`

**Visual Elements:**
```text
a: Home /
a: Help / Give Feedback [check]
p: Thank you! Your feedback has been received and forwarded to Chef James's team.
button: [close] Community Reflections & Suggestions
h1: Share Your Site Feedback
p: Help us refine JamesThew.com. Your impressions guide our culinary platform, recipes, and workshop experience.

  ## SECTION
h2: Tell us about your experience
p: Every detail matters in fine gastronomy and thoughtful digital craft. Community feedback directly shapes our seasonal recipe development, na
p: “The step-by-step procedure layout and temperature guidelines have transformed my weekend sauces. The new dark design is stunning.” 2 days a
p: “Participated in the monthly contest for the first time as a guest. The submission process was seamless and welcoming.” 1 week ago Zoya M. L
p: “Love the botanical elixirs section. Would love to see even more fermented vinegar and kombucha guides.” 2 weeks ago [help_outline]
p: Have a specific question? Visit our
a: FAQ or
a: Contact Us directly.

  ## SECTION
label: Your Name
<input text 'e.g. Tariq Mansoor'>
label: Email Address
<input email 'e.g. tariq@domain.com'>
label: Subject
<input text 'e.g. Suggestion regarding recipe filters'>
label: Feedback Category
<select  ''>
option: Design
option: Content
option: Recipes
option: Contests
option: Other [expand_more]
label: Overall Rating Select rating
button: [star]
button: [star]
button: [star]
button: [star]
button: [star]
label: Comments
<textarea  'Tell us what you loved, what could be improved, or any features you'd like to see...'>
p: Your feedback is read directly by our culinary and administrative staff.
button: Submit Feedback [arrow_forward]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Creates `Feedback` table.

---

### Home - JamesThew.com
**ID/Slug:** `home`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/professional-portrait-of-chef-james-thew-d3c305.jpg`
- `/images/home-img-3628b4.jpg`
- `/images/home-img-c21cae.jpg`
- `/images/home-img-cf62ca.jpg`
- `/images/home-img-976625.jpg`
- `/images/home-img-e15c13.jpg`
- `/images/home-img-f684e3.jpg`
- `/images/home-img-4dbc6c.jpg`
- `/images/home-img-d9756b.jpg`
- `/images/home-img-73c31e.jpg`
- `/images/home-img-8f1536.jpg`

**Visual Elements:**
```text
## SECTION
h1: Master Culinary Arts with 5-Star Chef James Thew
p: Specializing in Juices, Vegetarian, Non-Vegetarian & Italian Cuisines. Elevate your palate with Michelin-grade technique, disciplined kitche
a: Join Now ($10/mo)
a: Browse Free Recipes

  ## SECTION

  ## SECTION
h2: Chef James Thew
p: Distinguished 5-star hotel executive chef in Karachi, celebrated culinary author, and acclaimed national television cooking show host. Chef 
p: Through this sanctuary, James dismantles the guarded secrets of fine dining, empowering home gourmands to produce restaurant-grade sauces, a
a: Read Full Profile [arrow_forward]

  ## SECTION
h3: Join Chef James's Weekend Cookery Classes near home at affordable fees!
p: Hands-on culinary workshops covering gourmet prep, knife skills, and authentic plating right in Karachi. Limited bench spaces per session.
a: View Class Details

  ## SECTION
h2: Featured Free Recipes
p: Chef-crafted culinary guides accessible to everyone.
a: View All Free Recipes [east] Free [timer] 15 mins Juices [star] 4.9
h3: Juicy Citrus & Mint Revitalizer
p: Cold-pressed tonic balancing zesty blood oranges, wild peppermint infusion, and Himalayan black salt mineral notes. By Chef James
a: View Recipe [chevron_right] Free [timer] 35 mins Vegetarian [star] 5.0
h3: Smoked Aubergine & Pomegranate Risotto
p: Charred brinjal pulp folded through creamy carnaroli rice, finished with cold-pressed olive oil and tart jewels. By Chef James
a: View Recipe [chevron_right] Free [timer] 30 mins Non-Vegetarian [star] 4.8
h3: Karachi Spiced Pan-Seared Snapper
p: Fresh Arabian Sea snapper rendered in a cast iron skillet with toasted cumin crust and fresh curry leaf butter. By Chef James
a: View Recipe [chevron_right] Free [timer] 45 mins Italian [star] 4.9
h3: Hand-Rolled Truffle Tagliatelle
p: Heritage egg yolk pasta rolled paper-thin, swirled in cultured butter mantecatura and Piedmont black truffle shavings. By Chef James
a: View Recipe [chevron_right]
a: View All Free Recipes [east]

  ## SECTION
h2: Explore Culinary Disciplines
p: Precision recipes structured around James Thew’s core areas of restaurant specialization.
a: [local_drink]
h3: Juices
p: Cold-pressed elixirs, seasonal blends, and cellular wellness detoxes.
a: [spa]
h3: Vegetarian
p: Artisanal plant-based entrees, hearty grains, and fragrant farm herbs.
a: [kebab_dining]
h3: Non-Vegetarian
p: Prime cuts, coastal seafood, and traditional slow-cooked braises.
a: [dinner_dining]
h3: Italian
p: Authentic fresh pasta, wood-fired sauces, and classic antipasti.

  ## SECTION
h2: Monthly Master Chef Challenge: Artisan Seafood & Pasta Fusion
p: Submit your signature dish unifying handmade pasta dough with coastal Karachi seafood elements. Judged personally by Chef James on balance, 
p: Grand Prize: $500 Kitchen Aid Set + 1-on-1 Masterclass with Chef James
a: Participate Now
a: Read Rules Hall of Honor [military_tech] Victor [workspace_premium] Winner — March 2026 Challenge
h3: Farah Al-Sayed
p: Amateur Gourmet Division Winning Submission:
p: “Saffron Spiced Seabass with Fennel Glaze”
a: See Announcements [east]

  ## SECTION
h2: Member Experiences & Praise
p: Reflections from enthusiastic home cooks and aspiring culinary apprentices. [star] [star] [star] [star] [star]
p: “Chef James's masterclasses completely demystified Italian sauces. My dinner parties have never been the same! The depth of flavor we achiev
p: “The step-by-step video instructions and knife technique tips are worth ten times the monthly membership. Being able to pause and reproduce 
p: “Entering the weekly contests gave me the confidence to cook gourmet dishes I used to think were impossible. The feedback loop from fellow m

  ## SECTION
h2: Unlock the Full Culinary Academy
p: Access private reserves, advanced technique breakdowns, and direct master evaluation.
h3: Monthly Pass Standard $10 / month
li: [check_circle] Access all 50+ premium recipes and ingredient charts
li: [check_circle] Exclusive chef tips and knife care tutorials
li: [check_circle] Weekly contest entry submissions & peer voting
li: [check_circle] Priority reservations & discounts on Weekend Classes
a: Get Monthly Pass
h3: Yearly Academy Pass Best Value (Save $20) $100 / year
li: [verified] All monthly perks (recipes, tips, weekly contests)
li: [verified] Direct personal critique from Chef James on your recipe submissions
li: [verified] Official Academy Annual Masterclass Certificate
li: [verified] Guaranteed bench seating discount at Karachi Masterclass studio
a: Get Yearly Pass
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Home - JamesThew.com (Mobile)
**ID/Slug:** `home-mobile`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/home-mobile-img-4562b5.jpg`
- `/images/home-mobile-img-a8d91e.jpg`
- `/images/home-mobile-img-5860de.jpg`

**Visual Elements:**
```text
## SECTION
h1: Bonjour, Chef.
p: Precision kitchencraft and nocturnal fine dining at your fingertips.

  ## SECTION
button: All Masterpieces
button: Free Recipes
button: Premium Recipes
button: Knife Skills
button: Pastry & Art

  ## SECTION

  ## SECTION
h2: The Autumn Truffle Challenge
p: Submit your most innovative root vegetable pairing for a private virtual critique with Chef James.
button: Enter Submission

  ## SECTION
h3: The Art of the Nocturnal Reduction
p: Master deep aromatic stocks, Madeira glazes, and the delicate chemistry of glossy pan sauces. Included in All-Access
button: Watch Session

  ## SECTION
h2: Latest Publications View All Free Recipe
h4: Pan-Seared Diver Scallops with Parsnip Velouté
p: Crisp caramelization meets silken earthiness in this masterclass appetizer. Prep: 25 mins Read Method Premium
h4: Valrhona Grand Cru Soufflé
p: An impeccable rise paired with Tahitian vanilla bean crème anglaise. Prep: 40 mins Unlock Recipe
button: Join Now & Unlock All-Access [arrow_forward] JamesThew.com
button: [close]
a: Home
a: About Chef James
a: Recipes & Archives
a: Tips & Tricks
a: Contests
a: Announcements
a: Help & Support
a: Login
button: Join Now
a: [home] Home
a: [restaurant_menu] Recipes
a: [school] Classes
a: [person] Profile
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Join Now - Registration & Membership - JamesThew.com
**ID/Slug:** `register`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/close-up-portrait-of-chef-james-thew-in-formal-d-66586e.jpg`

**Visual Elements:**
```text
## SECTION
h1: Member Registration & Enrolment
p: Complete your membership to unlock master-tier kitchencraft, secluded techniques, and seasonal competitions.
button: [check] 1. Account Details Verified Profile
button: 2 2. Choose Plan Annual Recommended
button: 3 3. Payment Simulated Gate
h2: Account Credentials [lock] Private & Shielded
label: Full Name * [badge]
<input text 'Chef / Gastronome Name'>
label: Email Address * [mail]
<input email 'you@domain.com'>
label: Phone Number [call]
<input tel '+1 (555) 000-0000'>
label: Create Password * [key]
<input password ''>
button: [visibility] Password Strength: Strong
label: Confirm Password * [verified_user]
<input password ''>
button: [visibility]
p: [check_circle] Passwords match 02
h2: Select Membership Tier [bolt] Flexible Enrollment
<input radio ''>
label: Monthly Regular $10 / month
p: Includes full access to all premium recipes, monthly culinary tips, and member discussions. [sync] Renews monthly, cancel anytime [workspace
<input radio ''>
label: Yearly Save $20 $100 / year
p: Unrestricted mastery access, archive secrets, and automatic entry to every quarterly competition. [verified] 2 months free equivalent 03
h2: Simulated Payment [lock] Encrypted Sandbox Mode [info]
p: Demo payment: No real charge will occur. Pre-populated test numbers are simulated.
label: Card Number [credit_card]
<input text ''>
label: Expiry Date [calendar_today]
<input text 'MM/YY'>
label: CVV / CVC [shield]
<input password 'CVC'>
label: Postal Code [pin_drop]
<input text ''>
<input checkbox ''>
label: I agree to the
a: Terms & Conditions and
a: Privacy Policy of JamesThew.com Haute Cuisine Academy.
button: [verified] Complete Registration [SIDEBAR] [FOOTER]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Login - JamesThew.com
**ID/Slug:** `login`

**Image Paths:**
- `/images/login-img-05d991.jpg`

**Visual Elements:**
```text
## SECTION
a: [arrow_back] Return to JamesThew.com
h1: Welcome Back
p: Sign in to access your saved recipes, secret tips, and masterclass notebook.
label: Email Address [mail]
<input email 'chef.theodore@domain.com'>
label: Password [lock]
<input password '••••••••••••'>
button: [visibility]
<input checkbox ''>
a: Forgot Password?
button: Login to Kitchen [arrow_forward]
p: New to James Thew?
a: Join Now [lock_person] Secure 256-Bit Encrypted Gastronomy Portal
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Manage Contests - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-contests`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`
- `/images/close-up-of-a-magnificent-gourmet-autumn-pumpkin-3ccee6.jpg`
- `/images/artisanal-sourdough-bread-loaf-cut-in-half-showi-69f348.jpg`
- `/images/a-professional-culinary-knife-sharpening-stone-w-dddbb6.jpg`
- `/images/handcrafted-artisanal-cocktails-in-crystal-glass-018ced.jpg`

**Visual Elements:**
```text
h1: Manage Contests
p: Curate seasonal challenges, monitor community participation, and distribute prestigious culinary accolades.
button: [add] Create Contest Active Contests 04 +1 this week Total Submissions 1,284 +18% vs last Prize Pool Distributed $12,450 8 Contests Particip
button: All Contests (8)
button: Active (4)
button: Closed (4) [filter_list]
<select  ''>
option: Sort by Deadline
option: Sort by Entries
option: Sort by Title
th: Contest Title
th: Category
th: Timeline
th: Status
th: Entries
th: Actions Autumn Truffle & Squash Masterclass
p: Prize: $1,500 + Copper Cookware Set Recipe Oct 01 — Nov 15 3 days left Active 342
button: View Entries
button: Close
button: [delete] The Art of Fermentation & Sourdough
p: Prize: Professional Proofing Basket & Knife Set Both Oct 15 — Nov 30 18 days left Active 518
button: View Entries
button: Close
button: [delete] Kitchen Knife Skills & Safety Tips
p: Prize: Damascus Steel Chef Knife Tip Sep 01 — Oct 01 Ended Closed 244
button: View Entries
button: Closed
button: [delete] Botanical Infusions & Elixirs
p: Prize: Master Mixology Kit Recipe Nov 01 — Dec 15 Starts soon Upcoming 0
button: View Entries
button: Close
button: [delete] Showing 1 to 4 of 8 total contests
button: Previous
button: 1
button: 2
button: Next [trophy]
h2: Create New Contest
button: [close]
label: Contest Title
<input text 'e.g., Holiday Pastry & Confection Showcase'>
label: Category
<input radio ''>
<input radio ''>
<input radio ''>
label: Description & Requirements
<textarea  'Detail the guidelines, key ingredients, preparation standards, and evaluation criteria for participating chefs...'>
label: Prize Details
<input text 'e.g., $1,000 Cash Prize + Chef James Thew Signature Knife'>
label: Start Date
<input date ''>
label: Deadline
<input date ''>
label: Cover Imagery Prompt
<input text 'Describe contest promotional image...'>
button: Cancel
button: Publish Contest
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads `Contest` and `ContestSubmission` tables.

---

### Manage Members - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-users`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`
- `/images/portrait-of-a-smiling-professional-woman-with-da-da0d2f.jpg`
- `/images/portrait-of-a-young-male-chef-in-professional-bl-e304d3.jpg`
- `/images/portrait-of-an-elegant-female-culinary-enthusias-8228ea.jpg`
- `/images/portrait-of-an-experienced-pastry-chef-with-neat-8f8cc0.jpg`
- `/images/portrait-of-a-young-woman-with-warm-smile-wearin-6edcf1.jpg`

**Visual Elements:**
```text
<input text 'Search members by name, email, or phone...'>
button: All Members
button: Monthly
button: Yearly
button: Expired
button: [download] Export
th: Member
th: Contact
th: Plan Badge
th: Join Date
th: Expiry Date
th: Posts
th: Status
th: Actions Clarissa Montgomery ID: #USR-8492 c.montgomery@example.com +1 (555) 234-5678 [workspace_premium] Yearly VIP Jan 12, 2023 Jan 12, 202
button: [visibility]
button: [block] Marcus Vance ID: #USR-9102 marcus.v@culinaryarts.io +1 (555) 987-6543 Monthly Nov 04, 2023 Dec 04, 2024 19 Active
button: [visibility]
button: [block] Helena Rostova ID: #USR-3321 helena.r@gourmet.net +44 20 7946 0912 Expired Oct 15, 2022 Oct 15, 2023 5 Blocked
button: [visibility]
button: [check_circle] Julian Dupont ID: #USR-7744 j.dupont@patisserie.fr +33 1 42 68 55 00 [workspace_premium] Yearly VIP Feb 20, 2023 Feb 20, 2025
button: [visibility]
button: [block] Aaliyah Chen ID: #USR-1109 aaliyah.chen@spicecraft.com +1 (555) 432-1098 Monthly May 10, 2023 Nov 28, 2024 12 Active
button: [visibility]
button: [block] Showing 1 to 5 of 2,845 members
button: Previous
button: 1
button: 2
button: 3 ...
button: 57
button: Next
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads/Updates `User` and `Subscription` tables.

---

### Manage Tips - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-tips`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`

**Visual Elements:**
```text
h1: Culinary Mastery Tips
p: Curate and manage professional kitchen secrets, knife skills, and technique advisory notes.
button: [add] + Add Tip Total Active Tips [lightbulb] 128 [trending_up] +12 added this month Free Insights [lock_open] 45 Publicly accessible Master
<input text 'Search tips by title or keyword...'>
<select  ''>
option: All Categories
option: Knife Skills
option: Sauces & Emulsions
option: Pastry & Baking
option: Meat Butchery
option: Kitchen Equipment
<select  ''>
option: All Access Types
option: Free
option: Premium
<select  ''>
option: All Authors
option: Chef James
option: Sous Chef Clara
option: Chef Marcus
button: Reset Filters
th: Title & Summary
th: Category
th: Author
th: Access Toggle
th: Date
th: Actions Perfect Chiffonade on Delicate Herbs Master the rolling technique to prevent bruising delicate basil and mint leaves. Knife Skills C
<input checkbox ''>
button: [visibility]
button: [edit]
button: [delete] Emulsifying Hollandaise Without Splitting Temperature control secrets and the ice cube emergency fix for broken sauces. Sauces Sous
<input checkbox ''>
button: [visibility]
button: [edit]
button: [delete] The Maillard Reaction in Pan-Searing Surface moisture elimination for achieving an even, restaurant-quality crust on ribeye. Meat C
<input checkbox ''>
button: [visibility]
button: [edit]
button: [delete] Lamination Secrets for Croissant Dough Butter temperature control and turn pacing for pristine honeycomb crumb structures. Pastry C
<input checkbox ''>
button: [visibility]
button: [edit]
button: [delete] Sharpening on Japanese Waterstones Finding the correct 15-degree bevel angle and building a proper slurry for 1000/6000 grit stones
<input checkbox ''>
button: [visibility]
button: [edit]
button: [delete] Showing 1 to 5 of 128 entries
button: Previous
button: 1
button: 2
button: 3 ...
button: 26
button: Next [warning]
h3: Confirm Tip Deletion
p: Are you sure you want to delete this tip ? This action cannot be undone and will remove it from all active member feeds.
button: Cancel
button: Delete Tip [check_circle] Action Successful Changes have been saved successfully.
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads `Tip` table.

---

### Membership Plans - JamesThew.com
**ID/Slug:** `plans`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/dramatic-overhead-angle-of-a-master-chef-hands-p-b27e16.jpg`

**Visual Elements:**
```text
a: Home [chevron_right] Membership Plans [workspace_premium] Haute Gastronomy Guild
h1: Unlock Chef James’s Complete Kitchen
p: Choose the membership pass that fits your culinary journey. Gain unrestricted entry to Michelin-grade secret formulas, private masterclass a
button: Monthly Billing
button: Yearly Pass [local_fire_department] Save 17% Flexible Access [restaurant_menu]
h2: Monthly Pass
p: Full access calibrated for seasonal learners and culinary connoisseurs on the go. $10 / month
p: Billed monthly. Cancel anytime.
li: [check_circle] Access all 50+ premium recipes
li: [check_circle] Access all premium cooking tips & secret formulas
li: [check_circle] Full search across the entire master catalog
li: [check_circle] Post your own original recipes and tips to the community
li: [check_circle] Full participation in monthly contests with artisanal prizes
li: [check_circle] Priority site and recipe feedback channel
a: Join Monthly [military_tech] Best Value — Save $20 Executive Member [verified]
h2: Yearly Pass
p: The gold standard master suite. Ideal for committed home cooks and hospitality aspirants. $100 / year
p: Equivalent to $8.33/month. Billed annually.
li: [verified] Access all 50+ premium recipes
li: [verified] Access all premium cooking tips & secret formulas
li: [verified] Full search across the entire master catalog
li: [verified] Post your own original recipes and tips to the community
li: [verified] Full participation in monthly contests with artisanal prizes
li: [verified] Priority site and recipe feedback channel
a: [lock_open] Join Now (Annual) Private Reserve [menu_book] Exclusive Technique Vault
h3: Curated by an Executive 5-Star Hotel Chef
p: Every formula is tested across real brigade kitchens. With membership, gain access to culinary science insights, plating diagrams, and the s
h3: Free Guest vs. Full Member
th: Feature & Privileges
th: Free Guest
th: Full Member Free Recipes Access [check] [check] Free Cooking Tips & Fundamentals [check] [check] Premium Recipes Vault (50+ Dishes) [close] 
h3: Frequently Asked Questions
button: Can I switch between monthly and yearly billing? [expand_more] Yes, you can upgrade from monthly to yearly billing at any point from your me
button: What payment methods are supported? [expand_more] We process all major international credit and debit cards, including Visa, MasterCard, and
button: How does contest eligibility work for members? [expand_more] Active Monthly and Yearly members hold full voting and submission rights. You c
button: Can I cancel my membership at any time? [expand_more] Absolutely. There are no lock-in contracts. You may cancel renewal with a single click
p: Questions before subscribing? Visit our
a: Help & Contact Desk . [FOOTER]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### My Contest Entries - Dashboard - JamesThew.com
**ID/Slug:** `dashboard-my-entries`

**Image Paths:**
- `/images/dashboard-my-entries-img-0a7246.jpg`

**Visual Elements:**
```text
h2: My Contest Entries
p: Track your submissions to James Thew's quarterly culinary challenges. Review judging statuses and elite accolades.
button: [add_circle] Join Active Contest [workspace_premium] 03 Total Submissions [hourglass_top] 01 Pending Evaluation [trophy] 02 Accolades Won
button: All Entries (3)
button: Pending (1)
button: Winner (2) [search]
<input text 'Search entries or contests...'>
th: Contest Name
th: Entry Title
th: Type
th: Submitted Date
th: Status
th: Action Autumn Truffle Masterclass 2024 Global Culinary Showcase Handmade Tagliolini with White Alba Truffle Emulsion [menu_book] Recipe Oct 
button: [visibility] Winter Citrus & Smoke Challenge Executive Chef Guild Blood Orange & Rosemary Infused Smoke Reduction [lightbulb] Tip Nov 28, 20
button: [visibility] Artisanal Sourdough & Fermentation Cup Sanctuary Baking Society 72-Hour Wild Yeast Ancient Grain Boule [menu_book] Recipe Aug 0
button: [visibility] Showing 3 of 3 entries
button: Previous
button: 1
button: Next [local_fire_department] Active Challenge
h3: The 2025 Grand Gastronomy Open
p: Submit your most innovative molecular or classical plating masterpiece. Compete for the James Thew Gold Medal and a featured masterclass fea
button: Submit New Entry
```

**Business Logic:**
- Only accessible to logged-in Members.
- Shows user-specific data (their submissions, favorites).

**DB Impact:**
- Reads static or CMS data.

---

### My Tips - Dashboard - JamesThew.com
**ID/Slug:** `dashboard-my-tips`

**Image Paths:**
- `/images/dashboard-my-tips-img-ac28e0.jpg`
- `/images/dashboard-my-tips-img-ec443c.jpg`
- `/images/dashboard-my-tips-img-c099cb.jpg`
- `/images/dashboard-my-tips-img-09b87d.jpg`

**Visual Elements:**
```text
h2: My Kitchen Tips & Techniques [search]
<input text 'Filter submitted tips...'>
button: [add] + Add Tip Total Tips Published [lightbulb] 24 [trending_up] +3 this month Total Tip Views [visibility] 14.2K [trending_up] +18.4% enga
th: Tip Title & Preview
th: Category
th: Access
th: Date Submitted
th: Actions Precision Julienne: The Wet-Honing Method Achieve razor-thin vegetable strips consistently by establishing a 15-degree bevel angle b
button: [visibility]
button: [edit]
button: [delete] The Maillard Crust Secret on Cast Iron Preheating cast iron past 500°F with rendered tallow creates an unbreakable savory barrier. 
button: [visibility]
button: [edit]
button: [delete] Emulsifying Butter into Pan Sauces Always mount sauces off the direct flame using ice-cold cubed butter for a velvety gloss finish.
button: [visibility]
button: [edit]
button: [delete] Hydration Ratios in Artisan Sourdough Adjusting bulk fermentation temperatures by 2 degrees can alter crumb openness significantly.
button: [visibility]
button: [edit]
button: [delete] Showing 4 of 24 culinary tips
button: Previous
button: 1
button: 2
button: 3
button: Next [warning]
h3: Delete Culinary Tip
p: Are you sure you want to permanently delete "Precision Julienne: The Wet-Honing Method" ? This action cannot be undone and will remove it fr
button: Cancel
button: Confirm Deletion
h3: Contribute New Culinary Tip
button: [close]
label: Tip Title
<input text 'e.g. Perfect Tempering for Chocolate Ganache'>
label: Category
<select  ''>
option: Knife Skills
option: Meat & Poultry
option: Sauces & Reductions
option: Baking & Pastry
option: Equipment Mastery
label: Access Level
<input radio ''>
<input radio ''>
label: Tip Content & Technique
<textarea  'Detail the step-by-step master technique...'>
button: Cancel
button: Publish Tip
```

**Business Logic:**
- Only accessible to logged-in Members.
- Shows user-specific data (their submissions, favorites).

**DB Impact:**
- Reads `Tip` table.

---

### Our Mission - About - JamesThew.com
**ID/Slug:** `about-mission`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/close-up-photograph-of-a-professional-chef-hand-17da3d.jpg`

**Visual Elements:**
```text
a: Home / About / Our Mission Culinary Philosophy & Purpose
h1: “Exquisite cuisine is not an exclusive privilege; it is an enduring language of craft, patience, and shared joy that belongs in every kitche
p: Executive 5-Star Chef, Author, and Culinary Educator striving to bridge the divide between grand hotel brigade mastery and the everyday home

  ## SECTION
p: Mastercraft Precision
p: From Michelin Brigade to Domestic Sanctuary [skillet] [auto_stories] Foundational Creed
p: We dispel the myth that haute cuisine demands unattainable ingredients or impenetrable French kitchen nomenclature. By deconstructing balanc
h3: Open Pedagogy
p: Freely shared master fundamentals paired with tiered mentorship, ensuring refined technique is never kept behind gatekept guild doors.

  ## SECTION
h2: Our Mission
p: To democratize executive culinary wisdom by translating elite fine-dining methodologies into approachable, repeatable rituals for passionate
p: Demystifying master sauce-making, knife proficiency, and balanced flavor science. [check_circle]
p: Fostering respectful ingredient sourcing, culinary self-reliance, and sustainable pantry management. [visibility] 02 / Horizon
h2: Our Vision
p: To cultivate a boundary-free global sanctuary where domestic kitchens mirror the poise, artistry, and joyful precision of the world's most r
p: A universal culinary forum where regional traditions converse harmoniously with classical technique. [lens_blur]
p: Empowering next-generation culinary storytellers through open feedback and friendly competitive showcases.

  ## SECTION
h2: The Tenets We Plate Every Day
p: Every recipe developed, class scheduled, and tip written is measured against four inviolable cornerstones. [verified]
h3: Uncompromising Quality
p: From heat titration to knife beveling, we impart techniques rigorously tested across decades of five-star hospitality operations. TENET 01 [
h3: Radical Accessibility
p: Culinary grandeur translated for domestic cookware, sensible local ingredient substitutions, and universally affordable workshops. TENET 02 
h3: Nurturing Community
p: A warm, constructive fellowship where beginning cooks celebrate small triumphs and seasoned gastronomes share specialized insights. TENET 03
h3: Boundless Creativity
p: Respecting heritage lineages while encouraging adventurous flavor pairings, sculptural plating, and bespoke domestic innovation. TENET 04

  ## SECTION

  ## SECTION
h2: Awaken the Executive Chef Dormant in Your Domestic Kitchen
p: Join our global kitchen community today to access step-by-step master blueprints, attend Chef James's weekend classes, and elevate every pla
a: Join Now [arrow_forward]
a: Explore Weekend Classes
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Overview - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-dashboard`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`
- `/images/portrait-photo-of-a-professional-chef-wearing-a-e668c6.jpg`
- `/images/portrait-photo-of-a-smiling-female-baker-holding-82cfe4.jpg`
- `/images/portrait-photo-of-a-young-male-culinary-enthusia-d39f8f.jpg`
- `/images/portrait-photo-of-an-asian-female-tea-master-pre-14707b.jpg`

**Visual Elements:**
```text
h1: Welcome back, Chef James
p: Culinary platform analytics and administrative oversight.
a: [add] Add Recipe
a: [lightbulb] Add Tip
a: [emoji_events] Create Contest Total Recipes [restaurant_menu] 1,248 [trending_up] +12% Total Tips [lightbulb] 342 [trending_up] +5% Members 
h3: New Members per Month
p: Growth trajectory across platform tiers over the last 6 months 2024 Analytics 1.2k Nov 1.8k Dec 2.4k Jan 3.1k Feb 3.8k Mar 4.5k Apr
h3: Free vs Premium Content
p: Content distribution ratio 100% Catalog Premium (64%) Free (36%)
h3: Recent Contest Entries
p: Latest submissions awaiting evaluation or winner selection
a: View all [arrow_forward]
th: Title
th: Submitted By
th: Type
th: Contest Name
th: Date
th: Action Truffle Infused Risotto Chef Marcus Vance [workspace_premium] Premium Spring Masterclass Showcase Apr 12, 2024
a: View Artisan Sourdough Technique Elena Rostova Free Daily Kitchen Secrets Apr 11, 2024
a: View Pan-Seared Duck Breast Julian Thorne [workspace_premium] Premium Spring Masterclass Showcase Apr 10, 2024
a: View Matcha Ceremonial Pairing Aoi Tanaka Free Daily Kitchen Secrets Apr 09, 2024
a: View
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads static or CMS data.

---

### Overview - Dashboard - JamesThew.com
**ID/Slug:** `dashboard-overview`

**Image Paths:** None specific

**Visual Elements:**
```text
h1: Welcome back, Evelyn Vance
p: Your culinary dashboard is primed. 2 pending reviews require your attention. [workspace_premium] [crown] Yearly Member
p: Renews March 1, 2027
button: Renew / Change [arrow_forward]
a: [add_circle] Add Recipe
a: [note_add] Add Tip My Recipes [menu_book] 12 [trending_up] +2 this month My Tips [lightbulb] 8 [check_circle] 100% published Contest Entries
h2: Recent Activity
a: View All Log [menu_book]
h3: Submitted new recipe: Tuscan Truffle Risotto 2 hours ago
p: Added to main archive under Italian Culinary Arts. Awaiting final chef review. [military_tech]
h3: Contest Entry Approved: Summer Citrus Reduction Yesterday
p: Successfully registered for the annual Grand Kitchencraft Championship. [lightbulb]
h3: Published culinary tip: Maintaining Carbon Steel Pans 3 days ago
p: Shared valuable seasoning advice with the Sanctuary community. [timer] Ends in 12 Days
h2: Best Italian Recipe or Summer Juice Tip
p: Showcase your mastery of artisanal pasta or refreshing botanical extracts for a chance to win the Michelin Masterclass pass.
button: Participate Now [arrow_forward] [verified]
h3: Chef's Advisory
p: "Precision in preparation separates the novice from the artisan. Always temper your proteins 20 minutes before execution." — Executive Chef
```

**Business Logic:**
- Only accessible to logged-in Members.
- Shows user-specific data (their submissions, favorites).

**DB Impact:**
- Reads static or CMS data.

---

### Past Winners - Contests - JamesThew.com
**ID/Slug:** `contest-winners`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/portrait-of-culinary-contest-winner-farah-al-say-0a207c.jpg`
- `/images/exquisite-fine-dining-presentation-of-saffron-sp-bd79b4.jpg`
- `/images/plated-handcrafted-italian-agnolotti-pasta-with-7ecba9.jpg`
- `/images/vibrant-artisanal-cold-pressed-botanical-beverag-245094.jpg`
- `/images/salt-baked-multicolored-heritage-carrots-artisti-95a405.jpg`
- `/images/succulent-tamarind-glazed-tender-beef-short-rib-c8b80f.jpg`
- `/images/artisanal-wood-fired-neapolitan-pizza-bianca-wit-ca6926.jpg`
- `/images/artisanal-fermented-white-peach-and-green-corian-9e088d.jpg`

**Visual Elements:**
```text
a: Home
li: /
a: Contests
li: /
li: Past Winners HALL OF CULINARY HONORS
h1: Contest Winners Archive
p: Celebrating domestic chefs and passionate gourmands who have mastered seasonal challenges and earned Chef James's acclaim.

  ## SECTION
h3: Coastal Seafood & Citrus Emulsion Challenge Winning Entry [star] 5.0
h4: Saffron Spiced Seabass with Fennel & Meyer Lemon Glaze Farah Al-Sayed
p: Amateur Gourmet Division • Karachi, PK
p: “A breathtaking display of heat control and acid balance. The reduction maintained crystalline clarity while coating the fish with velvety b
p: Grand Prize: $500 Artisanal Kitchen Suite & 1-on-1 Culinary Mentorship Session
a: View Winning Recipe Details [arrow_forward] [military_tech] Gold Medalist Selection Winter Masterclass

  ## SECTION
button: All Years
button: 2026
button: 2025
button: 2024
button: All Categories
button: Italian
button: Juices
button: Vegetarian
button: Non-Vegetarian [ search ]
<input text 'Search past entries, winners, recipes...'>

  ## SECTION
h3: Artisanal Fresh Pasta & Morel Showcase [person] Marco Valenti • Rome / Community Master Winning Entry
p: Hand-Folded Agnolotti with Charred Thyme & Pine Nut Fonduta
a: View Winning Entry [arrow_forward] Juices [emoji_events] Dec 2025 Champion
h3: Winter Botanical Elixirs & Health Tonics [person] Amina Tariq • Lahore Winning Entry
p: Blood Orange, Turmeric & Smoked Rosemary Nectar
a: View Winning Entry [arrow_forward] Vegetarian [emoji_events] Nov 2025 Champion
h3: Heirloom Root & Plant Architecture [person] David Chen • Karachi Winning Entry
p: Salt-Baked Heritage Carrots with Whipped Goat Curd & Cumin Crunch
a: View Winning Entry [arrow_forward] Non-Vegetarian [emoji_events] Oct 2025 Champion
h3: Slow-Braised Autumn Meats & Stock Reductions [person] Bilal Haider • Islamabad Winning Entry
p: Tamarind-Glazed Beef Short Ribs on Parsnip-Cardamom Mash
a: View Winning Entry [arrow_forward] Italian [emoji_events] Sep 2025 Champion
h3: Neapolitan Sourdough & Fermentation Precision [person] Elena Rostova • Member Winning Entry
p: 72-Hour Fermented Pizza Bianca with Fior di Latte & Fig Compote
a: View Winning Entry [arrow_forward] Juices [emoji_events] Aug 2025 Champion
h3: Summer Stone Fruit & Cold-Brewed Shrub Challenge [person] Zainab Malik • Karachi Winning Entry
p: Fermented White Peach & Green Coriander Shrub
a: View Winning Entry [arrow_forward]
a: [chevron_left] Previous
a: 1
a: 2
a: 3
a: Next [chevron_right]

  ## SECTION
p: Inspired by our champions? Test your skills in our current challenge.
a: Enter Active Contest [arrow_forward]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads `Contest` and `ContestSubmission` tables.

---

### Premium Recipes (Guest) - JamesThew.com
**ID/Slug:** `recipes-premium-guest`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/gourmet-sous-vide-wagyu-beef-fillet-glistening-w-d8eadf.jpg`
- `/images/creamy-artisanal-saffron-risotto-topped-with-pan-1723d1.jpg`
- `/images/crispy-skinned-duck-confit-leg-rested-on-a-vibra-ade71d.jpg`
- `/images/intricate-layered-yellow-egg-yolk-fresh-pasta-sh-8256f7.jpg`
- `/images/deep-crimson-fermented-pomegranate-juice-elixir-204007.jpg`
- `/images/charred-fractaling-romanesco-broccoli-perched-ov-3c4fc2.jpg`
- `/images/slow-braised-whole-quail-basted-with-deep-dark-p-5adde2.jpg`
- `/images/pan-fried-sourdough-potato-gnocchi-tossed-in-nut-dbc955.jpg`

**Visual Elements:**
```text
a: Home [chevron_right] Recipes [chevron_right] Premium Recipes [workspace_premium] Haute Reserve Archives
h1: Premium Recipes
p: Exclusive recipes by Chef James and our community.

  ## SECTION
h2: Unlock all premium recipes — $10/month or $100/year
p: Get unlimited access to Michelin-grade secret formulas, step-by-step videos, and member recipe submissions.
a: Join Now
a: Login
<input text 'Search vault formulas, ingredients...'>
button: All
button: Juices
button: Vegetarian
button: Non-Vegetarian
button: Italian
label: Sort by:
<select  ''>
option: Most Recent
option: Highest Rated
option: Shortest Time [expand_more] [lock] Members Only Non-Vegetarian [crown] Premium Chef James [star] 5.0
h3: Sous-Vide Wagyu Fillet with Truffle Jus [schedule] 1h 15m prep & cook
button: [lock] Unlock Recipe [lock] Members Only Vegetarian [crown] Premium Chef James [star] 4.9
h3: Smoked Morel & Saffron Risotto Supreme [schedule] 45m prep & cook
button: [lock] Unlock Recipe [lock] Members Only Non-Vegetarian [crown] Premium Community Master [star] 5.0
h3: Artisanal Duck Confit with Blood Orange Gastrique [schedule] 2h 10m prep & cook
button: [lock] Unlock Recipe [lock] Members Only Italian [crown] Premium Chef James [star] 4.8
h3: Hand-Layered 100-Yolk Lobster Lasagnette [schedule] 1h 40m prep & cook
button: [lock] Unlock Recipe [lock] Members Only Juices [crown] Premium Community Master [star] 4.9
h3: Artisanal Fermented Ginger & Pomegranate Elixir [schedule] 25m prep & brew
button: [lock] Unlock Recipe [lock] Members Only Vegetarian [crown] Premium Chef James [star] 5.0
h3: Charred Romanesco with Almond Velouté [schedule] 40m prep & cook
button: [lock] Unlock Recipe [lock] Members Only Non-Vegetarian [crown] Premium Chef James [star] 4.9
h3: Braised Quail in Pomegranate Anise Glaze [schedule] 1h 10m prep & cook
button: [lock] Unlock Recipe [lock] Members Only Italian [crown] Premium Community Master [star] 4.7
h3: Artisanal Sourdough Gnocchi with Brown Butter Sage [schedule] 50m prep & cook
button: [lock] Unlock Recipe
button: [chevron_left]
button: 1
button: 2
button: 3 …
button: 7
button: [chevron_right] [FOOTER]
```

**Business Logic:**
- If user is a Guest, hide premium content (videos, full instructions) and show lock icons.
- Display upgrade prompts to premium plans.

**DB Impact:**
- Reads `Recipe` table.

---

### Premium Recipes (Member) - JamesThew.com
**ID/Slug:** `recipes-premium-member`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/gourmet-black-summer-truffle-risotto-plated-on-h-bc284a.jpg`
- `/images/portrait-silhouette-of-chef-james-thew-in-pristi-b57895.jpg`
- `/images/pan-seared-chilean-sea-bass-filet-over-velvety-s-ad8a62.jpg`
- `/images/portrait-silhouette-of-chef-james-thew-in-pristi-64daa8.jpg`
- `/images/decadent-hand-crimped-wild-morel-mushroom-and-ri-b0e1ab.jpg`
- `/images/culinary-chef-avatar-of-female-pastry-and-pasta-7f5ef5.jpg`
- `/images/cold-pressed-blood-orange-yuzu-rosemary-botanica-29e369.jpg`
- `/images/portrait-silhouette-of-chef-james-thew-in-pristi-54cec4.jpg`
- `/images/prime-dry-aged-wagyu-ribeye-steak-sliced-thinly-dfb274.jpg`
- `/images/portrait-silhouette-of-chef-james-thew-in-pristi-1bbf29.jpg`
- `/images/artisanal-hand-stretched-sourdough-roman-pizza-b-698b13.jpg`
- `/images/culinary-enthusiast-male-profile-photo-in-modern-978286.jpg`
- `/images/maitake-and-royal-trumpet-mushroom-carpaccio-lay-b1627c.jpg`
- `/images/portrait-silhouette-of-chef-james-thew-in-pristi-25b812.jpg`
- `/images/luminescent-cold-pressed-cucumber-ginger-granny-ea1330.jpg`
- `/images/culinary-chef-avatar-of-female-pastry-and-pasta-267d75.jpg`

**Visual Elements:**
```text
a: Home /
a: Recipes / Premium Recipes
button: [notifications]
button: EL Elena Rostova [verified] Master Pass [expand_more] Member Access Active
a: [dashboard] Dashboard
a: [person] Profile & Trophies
a: [bookmark] Saved Recipes (24)
a: [logout] Logout

  ## SECTION
h1: Premium Recipes
p: Welcome back, Member • Exclusive recipes by Chef James and our master community [restaurant_menu] 48 Chef Masterpieces [lock_open] 100% Unlo

  ## SECTION
<input text 'Search master ingredients, technique, or spice blend...'>
button: [close]
button: All
button: [workspace_premium] Premium
button: Free
<select  ''>
option: Sort: Top Rated
option: Sort: Newest First
option: Sort: Fastest Prep
option: Sort: Difficulty Level [expand_more]
button: All Specialties
button: Artisanal Juices
button: Vegetarian
button: Non-Vegetarian
button: Haute Italian Showing 48 exclusive master recipes

  ## SECTION
button: [bookmark] Chef James Thew [verified]
h2: Umbrian Truffle Acquerello Risotto
p: Aged Carnaroli rice whipped with cultured alpine butter and 36-month Parmigiano Reggiano. [schedule] 35 mins prep • 20 mins cook [star] 4.98
a: View Recipe [arrow_forward] Non-Vegetarian [workspace_premium] Premium
button: [bookmark] Chef James Thew [verified]
h2: Pan-Crisped Sea Bass in Saffron
p: Delicate marine fillets with slow-steeped Kashmiri saffron sauce and crisp caper berries. [schedule] 20 mins prep • 15 mins cook [star] 4.95
a: View Recipe [arrow_forward] Vegetarian [workspace_premium] Premium
button: [bookmark] Alessandra Rossi [verified]
h2: Handmade Wild Morel Mezzelune
p: Silky semolina pasta stuffed with foraged forest morels, aged pecorino, and hazelnut butter. [schedule] 45 mins prep • 8 mins cook [star] 4.
a: View Recipe [arrow_forward] Artisanal Juices [workspace_premium] Premium
button: [bookmark] Chef James Thew [verified]
h2: Blood Orange & Smoked Yuzu Elixir
p: Zero-proof cold extract with charred winter rosemary and subtle organic cardamom mist. [schedule] 12 mins prep • 0 mins cook [star] 4.89 (76
a: View Recipe [arrow_forward] Non-Vegetarian [workspace_premium] Premium
button: [bookmark] Chef James Thew [verified]
h2: 45-Day Dry-Aged Wagyu Ribeye
p: Reverse-seared over cherrywood embers, glazed with shallot and bone marrow reduction. [schedule] 15 mins prep • 25 mins cook [star] 5.00 (21
a: View Recipe [arrow_forward] Haute Italian [workspace_premium] Premium
button: [bookmark] Marco Valenti [verified]
h2: 72-Hour Sourdough Pizza Bianca
p: High-hydration crumb topped with Mission figs, pungent Gorgonzola, and wild thyme. [schedule] 30 mins prep • 6 mins bake [star] 4.94 (118)
a: View Recipe [arrow_forward] Vegetarian [workspace_premium] Premium
button: [bookmark] Chef James Thew [verified]
h2: Royal Trumpet Carpaccio
p: Wafer-thin king oyster stems cold-smoked in applewood, with pickled mustard pearl vinaigrette. [schedule] 25 mins prep • 0 mins cook [star] 
a: View Recipe [arrow_forward] Artisanal Juices [workspace_premium] Premium
button: [bookmark] Alessandra Rossi [verified]
h2: Emerald Garden Press & Ceremonial Matcha
p: Triple-filtered crisp orchard apples, crisp celery water, lemon balm, and stone-ground Uji matcha. [schedule] 10 mins prep • 0 mins cook [st
a: View Recipe [arrow_forward]

  ## SECTION
button: [chevron_left]
button: 1
button: 2
button: 3 ...
button: 6
button: [chevron_right]
a: [add] Add Recipe [FOOTER]
```

**Business Logic:**
- If user is a Member, fully unlock content.

**DB Impact:**
- Reads `Recipe` table.

---

### Premium Tips (Guest) - Tips & Tricks - JamesThew.com
**ID/Slug:** `tips-premium-guest`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`

**Visual Elements:**
```text
a: Home / Tips & Tricks / Premium Tips Culinary Mastery Archive
h1: Premium Tips from Chef James
p: Executive-level trade secrets, molecular gastronomy guidelines, and 5-star hotel kitchen formulations. [workspace_premium] Executive Vault A
h2: Unlock all premium kitchen master-tips — $10/month or $100/year
p: Gain unrestricted access to Chef James's private kitchen notes, ratio tables, sous-vide precision charts, and professional troubleshooting g
a: Join Now ($10/mo)
a: Login
button: All
button: Juices
button: Vegetarian
button: Non-Vegetarian
button: Italian
<input text 'Search secrets...'>
<select  ''>
option: Most Recent
option: Highly Requisite
option: Complexity Level [unfold_more] [military_tech] Premium Non-Vegetarian
h3: The Exact Temperature Gradients of Wagyu Resting [verified] Chef James Thew • 5-Star Hotel Laureate Resting at ambient temperatures collapse
a: Unlock Tip [arrow_forward] [calendar_today] Oct 12, 2026 Vault File #402 [military_tech] Premium Juices
h3: Enzymatic Clarification for Crystal Fruit Elixirs [verified] Chef James Thew • 5-Star Hotel Laureate Standard agar-agar gel filtration strip
a: Unlock Tip [arrow_forward] [calendar_today] Oct 08, 2026 Vault File #398 [military_tech] Premium Vegetarian
h3: Developing 72-Hour Sourdough Fermentation Complexity [verified] Chef James Thew • 5-Star Hotel Laureate Lactobacillus sanfranciscensis flour
a: Unlock Tip [arrow_forward] [calendar_today] Sep 29, 2026 Vault File #389 [military_tech] Premium Italian
h3: Cold Emulsion Stability Without Chemical Binders [verified] Chef James Thew • 5-Star Hotel Laureate Classical aioli and bagna càuda formulat
a: Unlock Tip [arrow_forward] [calendar_today] Sep 21, 2026 Vault File #381 [military_tech] Premium Non-Vegetarian
h3: Micro-Oxygenation Techniques for Deep Reduction Glazes [verified] Chef James Thew • 5-Star Hotel Laureate Veal demi-glaces frequently turn b
a: Unlock Tip [arrow_forward] [calendar_today] Sep 14, 2026 Vault File #375 [military_tech] Premium Italian
h3: Artisanal Cheese Curing in Controlled Humidity [verified] Chef James Thew • 5-Star Hotel Laureate Pecorino and raw mountain cheeses suffer s
a: Unlock Tip [arrow_forward] [calendar_today] Sep 05, 2026 Vault File #369
button: [chevron_left]
button: 1
button: 2
button: 3
button: [chevron_right] [FOOTER]
```

**Business Logic:**
- If user is a Guest, hide premium content (videos, full instructions) and show lock icons.
- Display upgrade prompts to premium plans.

**DB Impact:**
- Reads `Tip` table.

---

### Profile Settings - Dashboard - JamesThew.com
**ID/Slug:** `dashboard-profile`

**Image Paths:** None specific

**Visual Elements:**
```text
button: [photo_camera] Edit
h2: Chef James Vance [crown] Executive Elite Plan
p: james.vance@sanctuary-dining.com [event_available] Subscription renews on November 14, 2025 Profile Status: Verified Master
button: [badge] Personal Information
button: [lock_reset] Change Password
h3: Edit Profile Details
p: Update your personal credentials and professional contact details.
label: Full Name
<input text ''>
label: Email Address
<input email ''>
label: Phone Number
<input tel ''>
label: Culinary Specialization
<select  ''>
option: Haute Cuisine & French Technique
option: Modern Gastronomy
option: Artisanal Pastry & Baking
option: Plant-Forward Fine Dining
label: Bio / Professional Statement
<textarea  ''>
button: [save] Save Changes [security]
h4: Account Security
p: Two-factor authentication is active via authenticator app. Your kitchen archive is encrypted at rest.
button: Manage 2FA Settings [notifications_active]
h4: Kitchen Alerts
p: Receive instant notifications for contest judging results and new masterclass drops.
label: Email Notifications
<input checkbox ''>
h3: Update Password
p: Ensure your account is using a long, random password to stay secure.
label: Current Password
<input password '••••••••••••'>
label: New Password
<input password '••••••••••••'>
label: Confirm New Password
<input password '••••••••••••'>
button: [lock] Update Password [info]
h4: Password Requirements
li: [check] Minimum 8 characters long
li: [check] At least one uppercase letter
li: [check] At least one numeric digit
li: [check] At least one special symbol
```

**Business Logic:**
- Only accessible to logged-in Members.
- Shows user-specific data (their submissions, favorites).

**DB Impact:**
- Reads/Updates `User` and `Subscription` tables.

---

### Recipe Details (Guest Locked) - JamesThew.com
**ID/Slug:** `recipe-details-locked`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/recipe-details-locked-img-5e234d.jpg`
- `/images/recipe-details-locked-img-4661a9.jpg`
- `/images/recipe-details-locked-img-0a4483.jpg`
- `/images/recipe-details-locked-img-048af2.jpg`

**Visual Elements:**
```text
a: Home /
a: Recipes / Premium / Sous-Vide Wagyu Fillet with Truffle Jus

  ## SECTION
h1: Sous-Vide Wagyu Fillet with Truffle Jus [timer] Prep: 25 mins • [skillet] Cook: 90 mins • [group] Servings: 2 • [star] [star] [star] [star] 
h2: Ingredients Breakdown 8 items required [check_circle] 2x 250g A5 Wagyu Tenderloin cuts Center Cut [check_circle] 2 sprigs fresh thyme & sea 
h2: Culinary Procedure Precision Guide 01 Foundation Step
h3: Tempering and Vacuum Infusion
p: Pat the Wagyu fillets completely dry using culinary linen. Season generously on all sides with cracked sea salt flakes. Place into a chamber
h3: Water Bath Equilibrium & Thermal Control
p: Submerge the sealed pouches into the calibrated immersion circulator set precisely to 53.5°C (128.3°F). Cook for 90 minutes to render the in
h3: Reduction of Truffle Glace & Emulsion
p: In a copper saucier, sweat the shallots gently. Deglaze with aged Madeira and reduce until syrupy. Whisk in the enriched veal stock and simm
h3: Cast-Iron Maillard Sear & Plating
p: Remove fillets and flash-sear in a smoking hot cast-iron pan with clarified butter for strictly 45 seconds per facet. Rest for 4 minutes bef
h3: This Recipe Is for Members Only
p: Unlock complete culinary secret formulas, exact temperature charts, masterclass cooking videos, and private chef notes. [verified] Join for 
a: Join Now ($10/mo)
a: Login to your account
h3: Other Premium Masterclasses [auto_awesome]
p: Explore curated haute-cuisine formulas unlocked with any active membership plan. [lock] PREMIUM • Seafood
h4: Pan-Seared Hokkaido Scallops
p: Saffron emulsion & Ossetra caviar pearls [lock] PREMIUM • Pastry
h4: Valrhona Noir Opera Gateau
p: Espresso soak & 24-karat gold leaf glaze [lock] PREMIUM • Charcuterie
h4: Crispy Berkshire Pork Belly
p: Compressed honeycrisp & spiced cider gastrique
a: View All 84+ Masterclasses [arrow_forward] [workspace_premium] Tier Benefits
h4: What Members Unlock
li: [verified] Full grams-to-the-tenth precision ingredient specifications
li: [verified] Executive chef temperature and atmospheric resting curves
li: [verified] Sommelier wine pairing notes and sauce emulsion safeguards
li: [verified] Direct culinary consultation in member Q&A sessions Subscriber Rate $10 /month Cancel Anytime [FOOTER]
```

**Business Logic:**
- If user is a Guest, hide premium content (videos, full instructions) and show lock icons.
- Display upgrade prompts to premium plans.

**DB Impact:**
- Reads `Recipe` table.

---

### Recipe Details - JamesThew.com
**ID/Slug:** `recipe-details`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/gourmet-crisp-skinned-red-snapper-fillet-delicat-cbce06.jpg`
- `/images/headshot-of-chef-james-thew-in-formal-crisp-char-d7a28d.jpg`
- `/images/portrait-avatar-of-culinary-enthusiast-mariam-k-38a73e.jpg`
- `/images/portrait-avatar-of-julien-moreau-french-sous-che-413c84.jpg`
- `/images/portrait-avatar-of-sophie-vance-modern-food-jour-0a5bf7.jpg`
- `/images/slow-roasted-lamb-shank-coated-in-pomegranate-su-5e39a9.jpg`
- `/images/charred-octopus-tentacles-over-saffron-parsnip-p-da7644.jpg`
- `/images/handcrafted-saffron-ravioli-filled-with-fresh-ri-a1e812.jpg`

**Visual Elements:**
```text
a: [home] Home [chevron_right]
a: Recipes [chevron_right]
a: Non-Vegetarian [chevron_right] Karachi Spiced Pan-Seared Snapper Free Recipe Non-Vegetarian [local_fire_department] Pan-Searing • 480 kcal/s
h1: Karachi Spiced Pan-Seared Snapper
p: Fresh wild Arabian Sea red snapper seared to glassy golden perfection, counterbalanced with a velvety reduction of Persian saffron, hand-chu
button: [bookmark] Save to Cookbook
button: [share] Share
button: [print] Print Sheet [SIDEBAR] Master Class Walkthrough
h2: Cooking Procedure [verified] 5 Executable Stages 1
h3: Fillet Conditioning & Scored Spice Rub Stage 01 • 8 mins
p: Pat the red snapper fillets thoroughly dry using culinary towels; moisture is the enemy of a crisp skin. Make three shallow diagonal incisio
h3: The High-Heat Skin-Down Sear Stage 02 • 6 mins
p: Set a heavy-gauge carbon steel or copper frying pan over medium-high heat until wisps of shimmer emerge. Pour the remaining oil to coat. Lay
h3: Flesh Touch & Residual Butter Baste Stage 03 • 3 mins
p: Carefully invert the fillets with your spatula. Toss 1 tablespoon of butter into the foamy margins. Angle the skillet towards yourself and l
h3: Emulsifying the Saffron Butter Reduction Stage 04 • 5 mins
p: Transfer the snapper fillets skin-side up onto a warmed resting grate. Discard excess surface fat from the skillet, leaving only the fond. D
h3: Haute Cuisine Plating & Botanical Garnish Stage 05 • 3 mins
p: Ladle 2 tablespoons of the warm saffron emulsion into the shallow well of pre-warmed porcelain plates. Center a snapper fillet directly upon

  ## SECTION
h2: Community Feedback
p: Reviewed and calibrated by professional epicures and passionate home gourmands. 4.9 [star] [star] [star] [star] [star_half] Based on 86 Veri
h4: Mariam Khan [verified] Verified Cook [star] [star] [star] [star] [star]
p: "The skin scoring technique is truly the differentiator. It puffed and crystallized without bowing upward. The saffron reduction was pure si
h4: Julien Moreau [verified] Verified Cook [star] [star] [star] [star] [star]
p: "Fascinating blend of French monter au beurre emulsion paired with the pungent depth of toasted Karachi cumin. Be sure the butter is ice col
h4: Sophie Vance [verified] Verified Cook [star] [star] [star] [star] [star]
p: "Masterful balance. I substituted sea bass because snapper wasn't fresh at my market, and the cook times held remarkably true. The floral sa
h3: Leave Your Review & Culinary Notes
p: Share how the seasoning translated in your kitchen, temperature modifications, or pairing suggestions for fellow members.
label: Your Overall Rating [star] [star] [star] [star] [star] 5 Stars (Superb)
label: Full Name
<input text 'e.g. Eleanor Rigby'>
label: Email Address (Confidential)
<input email 'eleanor@haute-cuisine.com'>
label: Tasting Impressions & Kitchen Adjustments
<textarea  'Share your culinary experience, adjustments, or technique questions...'>
button: Submit Feedback [send] All submissions are vetted against our culinary etiquette standards. [check_circle] Thank you! Your culinary review h

  ## SECTION
h2: More Recipes from Chef James
a: Explore All Creations [arrow_forward] Premium [schedule] 1h 45m [star] 4.9 (112)
h3: Braised Kashmiri Lamb Shank & Smoked Aubergine
p: Slow-stewed with green cardamom, Kashmiri dried shallots, and caramelized pomegranate molasses.
a: View Recipe [arrow_forward] Free [schedule] 35m [star] 4.8 (64)
h3: Charred Coastal Octopus with Pimentón Butter
p: Tenderized over charcoal embers and glazed with Spanish smoked paprika, lime, and crushed sea salt.
a: View Recipe [arrow_forward] Premium [schedule] 50m [star] 5.0 (98)
h3: Handmade Saffron & Morel Mushroom Tortelli
p: Silky egg yolk dough infused with alpine butter, foraged Himalayan morels, and aged parmigiano broth.
a: View Recipe [arrow_forward]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads `Recipe` table.

---

### Recipe Details - JamesThew.com (Mobile)
**ID/Slug:** `recipe-details-mobile`

**Image Paths:**
- `/images/recipe-details-mobile-img-806710.jpg`

**Visual Elements:**
```text
button: [bookmark]
h2: Truffle Infused Wild Mushroom Risotto [schedule] Prep 25m [kettle] Cook 40m [star] 4.9 (64)
h3: The Masterclass Summary
p: A symphony of earthy porcini, velvety Carnaroli rice, and aromatic black truffle essence finished with aged Parmigiano-Reggiano. Crafted for
h3: Precision Ingredients Serves 2
<input checkbox ''>
<input checkbox ''>
<input checkbox ''>
<input checkbox ''>
<input checkbox ''>
h3: Culinary Procedure Stage 01 12 Mins
h4: The Mushroom Sauté & Infusion
p: Slice wild mushrooms uniformly. Sauté in noisette butter over medium-high flame until deeply caramelized. Reserve half for plating garnish. 
p: Chef's Note: Do not overcrowd the pan; high heat ensures moisture evaporates completely, concentrating the umami core. Stage 02 18 Mins
h4: Tasting the Toast & Gradual Addition
p: Toast the Carnaroli rice dry until translucent edges appear. Deglaze with dry white wine, then ladle simmering broth one measure at a time w
p: Chef's Note: Gentle, rhythmic stirring releases the starch naturally, giving you that quintessential velvety emulsion without cream. Stage 0
h4: Mantecatura & Truffle Finish
p: Remove from heat. Vigorously fold in cold butter, grated Parmigiano-Reggiano, and a precise drizzle of truffle oil. Rest for two minutes cov
p: Chef's Note: Never let the risotto boil after adding the cheese; thermal shock ruins the glossy emulsion. [restaurant]
h4: A Note from Chef James Executive Culinary Director
p: "Risotto is a meditation in patience. Treat the grains with respect, listen to the quiet simmer of your stockpot, and do not rush the mantec
button: [play_arrow] Begin Guided Masterclass
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads `Recipe` table.

---

### Recipes - Admin Dashboard - JamesThew.com
**ID/Slug:** `admin-recipes`

**Image Paths:**
- `/images/brand-logo-primary-color-d98a56-font-ebgaramond-2e5645.png`
- `/images/profile-49f51c.jpg`
- `/images/admin-recipes-img-bd11b9.jpg`
- `/images/admin-recipes-img-f42ab0.jpg`
- `/images/admin-recipes-img-e05cce.jpg`
- `/images/admin-recipes-img-516235.jpg`

**Visual Elements:**
```text
<input text 'Search recipes...'>
<select  ''>
option: All Categories
option: Main Course
option: Pasta & Grains
option: Beverages
option: Desserts
<select  ''>
option: Access: All
option: Free
option: Premium
<select  ''>
option: All Authors
option: Chef James
option: Elena Vance
option: Marcus Sterling
button: [add] Add Recipe Total Recipes 142 [trending_up] +4 this week Free Access 68 Publicly available Premium Masterclasses 74 [workspace_premium]
<input checkbox ''>
th: Thumbnail & Title
th: Category
th: Author
th: Access Type
th: Date Posted
th: Actions
<input checkbox ''>
button: [edit]
button: [delete]
<input checkbox ''>
button: [edit]
button: [delete]
<input checkbox ''>
button: [edit]
button: [delete]
<input checkbox ''>
button: [edit]
button: [delete] Showing 1-4 of 142 recipes
button: Previous
button: 1
button: 2
button: 3
button: Next [warning]
h3: Confirm Recipe Deletion
p: Are you sure you want to permanently delete this recipe? This action cannot be undone and will remove it from all member feeds.
button: Cancel
button: Delete Recipe
h3: Add New Culinary Recipe
button: [close]
label: Recipe Title
<input text 'e.g. Herb-Crusted Rack of Lamb'>
label: Category
<select  ''>
option: Main Course
option: Pasta & Grains
option: Beverages
option: Desserts
label: Access Level
<select  ''>
option: Free
option: Premium
label: Prep Time
<input text 'e.g. 20m'>
label: Cook Time
<input text 'e.g. 30m'>
label: Recipe Description & Instructions
<textarea  'Enter step by step instructions...'>
button: Cancel
button: Save Recipe
```

**Business Logic:**
- Only accessible to users with 'Admin' role.
- Allows CRUD operations on corresponding entities.

**DB Impact:**
- Reads `Recipe` table.

---

### Submit Contest Entry - Contests - JamesThew.com
**ID/Slug:** `contest-submit`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/artisanal-7-piece-copper-culinary-cookware-and-d-c8a527.jpg`

**Visual Elements:**
```text
a: Home /
a: Contests /
a: Active Contests / Submit Contest Entry 8 of 12 cols desktop) -->

  ## SECTION
h1: Contest Entry Submission
p: Open to all culinary creators — registered members and guest gourmands alike.
label: Select Active Contest
<select  ''>
option: Best Italian Recipe or Summer Juice Tip (Ends Mar 31, 2026) [expand_more]
label: Entry Type
button: [skillet] Recipe
button: [lightbulb] Tip
label: Your Name
<input text 'e.g. Tariq Mansoor'>
label: Your Email
<input email 'e.g. tariq@domain.com'>
label: Entry Title
<input text 'e.g. Wild Morel &amp; Saffron Risotto with Charred Leek Emulsion'>
label: Category
<select  ''>
option: Italian
option: Juices
option: Vegetarian
option: Non-Vegetarian [expand_more]
label: Ingredients
<textarea  'List each ingredient on a new line with exact quantities, e.g.
- 300g Carnaroli rice
- 50g Cultured unsalted butter
- 0.5g Kashmir saffron threads'>
label: Cooking Procedure
<textarea  'Step-by-step cooking instructions with temperature and time indicators...'>
label: Tip Description & Practical Technique Context
<textarea  'Describe your technical nuance, secret prep method, or flavor enhancement technique with clarity and kitchen context...'>
label: Dish Photograph
<input file ''>
p: Drop your dish photograph here or click to browse
p: JPG, PNG, or WEBP up to 10MB. Clear natural kitchen lighting recommended. [check_circle] file_selected.jpg
<input checkbox ''>
button: [send] Submit Entry [verified] Entry successfully queued for verification!
button: [close]
```

**Business Logic:**
- Validate form inputs.
- If Guest trying to submit, redirect to Login/Register.

**DB Impact:**
- Creates `ContestSubmission` table.

---

### Subscription - Dashboard - JamesThew.com
**ID/Slug:** `dashboard-subscription`

**Image Paths:** None specific

**Visual Elements:**
```text
h2: Executive Culinary Scholar
p: Full access to Michelin-tier archives, masterclasses, and private contest entries. Started On October 14, 2023 Renews / Expires October 14, 
button: Renew Plan
button: Change Plan [info] Simulated Environment
p: All transactions and renewals within The Sanctuary are currently operating in Simulated Payments mode. No real charges are applied to your l
h3: Choose Your Culinary Pace
p: Select the tier that aligns with your kitchen ambitions. Switch or cancel at any moment. Monthly Access Flexible $10 / month
p: Billed monthly. Ideal for exploratory home chefs and seasonal enthusiasts.
li: [check_circle] Full access to James Thew masterclasses
li: [check_circle] Unlimited recipe saving & notes
li: [check_circle] Monthly culinary contest entries
button: Select Monthly Best Value Yearly Mastership [crown] Popular $100 / year
p: Billed annually ($8.33/mo). Two months free for dedicated culinary artists.
li: [check_circle] Everything in Monthly Access
li: [check_circle] Exclusive 4K video technique library
li: [check_circle] Direct Q&A sessions with Chef James Thew
li: [check_circle] VIP seating access for live kitchen events
button: Select Yearly
h3: Payment History
p: A complete ledger of your simulated subscription billing.
button: [download] Export Ledger
th: Date
th: Plan Description
th: Amount
th: Status
th: Receipt Oct 14, 2023 Yearly Mastership (2023 - 2024) $100.00 Completed
button: View Oct 14, 2022 Yearly Mastership (2022 - 2023) $100.00 Completed
button: View Sep 14, 2022 Monthly Access (Trial Conversion) $10.00 Completed
button: View
h4: Confirm Subscription Action
button: [close]
p: Are you sure you wish to process this simulated payment action for your membership?
button: Cancel
button: Confirm Payment
```

**Business Logic:**
- Only accessible to logged-in Members.
- Shows user-specific data (their submissions, favorites).

**DB Impact:**
- Reads static or CMS data.

---

### Terms of Service & Privacy - JamesThew.com
**ID/Slug:** `terms-privacy`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`

**Visual Elements:**
```text
a: Home [chevron_right] Terms & Privacy Legal Governance
h1: Terms of Service & Privacy Policy
p: Last updated: March 1, 2026 • Governing your engagement with Chef James Thew's digital culinary platform. [SIDEBAR] Section 01 [handshake]
h2: 1. Acceptance of Terms
p: By accessing, browsing, or utilizing the services provided by JamesThew.com , including digital masterclasses, haute cuisine recipe repertoi
p: If you do not accept these regulations in their entirety, you must discontinue your journey across our platform. These terms form an irrevoc
h2: 2. Membership & Subscription Billing
p: JamesThew.com offers specialized subscription tiers granting exclusive access to proprietary recipes, advanced sous-vide workflows, and dire
p: Full access to premier recipe indexes, technique archives, and monthly Q&A sessions. Patron Annual $100 / year
p: Preferred enrollment in weekend cookery ateliers, digital books, and prioritized adjudication.
p: Demonstration & Testing Notice: Certain transactions and checkout steps simulated during preview deployments represent operational demonstra
p: All fees are billed in USD. Prorated refunds are not extended for mid-cycle cancellations; your culinary credentials remain wholly active un
h2: 3. Community Contributions & Intellectual Property
p: The entirety of intellectual creations hosted on this platform—including proprietary marinades, technical plating diagrams, written recipes,
p: Members participating in community exchanges, ingredient adaptations, or submission forums grant JamesThew.com a perpetual, worldwide, royal
li: Originality: All uploaded dish descriptions and secrets must represent your authentic gastronomic work.
li: Commercial Prohibition: Platform materials may not be duplicated or repurposed for commercial kitchen ventures without prior written assent.
li: Attribution: Chef James retains right of paternity across all educational assets created under the academy mantle. Section 04 [emoji_events]
h2: 4. Contest Rules & Eligibility
p: JamesThew.com conducts seasonal culinary competitions designed to elevate craftsmanship. Unless explicitly restricted in an announcement, co
p: All recipe entries and sensory profiles undergo rigorous evaluation curated by Chef James Thew and guest Michelin-trained sous chefs. Adjudi
p: Winners are notified directly through registered digital channels. Trophies, culinary masterclasses, and honorary distinctions carry no subs
h2: 5. Termination & Cancellation
p: Subscribers may terminate their paid participation or general membership at any moment by navigating to their profile preferences. Upon conf
p: JamesThew.com holds unreserved authority to suspend, revoke, or permanently ban any account found violating culinary community guidelines, e
h2: 6. Information We Collect
p: To provide bespoke culinary instruction and manage your platform privileges, we gather designated information upon your engagement: [badge] 
h2: 7. Use of Personal Information
p: The information entrusted to JamesThew.com serves explicit culinary and administrative objectives. We under no circumstances broker or monet
li: Academy Correspondence: Dissemination of contest results, class curriculum schedules, and technique updates.
li: Inquiry Processing: Addressing direct requests regarding weekend workshops and culinary masterclasses.
li: Platform Integrity: Fraud interception, security audits, and verification of recipe copyright submissions. Section 08 [cookie]
h2: 8. Cookies & Storage
p: We employ local storage identifiers and essential encrypted session tokens to sustain persistent access across sessions, remember ingredient
h2: 9. Contact Information
p: Should you require official clarifications regarding these Terms of Service or exercise statutory rights regarding your personal records, pl
p: Formal requests are acknowledged and reviewed by Chef James Thew's administrative team within three business days. [FOOTER]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads static or CMS data.

---

### Tip Details - Tips & Tricks - JamesThew.com
**ID/Slug:** `tip-details`

**Image Paths:**
- `/images/chef-hat-logo-d2a80b.png`
- `/images/tip-details-img-5a34dc.jpg`

**Visual Elements:**
```text
a: Home /
a: Tips & Tricks /
a: Free Tips / Emulsifying Pan Sauces with Ice-Cold Butter Non-Vegetarian & Sauces FREE
h1: The Science of Emulsifying Pan Sauces with Ice-Cold Cultured Butter [person] Chef James Thew (Executive Chef) • [calendar_today] October 14,

  ## SECTION
h2: 1. The Temperature Paradox
p: Home cooks often assume that incorporating softened or room-temperature butter into a simmering wine or stock reduction facilitates seamless
p: Mastering the classical French technique of monter au beurre hinges on refrigeration. Cubed, ice-cold butter (chilled to roughly 3°C to 5°C)
h2: 2. The Physics of Fat Spheres
p: Emulsification is an act of gentle mechanical suspension, not combustion. The instant cold butter cubes meet your concentrated liquid base, 
p: Continuous centrifugal action is critical. By swirling the curved walls of a heavy copper saucier in smooth circular strokes or rhythmic fig
h3: Chef James’s Golden Rule
p: "Never return the pan to violent boil once cold butter touches the reduction. Swirl continuously in rhythmic figure-eights until the sauce c
h2: 3. Acidity as an Emulsifier
p: Pure water and pure fat refuse kinship without a biochemical intermediary. In classical kitchencraft, your natural surfactants reside in the
p: When dry white wine or verjus reduces alongside finely minced shallots, natural pectins and tartaric acids concentrate together. These compo
h3: Key Steps / Quick Sequence
li: 1 Reduce deglazed stock, shallots, and wine by at least 75% until thickened and sticky at the pan’s base.
li: 2 Pull the sauté pan entirely off high heat, allowing thermal agitation to calm for 15 seconds.
li: 3 Drop in small, refrigerator-cold butter cubes two at a time, swirling continuously in rhythmic figure-eights.
li: 4 Cease movement when the sauce achieves a velvety nappe consistency, coating a wooden spoon without dripping thin. Share this culinary tip
button: [public]
button: [photo_camera]
button: [share]
button: [link] Copy Link

  ## SECTION
h2: More Culinary Wisdom from Chef James [lightbulb] Juices & Aromatics FREE
h3: Tempering Whole Spices in Cold-Pressed Mustard Oil
p: How smoking thresholds unlock sweet pungent allyls while neutralizing raw acridity in seed aromatics. Chef James Thew Oct 08, 2025
a: Read Tip [arrow_forward] [lightbulb] Vegetarian FREE
h3: Retaining Vibrant Chlorophyll in Blanched Greens
p: The chemical shift of magnesium in plant cells and why hyper-salinated rolling baths freeze enzyme breakdown. Chef James Thew Sep 29, 2025
a: Read Tip [arrow_forward] [lightbulb] Juices FREE
h3: The Secret to Crystal-Clear Citrus Clarification
p: Harnessing agar freeze-thaw syneresis to produce jewel-like, translucent cordials that elevate master service. Chef James Thew Sep 18, 2025
a: Read Tip [arrow_forward]
```

**Business Logic:**
- Standard rendering of content based on database records.

**DB Impact:**
- Reads `Tip` table.

---


## Built by agent
The following screens do NOT exist in Stitch and must be built in the same style:
1. Member "My Recipes" -> `/Dashboard/MyRecipes` (copy the My Tips screen structure)
2. "Free Register" -> `/Account/RegisterFree` (copy the Login/Join Now style)
3. "Upgrade to post" locked states for a Free user in the member dashboard
4. Edit Recipe / Edit Tip pages for members (reuse the Add forms)


## Built by agent
The following screens do NOT exist in Stitch and must be built in the same style:
1. Member "My Recipes" -> `/Dashboard/MyRecipes` (copy the My Tips screen structure)
2. "Free Register" -> `/Account/RegisterFree` (copy the Login/Join Now style)
3. "Upgrade to post" locked states for a Free user in the member dashboard
4. Edit Recipe / Edit Tip pages for members (reuse the Add forms)
