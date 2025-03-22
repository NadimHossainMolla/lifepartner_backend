using MatrimonyAPI.Repository;
using MatrimonyAPI.Repository.Implementations;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System.Text;

var corsPol = "corspolicy";

var builder = WebApplication.CreateBuilder(args);

// Ensure connection string is correctly retrieved
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext (which manages the SQL connection) as a Scoped service
builder.Services.AddScoped<DbContext>(provider => new DbContext(connectionString));

// Register repositories for dependency injection
builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILookUpDetailsRepository, LookUpDetailsRepository>();
builder.Services.AddScoped<IFilterRepository, FilterRepository>();
builder.Services.AddScoped<IFilesRepository, FilesRepository>();
builder.Services.AddScoped<IProposalRepository, ProposalRepository>();

// Register controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Life Partner API", Version = "v1" });

    // Add JWT Bearer authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and your token. Example: Bearer abc123"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add services to the container.
builder.Services.AddCors(p => p.AddPolicy(corsPol, build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//Configure CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigins", policy =>
//    {
//        policy.WithOrigins("https://example.com", "https://localhost:3000", "http://localhost:3000") // Allowed origins
//              .AllowCredentials() // Allow credentials (e.g., cookies, auth headers)
//              .AllowAnyHeader() // Allow all headers
//              .AllowAnyMethod(); // Allow all HTTP methods (GET, POST, PUT, etc.)
//    });
//});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    options.RoutePrefix = "swagger"; // Set Swagger UI route
});

// Redirect HTTP to HTTPS (if needed)
//app.UseHttpsRedirection();

// Use CORS policy
//app.UseCors("AllowSpecificOrigins");
app.UseCors(corsPol);

// Use Authorization middleware (if required later)
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Serve static files
app.UseStaticFiles(); // For serving static files from wwwroot
// Serve static files from the "Uploaded Files" directory
var uploadedFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadedFilesPath),
    RequestPath = "/UploadedFiles" // URL endpoint to access files
});

app.Run();
