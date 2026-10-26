var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

var legacyRoutes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
{
    ["/index.html"] = "/",
    ["/about.html"] = "/about",
    ["/services.html"] = "/services",
    ["/contact.html"] = "/contact",
    ["/case-studies.html"] = "/case-studies",
    ["/Who-We-Serve.html"] = "/who-we-serve",
    ["/Why-Cerebral-Ops.html"] = "/why-cerebral-ops",
    ["/Marketing-Services.html"] = "/marketing-services",
    ["/Technical-Services.html"] = "/technical-services",
    ["/Ops-Services.html"] = "/ops-services",
    ["/privacy-policy.html"] = "/privacy-policy",
    ["/terms-and-conditions.html"] = "/terms-and-conditions",
    ["/products/revops-audit.html"] = "/products/revops-audit",
    ["/startup/accelerator.html"] = "/startup/accelerator",
    ["/startup/system-setup.html"] = "/startup/system-setup",
    ["/Assessments/assessment.html"] = "/assessments/assessment",
    ["/Assessments/thankyou.html"] = "/assessments/thankyou",
    ["/thankyou.html"] = "/thankyou"
};

app.Use(async (context, next) =>
{
    if (legacyRoutes.TryGetValue(context.Request.Path.Value ?? string.Empty, out var target))
    {
        context.Response.Redirect(target + context.Request.QueryString, permanent: true);
        return;
    }

    await next();
});

app.MapRazorPages();
app.Run();
