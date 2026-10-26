# Cerebral Ops — ASP.NET Core

ASP.NET Core Razor Pages migration of the Cerebral Ops website.

## Stack
- ASP.NET Core / .NET 8
- Razor Pages
- Existing site styling loaded from the original public repository during this migration phase
- No database
- No PHP, Composer, PHPMailer, SMTP backend, or custom contact form
- Contact uses direct email and Calendly

## Main routes
`/`, `/about`, `/services`, `/contact`, `/case-studies`, `/who-we-serve`, `/why-cerebral-ops`, `/marketing-services`, `/technical-services`, `/ops-services`, `/privacy-policy`, `/terms-and-conditions`, `/products/revops-audit`, `/startup/accelerator`, `/startup/system-setup`, `/assessments/assessment`.

Legacy `.html` URLs redirect to the new Razor routes.

## Important migration note
The CSS and image assets currently reference the original CerebralOps repository so that the conversion can be tested quickly without duplicating binary assets. Before final production deployment, copy those assets into `wwwroot` and change the references to local paths.

The old PHP email backend and its committed SMTP credential are deliberately not migrated. Rotate the exposed mailbox password before production use.
