using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//sets up db
var connectionString = builder.Configuration.GetConnectionString("DevDB");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

//scopes
builder.Services.AddScoped<ITokenService, TokenService>();

//auth 
builder.Services
.AddControllers().
AddNewtonsoftJson(options =>
{
    options
    .SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}
);

//Identitity

//Password settings 
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    options.Password.RequiredLength = 12
).AddEntityFrameworkStores<AppDbContext>();

//adding auth-initialisers
builder.Services.AddAuthentication(options =>
   {
       options.DefaultAuthenticateScheme =
        options.DefaultChallengeScheme =
        options.DefaultForbidScheme =
        options.DefaultScheme =
        options.DefaultSignInScheme =
        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
   }).AddJwtBearer(options =>
   {
       options.TokenValidationParameters =
       new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidIssuer = builder.Configuration["JWT:Issuer"],
           ValidateAudience = true,
           ValidAudience = builder.Configuration["JWT:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(
             System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
           )
       };
   }
   );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();

