var builder = WebApplication.CreateBuilder(args);

// Services must be added before Build()
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

var app = builder.Build();

// Middleware after Build()
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();